using System;
using System.Collections.Generic;
using System.Text;
using Genetiq.Core.Populations;

namespace Genetiq.Core.PopulationEnvironments
{
    /// <summary>
    /// A simple population environment with only a single population.
    /// </summary>
    public class SimplePopulationEnvironment<T> : IPopulationEnvironment<T>
    {
        private readonly IPopulation<T> _population;

        public SimplePopulationEnvironment(IPopulation<T> population)
        {
            this._population = population;
        }

        public IEnumerable<IPopulation<T>> Populations => new IPopulation<T>[] { _population };
    }
}
