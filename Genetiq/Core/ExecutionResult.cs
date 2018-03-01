using System;
using System.Collections.Generic;
using System.Text;
using Genetiq.Core.Environment;

namespace Genetiq.Core
{
    /// <summary>
    /// Contains output results.
    /// </summary>
    /// <typeparam name="T">genotype type</typeparam>
    public class ExecutionResult<T>
    {
        /// <summary>
        /// The environment containing populations used from the run.
        /// </summary>
        public IEnvironment<T> Environment { get; set; }
    }
}
