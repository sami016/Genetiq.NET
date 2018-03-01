using System;
using System.Collections.Generic;
using System.Text;
using Genetiq.Core.Selection.Fitness.Explicit;

namespace Genetiq.Core.Selection
{
    /// <summary>
    /// High level profile for determining how selection is performed which combines the fitness function and selection strategy.
    /// </summary>
    /// <typeparam name="T">genotype type</typeparam>
    public interface ISelectionProfile<T>
    {
        /// <summary>
        /// Select a genotype from the population.
        /// </summary>
        /// <param name="genotypes">genotypes</param>
        /// <returns></returns>
        T Select(T[] genotypes, FitnessCache<T> fitnessCache);
    }
}
