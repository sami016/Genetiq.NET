using System;

namespace Genetiq.Core.Environment.Populations
{
    public static class PopulationExtensions
    {
        public static void Seed<T>(this IPopulation<T> population, Func<T> genotypeFactory)
        {
            var genoTypes = new T[population.Count];
            for (var i = 0; i < population.Count; i++)
            {
                genoTypes[i] = genotypeFactory();
            }
            population.Seed(genoTypes);
        }

    }
}
