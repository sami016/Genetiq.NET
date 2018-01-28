
namespace Genetiq.Core.Fitness
{
    /// <summary>
    /// Evaluates the fitness of an individual.
    /// </summary>
    public interface IFitnessFunction<T>
    {
        /// <summary>
        /// Evaluates the individuals fitness.
        /// </summary>
        /// <param name="individual">individual</param>
        /// <returns>fitness value</returns>
        double EvaluateFitness(T individual);
    }
}
