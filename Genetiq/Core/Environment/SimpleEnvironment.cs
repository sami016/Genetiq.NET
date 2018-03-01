using System.Collections.Generic;
using Genetiq.Core.Environment.Populations;

namespace Genetiq.Core.Environment
{
    /// <summary>
    /// A simple population environment with only a single population.
    /// </summary>
    public class SimplePopulationEnvironment<T> : IEnvironment<T>
    {
        private readonly IPopulation<T> _population;

        public SimplePopulationEnvironment(IPopulation<T> population)
        {
            this._population = population;
        }

        public SimplePopulationEnvironment(int populationSize)
        {
            this._population = new Population<T>(populationSize);
        }

        public IEnumerable<IPopulation<T>> Populations => new IPopulation<T>[] { _population };

        public void AfterEpoch()
        {
        }
    }
}
