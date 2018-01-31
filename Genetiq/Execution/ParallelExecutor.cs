using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Genetiq.Core;
using Genetiq.Core.PopulationEnvironments;
using Genetiq.Core.Populations;
using Genetiq.Core.Termination;

namespace Genetiq.Execution
{
    /// <summary>
    /// Standard parallel executor.
    /// The round for each population is synchronized, such that no population is ever ahead.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ParallelExecutor<T> : IGeneticExecutor<T>
        where T : ICloneable
    {
        public void ConfigureThreadPool(int coreScaleFacor = 2)
        {
            // Get the number of logical processors.
            var processorCount = Environment.ProcessorCount;
            ThreadPool.SetMinThreads(processorCount, processorCount);
        }

        public void Run(AlgorithmProfile<T> profile)
        {
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
                var populationTasks = profile.PopulationEnvironment.Populations
                    .Select(population => new Task(PopulationRound, new Tuple<AlgorithmProfile<T>, IPopulation<T>>(profile, population)))
                    .ToArray();
                foreach (var task in populationTasks)
                {
                    task.Start();
                }
                // Wait for all populations to finish the round.
                Task.WaitAll(populationTasks);

                roundNumber++;
            }
        }

        private void PopulationRound(object obj)
        {
            var state = obj as Tuple<AlgorithmProfile<T>, IPopulation<T>>;
            if (state == null)
            {
                return;
            }

            var profile = state.Item1;
            var population = state.Item2;

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

            // Create a dictionary to hold new fitness values.
            var evaluted = new ConcurrentDictionary<T, double>();
            var evaluateTasks = population.Genotypes.Select(x => new Task(() =>
            {
                while (!evaluted.TryAdd(x, profile.FitnessFunction.EvaluateFitness(x))) ;
            })).ToArray();
            foreach (var task in evaluateTasks)
            {
                task.Start();
            }
            Task.WaitAll(evaluateTasks);
            population.ExternalEvaluate(evaluted, false);

            // Post-fitness evaluation hook.
            profile.PostFitnessEvaluation?.Invoke(population);
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
