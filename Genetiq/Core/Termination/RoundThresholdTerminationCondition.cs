using System;
using System.Collections.Generic;
using System.Text;

namespace Genetiq.Core.Termination
{
    /// <summary>
    /// Termination after a set number of rounds have passed.
    /// </summary>
    public class RoundThresholdTerminationCondition<T> : ITerminationCondition<T>
    {
        private readonly int _roundLimit;

        public RoundThresholdTerminationCondition(int roundLimit)
        {
            _roundLimit = roundLimit;
        }


        public bool ShouldTerminate(TerminationConditionContext<T> context)
        {
            return context.Round >= _roundLimit;
        }
    }
}
