namespace Genetiq.Core.Selection.Fitness.Implicit
{
    /// <summary>
    /// Competitive fitness function - implicit rather than explicit measure of fitness which evaluates the fitness of an individual only in relation to that of another invidual.
    /// </summary>
    /// <typeparam name="T">Genotype type</typeparam>
    public interface IImplicitFitnessFunction<T>
    {
        /// <summary>
        /// Compares the fitnesses of two invididuals.
        /// Returns a flag indicating which of the individuals has the highest fitness.
        /// </summary>
        /// <param name="first">first individual being evaluated</param>
        /// <param name="second">second individual being evaluated</param>
        /// <returns>flag - true if first individual has a higher fitness, false if the second individual has a higher fitness.</returns>
        T CompareFitnesses(T first, T second);
    }
}
