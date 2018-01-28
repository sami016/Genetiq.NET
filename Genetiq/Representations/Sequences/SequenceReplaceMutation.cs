using System;
using System.Collections.Generic;
using System.Linq;
using Genetiq.Core.Mutation;

namespace Genetiq.Representations.Sequences
{
    public static class SequenceReplaceMutation
    {
        public static Func<T, T> RandomReplacementSet<T>(Random random, IEnumerable<T> candidates)
        {
            var candidateArray = candidates.ToArray();
            return old => {
                var replacementIndex = random.Next(candidateArray.Length);
                return candidateArray[replacementIndex];
            };
        }

        public static Func<byte, byte> RandomReplacementByte(Random random, byte min, byte max)
        {
            return old =>
            {
                return (byte)random.Next(min, max);
            };
        }
    }

    /// <summary>
    /// Replaces a certain number of elements at random positions in the sequence.
    /// A replacement set function is used to select the new element.
    /// Allows specification of a constant of random value for number of times to run.
    /// </summary>
    public class SequenceReplaceMutation<T> : IMutator<Sequence<T>>
    {
        private readonly Random _random;
        private readonly Func<T, T> _replaceFactory;
        // Number of mutations to apply, normally 1.
        private Func<int> _numberOfMutations = () => 1;

        public SequenceReplaceMutation(Random random, Func<T, T> replaceFactory)
        {
            _random = random;
            _replaceFactory = replaceFactory;
        }

        public void SetNumberOfMutations(int number)
        {
            _numberOfMutations = () => number;
        }

        public void SetNumberOfMutationsFunc(Func<int> numberOfMutations)
        {
            _numberOfMutations = numberOfMutations;
        }

        public void Mutate(Sequence<T> sequence)
        {
            for (var i=0; i<_numberOfMutations(); i++)
            {
                var pos = _random.Next(sequence.Length);
                sequence.Data[pos] = _replaceFactory(sequence.Data[pos]);
            }
        }
    }
}
