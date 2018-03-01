using System;
using System.Collections.Generic;
using System.Text;
using Genetiq.Core.Variation.Combination;

namespace Genetiq.Representations.Sequences
{
    /// <summary>
    /// A multi-point crossover combiner for sequences.
    /// </summary>
    public class SequenceMultiPointCrossover<T> : ICombiner<Sequence<T>>
    {
        public virtual int N { get; set; } = 1;

        private Random _random;

        public SequenceMultiPointCrossover(Random random)
        {
            _random = random;
        }

        public Sequence<T> Combine(Sequence<T>[] genotypes)
        {
            var parentA = genotypes[0];
            var parentB = genotypes[1];

            if (parentB.Length > parentA.Length)
            {
                var tmp = parentA;
                parentA = parentB;
                parentB = parentA;
            }

            var lengthMax = parentA.Length;
            var lengthMin = parentB.Length;

            // Generate set of crossover points.
            var crossoverPoints = new int[N];
            for (var i = 0; i < N; i++)
            {
                crossoverPoints[i] = _random.Next(N);
            }
            Array.Sort(crossoverPoints);

            // Create a new result array.
            var resultArray = new T[lengthMax];
            
            // The current index within the crossover point array.
            var crossoverPointIndex = 0;
            // Boolean flag tracks which individual we are reading from - flipped whenever we advance in the crossover point array.
            var firstSequence = _random.NextDouble() >= 0.5;
            for (var i = 0; i < lengthMin; i++)
            {
                while (crossoverPointIndex < N && i >= crossoverPoints[crossoverPointIndex])
                {
                    crossoverPointIndex++;
                    firstSequence = !firstSequence;
                }
                resultArray[i] = firstSequence ? parentA.Data[i] : parentB.Data[i];
            }
            // If the lengths are mismatched, we read the rest from the longer of the two sequence.
            for (var i = lengthMin; i < lengthMax; i++)
            {
                resultArray[i] = parentA.Data[i];
            }

            return new Sequence<T>(resultArray);
        }

        public int CombineCount => 2;
    }
}
