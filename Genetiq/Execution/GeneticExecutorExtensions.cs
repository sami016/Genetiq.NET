using System;
using System.Collections.Generic;
using System.Text;
using Genetiq.Core;
using Genetiq.Core.Epoch.Termination;

namespace Genetiq.Execution
{
    public static class GeneticExecutorExtensions
    {
        /// <summary>
        /// Extension for executing using an algorithm profile factory.
        /// Useful in cases requiring subsequent independant runs.
        /// </summary>
        /// <typeparam name="T">genotype type</typeparam>
        /// <param name="geneticExecutor">genetic executor</param>
        /// <param name="algorithmProfileFactory">algorithm profile factory</param>
        /// <returns>algorithm profile</returns>
        public static ExecutionProfile<T> Run<T>(this IGeneticExecutor<T> geneticExecutor, Func<ExecutionProfile<T>> algorithmProfileFactory, ITerminationCondition<T> terminationCondition)
            where T : ICloneable
        {
            var profile = algorithmProfileFactory();
            geneticExecutor.Run(profile, terminationCondition);
            return profile;
        }
    }
}
