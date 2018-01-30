using System;
using Genetiq.Core.Genotype;
using Genetiq.Core.Mutation;
using Genetiq.Core.Populations;
using Genetiq.Core.Selection;

namespace Genetiq.Core.RoundStrategy
{
    public interface IRoundStrategy
    {
        void Run<T>(IPopulation<T> population, ISelectionStrategy selection, IMutator<T> mutator, ICombiner<T> combiner)
             where T : ICloneable;
    }
}
