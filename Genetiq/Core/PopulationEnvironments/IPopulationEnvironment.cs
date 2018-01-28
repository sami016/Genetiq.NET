using System.Collections.Generic;
using Genetiq.Core.Populations;

namespace Genetiq.Core.PopulationEnvironments
{
    /// <summary>
    /// The high level population environment model.
    /// Useful in cases where multiple populations may be useful.
    /// </summary>
    public interface IPopulationEnvironment<T>
    {
        IEnumerable<IPopulation<T>> Populations { get; }
    }
}
