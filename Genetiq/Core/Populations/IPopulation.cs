using System.Collections.Generic;
using Genetiq.Core.Fitness;

namespace Genetiq.Core.Populations
{
    /// <summary>
    /// Represents a population of individuals.
    /// </summary>
    public interface IPopulation<T>
    {
        // The set of genotypes - these are 
        T[] Genotypes { get; }

        /// <summary>
        /// The mapping between genotypes and fitness values.
        /// </summary>
        IDictionary<T, double> Fitnesses { get; }

        /// <summary>
        /// Get the number of individuals within the population.
        /// </summary>
        int Count { get; }

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
        
        /// <summary>
        /// Evaluates the fitness of all individuals within the population.
        /// </summary>
        void Evaluate(IFitnessFunction<T> fitnessFunction);

    }
}
