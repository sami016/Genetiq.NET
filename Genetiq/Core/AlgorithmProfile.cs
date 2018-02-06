using Genetiq.Core.Fitness;
using Genetiq.Core.Mutation;
using Genetiq.Core.PopulationEnvironments;
using Genetiq.Core.RoundStrategy;
using Genetiq.Core.Selection;
using Genetiq.Core.Termination;
using System;
using Genetiq.Core.Populations;

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
    public class AlgorithmProfile<T>
    {
        /// <summary>
        /// Initial seed factory function used to create the genesis population.
        /// </summary>
        public Func<T> SeedFactory { get; set; }

        /// <summary>
        /// The type of population environment model to use.
        /// </summary>
        public IPopulationEnvironment<T> PopulationEnvironment { get; set; }

        /// <summary>
        /// The fitness function to use.
        /// </summary>
        public IFitnessFunction<T> FitnessFunction { get; set; }

        /// <summary>
        /// The termination condition - defining when to stop running.
        /// </summary>
        public ITerminationCondition<T> TerminationCondition { get; set; }

        /// <summary>
        /// Defines the strategy for selecting individuals from a population.
        /// </summary>
        public ISelectionStrategy SelectionStrategy { get; set; }

        /// <summary>
        /// The round strategy employed.
        /// </summary>
        public IRoundStrategy RoundStrategy { get; set; }

        /// <summary>
        /// Defines the mutation algorithm used upon a child being born.
        /// </summary>
        public IMutator<T> Mutator { get; set; }

        /// <summary>
        /// Defines the combiner algorithm used to optonally perform cross over.
        /// </summary>
        public ICombiner<T> Combiner { get; set; }

        /// <summary>
        /// Hook for making modifications to individuals prior to a fitness evaluation update.
        /// Generally useful modification for hybrid algorithms (e.g. memetic algorithm).
        /// </summary>
        public PreFitnessEvaluationHook<T> PreFitnessEvaluation;

        /// <summary>
        /// Hook for making modifications to fitness values after the fitness evaluation has completed for a population.
        /// This is typically when any fitness rescaling operations would be applied - e.g. normalisation.
        /// </summary>
        public PostFitnessEvaluationHook<T> PostFitnessEvaluation;

    }
}
