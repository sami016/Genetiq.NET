using Genetiq.Representations.Sequences;
using System;
using System.Collections.Generic;
using System.Text;
using Genetiq.Core.Variation.Mutation;

namespace Genetiq.Representations.Chromosomes
{
    public class ChromosomeMutator<T> : Mutators<T>, IMutator<Sequence<T>>
    {
        public ChromosomeMutator(Random random) : base(random)
        {
        }

        public void Mutate(Sequence<T> genotype)
        {
            foreach (var chromosome in genotype.Data)
            {
                Mutate(chromosome);
            }
        }
    }
}
