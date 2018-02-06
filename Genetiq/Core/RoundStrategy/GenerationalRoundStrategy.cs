using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Genetiq.Core.Mutation;
using Genetiq.Core.Populations;
using Genetiq.Core.Selection;

namespace Genetiq.Core.RoundStrategy
{
    /// <summary>
    /// Round startegy, where an entire new generation is bred each round.
    /// </summary>
    public class GenerationalRoundStrategy: IRoundStrategy
    {
        public IList<IShortlistStrategy> ShortlistStrategies { get; } = new List<IShortlistStrategy>();

        public void Run<T>(IPopulation<T> population, ISelectionStrategy selection, IMutator<T> mutator, ICombiner<T> combiner)
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
                var child = (combiner == null)
                    ? (T)selection.Select(population.Genotypes, population.Fitnesses).Clone()
                    : combiner.Create(selection, population);
                mutator.Mutate(child);
                newGeneration[i] = child;
            }

            population.ReplaceAll(newGeneration);
        }
    }
}
