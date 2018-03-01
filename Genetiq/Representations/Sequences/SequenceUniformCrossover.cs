using System;
using Genetiq.Core.Variation.Combination;

namespace Genetiq.Representations.Sequences
{
    public class SequenceUniformCrossover<T> : ICombiner<Sequence<T>>
    {
        private readonly Random _random;

        public SequenceUniformCrossover(Random random)
        {
            _random = random;
        }

        public Sequence<T> Combine(Sequence<T>[] genotypes)
        {
            var parentA = genotypes[0];
            var parentB = genotypes[1];

            // Ensure parent A is longer.
            if (parentB.Length > parentA.Length)
            {
                var tmp = parentA;
                parentA = parentB;
                parentB = tmp;
            }

            var data = new T[parentA.Length];

            // Perform the uniform crossover.
            for (var i = 0; i < parentB.Length; i++)
            {
                if (_random.NextDouble() >= 0.5)
                {
                    data[i] = parentA.Data[i];
                }
                else
                {
                    data[i] = parentB.Data[i];
                }
            }

            // Copy the end of the longer string.
            for (var i = parentB.Length; i < parentA.Length; i++)
            {
                data[i] = parentA.Data[i];
            }

            return new Sequence<T>(data);
        }

        public int CombineCount => 2;
    }
}
