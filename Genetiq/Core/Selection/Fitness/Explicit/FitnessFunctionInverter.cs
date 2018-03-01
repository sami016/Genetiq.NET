namespace Genetiq.Core.Selection.Fitness.Explicit
{
    /// <summary>
    /// Inverts a fitness function.
    /// </summary>
    /// <typeparam name="T">genotype type</typeparam>
    public class FitnessFunctionInverter<T> : IExplicitFitnessFunction<T> 
    {
        private readonly IExplicitFitnessFunction<T> _inner;

        public FitnessFunctionInverter(IExplicitFitnessFunction<T> inner)
        {
            _inner = inner;
        }

        public double EvaluateFitness(T individual)
        {
            return -_inner.EvaluateFitness(individual);
        }
    }
}
