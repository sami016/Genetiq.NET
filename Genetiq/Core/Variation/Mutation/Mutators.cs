using System;
using System.Collections.Generic;

namespace Genetiq.Core.Variation.Mutation
{
    /// <summary>
    /// Collections of mutators, each applied with a determined probability.
    /// </summary>
    /// <typeparam name="T">genotype type</typeparam>
    public class Mutators<T> : Dictionary<IMutator<T>, double>, IMutator<T>
    {
        private readonly Random _random;

        public Mutators(Random random)
        {
            _random = random;
        }

        public void Mutate(T genotype)
        {
            foreach (var entry in this) {
                if (_random.NextDouble() < entry.Value)
                {
                    entry.Key.Mutate(genotype);
                }
            }
        }
    }
}
