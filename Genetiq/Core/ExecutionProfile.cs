using Genetiq.Core.Selection;
using System;
using Genetiq.Core.Epoch;
using Genetiq.Core.Environment;
using Genetiq.Core.Environment.Populations;
using Genetiq.Core.Variation;

namespace Genetiq.Core
{

    /// <summary>
    /// Delegate for a pre-fitness evaluation hook.
    /// </summary>
    /// <typeparam name="T">individual type</typeparam>
    /// <param name="population">population</param>
    public delegate void PreFitnessEvaluationHook<T>(IPopulation<T> population);

    /// <summary>
    /// Delegate for a post-fitness evaluation hook.
    /// </summary>
    /// <typeparam name="T">individual type</typeparam>
    /// <param name="population">population</param>
    public delegate void PostFitnessEvaluationHook<T>(IPopulation<T> population);

    /// <summary>
    /// A collection of hooks for modifying the way in which the genetic algorithm is run.
    /// </summary>
    public class ExecutionProfile<T>
    {
        /// <summary>
        /// Defines the environment of populations.
        /// </summary>
        public EnvironmentProfile<T> EnvironmentProfile { get; set; }

        /// <summary>
        /// Defines the strategy for selecting individuals from a population.
        /// </summary>
        public ISelectionProfile<T> SelectionProfile { get; set; }

        /// <summary>
        /// Defines how each epoch is run.
        /// </summary>
        public EpochProfile<T> EpochProfile { get; set; }

        /// <summary>
        /// Defines the algorithm variation.
        /// </summary>
        public VariationProfile<T> VariationProfile { get; set; }

        /// <summary>
        /// Hook for making modifications to individuals prior to a fitness evaluation update.
        /// Generally useful modification for hybrid algorithms (e.g. memetic algorithm).
        /// </summary>
        public PreFitnessEvaluationHook<T> PreFitnessEvaluation { get; }

        /// <summary>
        /// Hook for making modifications to fitness values after the fitness evaluation has completed for a population.
        /// This is typically when any fitness rescaling operations would be applied - e.g. normalisation.
        /// </summary>
        public PostFitnessEvaluationHook<T> PostFitnessEvaluation { get; }

    }
}
