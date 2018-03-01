using Genetiq.Core.Environment.Populations;
using Genetiq.Core.Selection;

namespace Genetiq.Core.Variation.Combination
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
        /// <returns>combined individual</returns>
        public static T Create<T>(this ICombiner<T> combiner, ISelectionProfile<T> selection, IPopulation<T> population)
        {
            var individuals = new T[combiner.CombineCount];
            for (int i = 0; i < combiner.CombineCount; i++)
            {
                individuals[i] = selection.Select(population.Genotypes, population.FitnessCache);
            }

            return combiner.Combine(individuals);
        }
    }
}
