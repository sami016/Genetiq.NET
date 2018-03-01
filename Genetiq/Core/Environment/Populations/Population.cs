using System;
using System.Collections.Generic;
using System.Linq;
using Genetiq.Core.Selection.Fitness.Explicit;

namespace Genetiq.Core.Environment.Populations
{
    public class Population<T> : IPopulation<T>
    {
        private readonly T[] _genotypes;

        public T[] Genotypes => _genotypes;
        public int Count => _genotypes.Length;
        public FitnessCache<T> FitnessCache { get; } = new FitnessCache<T>();

        public Population(int populationSize)
        {
            _genotypes = new T[populationSize];
        }

        public void Seed(IEnumerable<T> genotypes)
        {
            if (genotypes.Count() != Count)
            {
                throw new Exception("seed set size does not match the population size");
            }
            genotypes.ToArray().CopyTo(_genotypes, 0);
        }

        public void ReplaceAll(T[] individuals)
        {
            individuals.CopyTo(_genotypes, 0);
        }
    }
}
