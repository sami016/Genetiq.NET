using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Genetiq.Core.Fitness;
using Genetiq.Core.Genotype;

namespace Genetiq.Core.Populations
{
    public class Population<T> : IPopulation<T>
    {
        private readonly T[] _genotypes;
        private readonly IDictionary<T, double> _fitnesses;

        public Population(int populationSize)
        {
            _genotypes = new T[populationSize];
            _fitnesses = new Dictionary<T, double>();
        }

        public T[] Genotypes => _genotypes;
        public IDictionary<T, double> Fitnesses => _fitnesses;

        public int Count => _genotypes.Length;

        public void Seed(IEnumerable<T> genotypes)
        {
            if (genotypes.Count() != Count)
            {
                throw new Exception("seed set size does not match the population size");
            }
            genotypes.ToArray().CopyTo(_genotypes, 0);
        }
        

        public void Evaluate(IFitnessFunction<T> fitnessFunction)
        {
            _fitnesses.Clear();
            // Evaluate genotype -> phenotype mapping, then fitnesses.
            for (int i = 0; i < Count; i++)
            {
                _fitnesses[_genotypes[i]] = fitnessFunction.EvaluateFitness(_genotypes[i]);
            }
        }

        public void ReplaceAll(T[] individuals)
        {
            individuals.CopyTo(_genotypes, 0);
        }
    }
}
