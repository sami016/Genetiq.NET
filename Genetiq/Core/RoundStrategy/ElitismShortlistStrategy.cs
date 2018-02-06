using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Genetiq.Core.Populations;

namespace Genetiq.Core.RoundStrategy
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
                .Fitnesses
                .OrderByDescending(x => x.Value)
                .Take(count)
                .Select(x => x.Key)
                .ToArray();
        }
    }
}
