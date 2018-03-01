using Genetiq.Core.Environment;

namespace Genetiq.Core.Epoch.Termination
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
        public IEnvironment<T> PopulationEnvironment { get; set; }
    }
}
