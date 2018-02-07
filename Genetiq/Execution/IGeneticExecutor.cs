using System;
using System.Collections.Generic;
using System.Text;
using Genetiq.Core;
using Genetiq.Core.Termination;

namespace Genetiq.Execution
{
    /// <summary>
    /// A genetic executor that carries out the algorithm.
    /// </summary>
    /// <typeparam name="T">individual genotype type</typeparam>
    public interface IGeneticExecutor<T>
        where T : ICloneable
    {
        /// <summary>
        /// Runs a given algorithm profile.
        /// 
        /// Objects within the algorithm profile will be modified as the algorithm runs.
        /// 
        /// Independent runs should initialise a new algorithm profile.
        /// </summary>
        /// <param name="algorithmProfile">algorithm profile</param>
        /// <param name="terminationCondition">termination condition which determines when to halt</param>
        void Run(AlgorithmProfile<T> algorithmProfile, ITerminationCondition<T> terminationCondition);

    }
}
