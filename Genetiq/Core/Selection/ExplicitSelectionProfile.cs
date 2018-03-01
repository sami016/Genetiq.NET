using Genetiq.Core.Selection;
using Genetiq.Core.Selection.Strategies;
using System;
using System.Collections.Generic;
using System.Text;
using Genetiq.Core.Selection.Fitness.Explicit;
using System.Linq;

namespace Genetiq.Core.Selection
{
    /// <summary>
    /// Selection profile for explicit fitness functions.
    /// </summary>
    /// <typeparam name="T">genotype type</typeparam>
    public class ExplicitSelectionProfile<T> : ISelectionProfile<T>
    {
        /// <summary>
        /// Selection strategy.
        /// </summary>
        public ISelectionStrategy SelectionStrategy { get; set; }

        /// <summary>
        /// Fitness function.
        /// </summary>
        public IExplicitFitnessFunction<T> FitnessFunction { get; set; }
        

        public T Select(T[] individuals, FitnessCache<T> fitnessCache)
        {
            fitnessCache.Update(individuals, FitnessFunction);
            return SelectionStrategy.Select(individuals, fitnessCache.FitnessScores);
        }
    }
}
