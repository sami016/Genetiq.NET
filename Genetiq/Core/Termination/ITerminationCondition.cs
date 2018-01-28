using System;
using System.Collections.Generic;
using System.Text;

namespace Genetiq.Core.Termination
{
    public interface ITerminationCondition<T>
    {
        bool ShouldTerminate(TerminationConditionContext<T> context);
    }
}
