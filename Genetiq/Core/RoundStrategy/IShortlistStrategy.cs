using Genetiq.Core.Populations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Genetiq.Core.RoundStrategy
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
