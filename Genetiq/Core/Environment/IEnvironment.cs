using System.Collections.Generic;
using Genetiq.Core.Environment.Populations;

namespace Genetiq.Core.Environment
{
    /// <summary>
    /// The high level population environment model.
    /// Useful in cases where multiple populations may be useful.
    /// </summary>
    public interface IEnvironment<T>
    {
        /// <summary>
        /// The set of populations within the environment.
        /// </summary>
        IEnumerable<IPopulation<T>> Populations { get; }

        /// <summary>
        /// Executes after a round/epoch.
        /// </summary>
        void AfterEpoch();
    }
}
