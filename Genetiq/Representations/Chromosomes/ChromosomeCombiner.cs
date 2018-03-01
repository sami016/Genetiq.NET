using Genetiq.Representations.Sequences;
using System;
using System.Collections.Generic;
using System.Text;
using Genetiq.Core.Variation.Combination;

namespace Genetiq.Representations.Chromosomes
{
    public class UniformChromosomeCombiner<T> : ICombiner<Sequence<T>>
    {
        private ICombiner<T> _chromosomeCombiner;

        public int CombineCount => _chromosomeCombiner.CombineCount;

        public UniformChromosomeCombiner(ICombiner<T> chromosomeCombiner)
        {
            _chromosomeCombiner = chromosomeCombiner;
        }

        public Sequence<T> Combine(Sequence<T>[] genotypes)
        {
            T[] items = new T[genotypes.Length];
            for (var i=0; i<genotypes.Length; i++)
            {
                var chromosomesAtIndex = new T[CombineCount];
                for (var pos=0; pos<CombineCount; pos++)
                {
                    chromosomesAtIndex[pos] = genotypes[pos].Data[i];
                }
                items[i] = _chromosomeCombiner.Combine(chromosomesAtIndex);
            }
            return new Sequence<T>(items);
        }
    }
}
