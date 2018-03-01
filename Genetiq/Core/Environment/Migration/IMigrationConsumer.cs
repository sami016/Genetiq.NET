using System.Collections.Generic;
using Genetiq.Core.Environment.Populations;

namespace Genetiq.Core.Environment.Migration
{
    public interface IMigrationConsumer
    {
        /// <summary>
        /// Samples n individuals from other populations that are not in the population being sampled into.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="populationEnvironment">the population environment</param>
        /// <param name="population">the population being sampled from</param>
        /// <returns></returns>
        IEnumerable<T> Sample<T>(IEnvironment<T> populationEnvironment, IPopulation<T> population);
    }
}
