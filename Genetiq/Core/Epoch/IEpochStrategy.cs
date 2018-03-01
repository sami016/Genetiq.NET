using System;
using Genetiq.Core.Environment.Populations;
using Genetiq.Core.Selection;
using Genetiq.Core.Variation;

namespace Genetiq.Core.Epoch
{
    /// <summary>
    /// Strategy determining how a each epoch is executed.
    /// </summary>
    public interface IEpochStrategy
    {
        void Run<T>(IPopulation<T> population, ISelectionProfile<T> selection, VariationProfile<T> variationProfile)
             where T : ICloneable;
    }
}
