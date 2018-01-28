using System;
using System.Collections.Generic;
using System.Text;
using Genetiq.Core.PopulationEnvironments;

namespace Genetiq.Core.Termination
{
    public struct TerminationConditionContext<T>
    {
        /// <summary>
        /// The round or epoch count - the number of times the main loop has been executed so far.
        /// </summary>
        public int Round { get; set; }

        /// <summary>
        /// The population environment.
        /// </summary>
        public IPopulationEnvironment<T> PopulationEnvironment { get; set; }
    }
}
