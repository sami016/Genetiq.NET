using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Genetiq.Core.Fitness;

namespace Genetiq.Core.Populations
{
    public class Population<T> : IPopulation<T>
    {
        private readonly T[] _genotypes;
        private IDictionary<T, double> _fitnesses;

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

        public void ExternalEvaluate(IDictionary<T, double> fitnesses, bool copyValues = false)
        {
            if (copyValues)
            {
                _fitnesses.Clear();
                foreach (var entry in fitnesses)
                {
                    _fitnesses.Add(entry.Key, entry.Value);
                }
            }
            else
            {
                _fitnesses = fitnesses;
            }
        }

        public void ReplaceAll(T[] individuals)
        {
            individuals.CopyTo(_genotypes, 0);
        }
    }
}
