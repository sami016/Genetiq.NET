using System;
using System.Collections.Generic;
using System.Linq;
using Genetiq.Core.Environment.Populations;
using Genetiq.Core.Selection;
using Genetiq.Core.Variation;
using Genetiq.Core.Variation.Combination;

namespace Genetiq.Core.Epoch
{
    /// <summary>
    /// Round startegy, where an entire new generation is bred each round.
    /// </summary>
    public class GenerationalEpochStrategy: IEpochStrategy
    {
        public IList<IShortlistStrategy> ShortlistStrategies { get; } = new List<IShortlistStrategy>();

        public void Run<T>(IPopulation<T> population, ISelectionProfile<T> selection, VariationProfile<T> variationProfile)
            where T : ICloneable
        {
            var newGeneration = new T[population.Count];

            var pos = 0;

            // Apply shortlisting strategies.
            foreach (var shortlistStrategy in ShortlistStrategies)
            {
                var shortListed = shortlistStrategy.GetShortlisted(population);
                for (var i=pos; i<pos+shortListed.Count(); i++)
                {
                    newGeneration[i] = shortListed[i - pos];
                }
                // Increment the current position by the number of shortlisted individuals.
                pos += shortListed.Count();
            }

            // Generate children using the selection strategy.
            for (var i=pos; i<population.Count; i++)
            {
                var child = (variationProfile.Combiner == null)
                    ? (T)selection.Select(population.Genotypes, population.FitnessCache).Clone()
                    : (T)variationProfile.Combiner.Create(selection, population);
                variationProfile.Mutator.Mutate(child);
                newGeneration[i] = child;
            }

            population.ReplaceAll(newGeneration);
        }
    }
}
