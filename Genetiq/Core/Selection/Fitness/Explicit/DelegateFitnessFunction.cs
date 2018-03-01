using System;

namespace Genetiq.Core.Selection.Fitness.Explicit
{
    /// <summary>
    /// Fitness function which wraps a delegate function.
    /// </summary>
    /// <typeparam name="T">genotype type</typeparam>
    public class DelegateFitnessFunction<T> : IExplicitFitnessFunction<T>
    {
        private readonly Func<T, double> _func;

        public DelegateFitnessFunction(Func<T, double> func)
        {
            _func = func;
        }

        public double EvaluateFitness(T individual)
        {
            return _func(individual);
        }

        public static implicit operator DelegateFitnessFunction<T>(Func<T, double> func)
        {
            return new DelegateFitnessFunction<T>(func);
        }
    }
}
