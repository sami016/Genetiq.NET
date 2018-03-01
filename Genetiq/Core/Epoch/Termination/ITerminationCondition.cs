namespace Genetiq.Core.Epoch.Termination
{
    /// <summary>
    /// Condition determining when execution should complete.
    /// </summary>
    /// <typeparam name="T">genotype type</typeparam>
    public interface ITerminationCondition<T>
    {
        /// <summary>
        /// Checks whether the algorithm should terminate.
        /// </summary>
        /// <param name="context">termination condition context</param>
        /// <returns>flag - true indicates to terminate</returns>
        bool ShouldTerminate(TerminationConditionContext<T> context);
    }
}
