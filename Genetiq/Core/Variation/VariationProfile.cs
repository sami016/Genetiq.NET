using System;
using System.Collections.Generic;
using System.Text;
using Genetiq.Core.Variation.Combination;
using Genetiq.Core.Variation.Mutation;

namespace Genetiq.Core.Variation
{
    /// <summary>
    /// High level profile for determining how variation occurs.
    /// </summary>
    /// <typeparam name="T">genotype type</typeparam>
    public class VariationProfile<T>
    {
        /// <summary>
        /// Defines the mutation algorithm used upon a child being born.
        /// </summary>
        public IMutator<T> Mutator { get; set; }

        /// <summary>
        /// Defines the combiner algorithm used to optonally perform cross over.
        /// </summary>
        public ICombiner<T> Combiner { get; set; }
    }
}
