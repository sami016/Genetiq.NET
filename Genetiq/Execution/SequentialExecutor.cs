using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Genetiq.Core;
using Genetiq.Core.Fitness;
using Genetiq.Core.Genotype;
using Genetiq.Core.PopulationEnvironments;
using Genetiq.Core.Populations;
using Genetiq.Core.RoundStrategy;
using Genetiq.Core.Termination;

namespace Genetiq.Execution
{
    public class SequentialExecutor<T>
        where T : ICloneable
    {

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
                    // Post-fitness evaluation hook.
                    profile.PostFitnessEvaluation?.Invoke(population);

                }
                roundNumber++;
            }
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
