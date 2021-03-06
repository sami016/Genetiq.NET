﻿namespace Genetiq.Core.Variation.Combination
{
    /// <summary>
    /// Interface for sexual recombination.
    /// 
    /// In the most general sense a set of individuals are combined to produce a new individual.
    /// </summary>
    public interface ICombiner<T>
    {
        T Combine(T[] genotypes);
        int CombineCount { get; }
    }
}
