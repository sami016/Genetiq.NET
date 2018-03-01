using System;
using Genetiq.Core.Variation.Combination;

namespace Genetiq.Representations.Sequences
{
    public class SequenceSinglePointCrossover<T> : ICombiner<Sequence<T>>
    {
        private readonly Random _random;

        public SequenceSinglePointCrossover(Random random)
        {
            _random = random;
        }

        public Sequence<T> Combine(Sequence<T>[] genotypes)
        {
            var parentA = genotypes[0];
            var parentB = genotypes[1];

            // Random ordering.
            if (_random.NextDouble() >= 0.5)
            {
                var tmp = parentB;
                parentB = parentA;
                parentA = tmp;
            }

            var aLength = parentA.Length;
            var bLength = parentB.Length;

            // Choose a crossover point.
            var crossoverPoint = _random.Next(aLength);

            // If the second parent is shorter in length...
            if (crossoverPoint > bLength)
            {
                // Just take upto the merge point on the first.
                var singleMergeData = new T[crossoverPoint];
                Array.Copy(parentA.Data, singleMergeData, 0);
                return new Sequence<T>(singleMergeData);
            }

            var data = new T[bLength];
            Array.Copy(parentA.Data, 0, data, 0, crossoverPoint);
            Array.Copy(parentB.Data, 0, data, crossoverPoint, bLength - crossoverPoint);
            return new Sequence<T>(data);
        }

        public int CombineCount => 2;
    }
}
