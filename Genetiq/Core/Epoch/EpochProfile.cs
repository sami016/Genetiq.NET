using System;
using System.Collections.Generic;
using System.Text;
using Genetiq.Core.Epoch.Termination;

namespace Genetiq.Core.Epoch
{
    /// <summary>
    /// High level profile for determining how each epoch (round) is executed.
    /// </summary>
    /// <typeparam name="T">genotype type</typeparam>
    public class EpochProfile<T>
    {
        /// <summary>
        /// The termination condition.
        /// </summary>
        public ITerminationCondition<T> TerminationCondition { get; set; }

        /// <summary>
        /// The strategy for each epoch.
        /// </summary>
        public IEpochStrategy EpochStrategy { get; set; }
    }
}
