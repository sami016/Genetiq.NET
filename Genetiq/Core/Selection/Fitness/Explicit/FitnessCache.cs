using System.Collections.Generic;
using System.Linq;

namespace Genetiq.Core.Selection.Fitness.Explicit
{
    /// <summary>
    /// Class for caching fitness values.
    /// </summary>
    public class FitnessCache<T>
    {
        private FitnessScore<T>[] _cache;

        public FitnessScore<T>[] FitnessScores => _cache;

        public IEnumerable<FitnessScore<T>> Ordered => FitnessScores.OrderByDescending(x => x.Fitness);

        public void Update(T[] genotypes, IExplicitFitnessFunction<T> fitnessFunction)
        {
            // Resize or create cache if required.
            if (_cache == null || _cache.Length != genotypes.Length)
            {
                _cache = new FitnessScore<T>[genotypes.Length];
            }
            // Update all values.
            var length = genotypes.Length;
            for (var i=0; i<length; i++)
            {
                var genotype = genotypes[i];
                _cache[i] = new FitnessScore<T>
                {
                    Genome = genotype,
                    Fitness = fitnessFunction.EvaluateFitness(genotype)
                };
            }
        }
    }
}
