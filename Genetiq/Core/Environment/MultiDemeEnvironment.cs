using System.Collections.Generic;
using System.Linq;
using Genetiq.Core.Environment.Populations;

namespace Genetiq.Core.Environment
{
    /// <summary>
    /// A population environment where multiple demes exist, each with it's own population in parallel.
    /// Migration occurs occasionally between demes.
    /// </summary>
    public class MultiDemeEnvironment<T> : IEnvironment<T>
    {
        private IList<IPopulation<T>> _populations = new List<IPopulation<T>>();

        public MultiDemeEnvironment(int populationSize, int numberOfPopulations)
        {
            for (var i=0; i<numberOfPopulations; i++)
            {
                _populations.Add(new Population<T>(populationSize));
            }
        }

        public MultiDemeEnvironment(IEnumerable<IPopulation<T>> populations)
        {
            _populations = populations.ToList();
        }

        public IEnumerable<IPopulation<T>> Populations => _populations;

        public void AfterEpoch()
        {
        }
    }
}
