using Genetiq.Core.Populations;
using Genetiq.Core.Selection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Genetiq.Core.Mutation
{
    public static class CombinerExtensions
    {
        /// <summary>
        /// Applies a combiner to a population using a selection strategy.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="combiner">combiner</param>
        /// <param name="selection">selection strategy</param>
        /// <param name="population">population</param>
        /// <returns></returns>
        public static T Create<T>(this ICombiner<T> combiner, ISelectionStrategy selection, IPopulation<T> population)
        {
            var individuals = new T[combiner.CombineCount];
            for (int i = 0; i < combiner.CombineCount; i++)
            {
                individuals[i] = selection.Select(population.Genotypes, population.Fitnesses);
            }

            return combiner.Combine(individuals);
        }
    }
}
