using System;
using System.Collections.Generic;
using System.Text;

namespace Genetiq.Core.Environment
{
    /// <summary>
    /// High level profile for defining the environment of populations.
    /// </summary>
    /// <typeparam name="T">genotype type</typeparam>
    public class EnvironmentProfile<T>
    {
        /// <summary>
        /// The type of population environment model to use.
        /// </summary>
        public IEnvironment<T> Environment { get; set; }

        /// <summary>
        /// Seeder factory function used to create the initial population.
        /// </summary>
        public Func<T> GenomeSeeder { get; set; }
    }
}
