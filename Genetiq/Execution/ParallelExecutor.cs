using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using Genetiq.Core;
using Genetiq.Core.Fitness;
using Genetiq.Core.PopulationEnvironments;
using Genetiq.Core.Populations;
using Genetiq.Core.RoundStrategy;
using Genetiq.Core.Termination;
using Genetiq.Utility;

namespace Genetiq.Execution
{
    /// <summary>
    /// Parallel implementation of an executor.
    /// 
    /// Not currently worth using as it seems to add overhead without improvement.
    /// 
    /// Future parallel implementations should focus more on distributed populations and migration.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ParallelExecutor<T>
        where T : ICloneable
    {
        private struct FitnessComputationTask
        {
            public ArraySegment<T> Genotypes { get; set; }
            public ArraySegment<double> Fitnesses { get; set; }
        }

        public int NumThreads { get; set; } = Environment.ProcessorCount;

        private void StartThreads(CancellationToken cancellationToken, IFitnessFunction<T> fitnessFunction, BlockingCollection<FitnessComputationTask> fitnessComputationTasks)
        {
            for (var i = 0; i < NumThreads; i++)
            {
                new Thread(() => Process(cancellationToken, fitnessFunction, fitnessComputationTasks)).Start();
            }
        }

        private void Process(CancellationToken cancellationToken, IFitnessFunction<T> fitnessFunction, BlockingCollection<FitnessComputationTask> fitnessComputationTasks)
        {
            try
            {
                foreach (var item in fitnessComputationTasks.GetConsumingEnumerable(cancellationToken))
                {
                    for (var index = item.Fitnesses.Offset; index < item.Fitnesses.Count; index++)
                    {
                        item.Fitnesses.Array[index] = fitnessFunction.EvaluateFitness(item.Genotypes.Array[index]);
                    }
                }
            }
            catch (OperationCanceledException)
            {
            }
        }

        public void Run(AlgorithmProfile<T> profile)
        {
            var cancellationSource = new CancellationTokenSource();
            var fitnessProcessingQueue = new BlockingCollection<FitnessComputationTask>();

            StartThreads(cancellationSource.Token, profile.FitnessFunction, fitnessProcessingQueue);

            var roundNumber = 0;
            // Initial seed and fitness evaluation.
            foreach (var population in profile.PopulationEnvironment.Populations)
            {
                population.Seed(profile.SeedFactory);
                // Pre-fitness evaluation hook.
                profile.PreFitnessEvaluation?.Invoke(population);
                // Evaluate the fitness of every individual in the population.
                population.Evaluate(profile.FitnessFunction);
                // Post-fitness evaluation hook.
                profile.PostFitnessEvaluation?.Invoke(population);
            }
            // For each round.
            while (!profile.TerminationCondition.ShouldTerminate(CreateTerminationContext(roundNumber, profile.PopulationEnvironment)))
            {
                // For each population.
                foreach (var population in profile.PopulationEnvironment.Populations)
                {
                    // Run the round strategy.
                    profile.RoundStrategy.Run(
                        population,
                        profile.SelectionStrategy,
                        profile.Mutator,
                        profile.Combiner
                    );
                    // Pre-fitness evaluation hook.
                    profile.PreFitnessEvaluation?.Invoke(population);
                    // Evaluate the fitness of every individual in the population.
                    population.Evaluate(profile.FitnessFunction);

                    // Create result arrays.
                    T[] genotypes = population.Genotypes.Clone() as T[];
                    double[] fitnesses = new double[genotypes.Length];
                    var genotypePartitions = genotypes.Partition(NumThreads);
                    var fitnessPartitions = fitnesses.Partition(NumThreads);
                    for (var i = 0; i < NumThreads; i++)
                    {
                        fitnessProcessingQueue.Add(new FitnessComputationTask
                        {
                            Genotypes = genotypePartitions[i],
                            Fitnesses = fitnessPartitions[i]
                        });
                    }

                    // Wait for processing to finish.
                    while (fitnessProcessingQueue.Any()) ;

                    // Post-fitness evaluation hook.
                    profile.PostFitnessEvaluation?.Invoke(population);

                }
                roundNumber++;
            }

            cancellationSource.Cancel();
        }

        private TerminationConditionContext<T> CreateTerminationContext(int roundNumber, IPopulationEnvironment<T> populationEnvironment)
        {
            return new TerminationConditionContext<T>()
            {
                Round = roundNumber,
                PopulationEnvironment = populationEnvironment
            };
        }
    }
}
