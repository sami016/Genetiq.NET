using System;
using System.Linq;
using Genetiq.Core.Environment.Populations;

namespace Genetiq.Core.Epoch
{
    public class ElitismShortlistStrategy : IShortlistStrategy
    {
        private readonly double _populationElitismFraction;

        public ElitismShortlistStrategy(double populationElitismFraction)
        {
            _populationElitismFraction = populationElitismFraction;
        }

        public T[] GetShortlisted<T>(IPopulation<T> population)
        {
            var count = (int)Math.Floor(population.Count * _populationElitismFraction);
            return population
                .Genotypes
                //.Fitnesses
                //.OrderByDescending(x => x.Value)
                .Take(count)
                //.Select(x => x.Key)
                .ToArray();
        }
    }
}
