using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Genetiq.Core;
using Genetiq.Core.Environment;
using Genetiq.Core.Environment.Populations;
using Genetiq.Core.Epoch.Termination;

namespace Genetiq.Execution
{

    /// <summary>
    /// Sequential executor which executes an execution profile locally on a single thread.
    /// </summary>
    /// <typeparam name="T">genotype type</typeparam>
    public class SequentialExecutor<T>
        where T : ICloneable
    {

        /// <summary>
        /// Initialises each population.
        /// </summary>
        /// <param name="profile">execution profile</param>
        private void InitialisePopulations(ExecutionProfile<T> profile)
        {
            // Initial seed and fitness evaluation.
            foreach (var population in profile.EnvironmentProfile.Environment.Populations)
            {
                population.Seed(profile.EnvironmentProfile.GenomeSeeder);
                // Pre-fitness evaluation hook.
                profile.PreFitnessEvaluation?.Invoke(population);
                // Post-fitness evaluation hook.
                profile.PostFitnessEvaluation?.Invoke(population);
            }
        }

        public ExecutionResult<T> Run(ExecutionProfile<T> profile)
        {
            // Initialises each population.
            InitialisePopulations(profile);

            var roundNumber = 0;
            // For each round.
            while (!profile.EpochProfile
                .TerminationCondition
                .ShouldTerminate(CreateTerminationContext(roundNumber, profile.EnvironmentProfile.Environment)))
            {
                // For each population.
                foreach (var population in profile.EnvironmentProfile.Environment.Populations)
                {
                    // Run the round strategy.
                    profile.EpochProfile.EpochStrategy.Run(
                        population,
                        profile.SelectionProfile,
                        profile.VariationProfile
                    );
                    // Pre-fitness evaluation hook.
                    profile.PreFitnessEvaluation?.Invoke(population);
                    // Post-fitness evaluation hook.
                    profile.PostFitnessEvaluation?.Invoke(population);
                }
                profile.EnvironmentProfile.Environment.AfterEpoch();

                roundNumber++;
            }

            return new ExecutionResult<T>
            {
                Environment = profile.EnvironmentProfile.Environment
            };
        }

        private TerminationConditionContext<T> CreateTerminationContext(int roundNumber, IEnvironment<T> populationEnvironment)
        {
            return new TerminationConditionContext<T>()
            {
                Round = roundNumber,
                PopulationEnvironment = populationEnvironment
            };
        }
    }
}
