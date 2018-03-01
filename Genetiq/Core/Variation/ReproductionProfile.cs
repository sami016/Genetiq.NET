using Genetiq.Core.Variation.Combination;
using Genetiq.Core.Variation.Mutation;

namespace Genetiq.Core.Variation
{
    public sealed class ReproductionProfile<T>
    {
        public IMutator<T> Mutator { get; set; }
        public ICombiner<T> Combiner { get; set; }

    }
}
