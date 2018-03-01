using System.Collections.Generic;
using Genetiq.Core.Selection.Fitness.Explicit;

namespace Genetiq.Core.Environment.Populations
{
    /// <summary>
    /// Represents a population of individuals.
    /// </summary>
    public interface IPopulation<T>
    {
        // The set of genotypes - these are 
        T[] Genotypes { get; }

        /// <summary>
        /// Get the number of individuals within the population.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Cache of fitness values, avoids recalculating fitnesses twice.
        /// </summary>
        FitnessCache<T> FitnessCache { get; }

        /// <summary>
        /// Replaces all individuals within the population.
        /// </summary>
        /// <param name="individuals">individuals</param>
        void ReplaceAll(T[] individuals);

        /// <summary>
        /// Seeds the population with a set of genotypes.
        /// </summary>
        /// <param name="genotypes">set of genotypes</param>
        void Seed(IEnumerable<T> genotypes);
    }
}
