using System;
using System.Collections.Generic;
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

        public void Run<T>(IPopulation<T> population, ISelectionStrategy selection, IMutator<T> mutator, ICombiner<T> combiner)
            where T : ICloneable
        {
            var newGeneration = new T[population.Count];
            for (var i=0; i<population.Count; i++)
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
