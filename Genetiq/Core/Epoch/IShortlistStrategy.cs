using Genetiq.Core.Environment.Populations;

namespace Genetiq.Core.Epoch
{
    /// <summary>
    /// Strategy for shortlisting the selection of genotypes before the main selection phase.
    /// Currently only applicable in generational round strategy.
    /// </summary>
    public interface IShortlistStrategy
    {
        T[] GetShortlisted<T>(IPopulation<T> population);
    }
}
