using System;
using System.Collections.Generic;
using System.Text;

namespace Genetiq.Core.Fitness
{
    /// <summary>
    /// Inverts a fitness function.
    /// </summary>
    /// <typeparam name="T">genotype type</typeparam>
    public class FitnessFunctionInverter<T> : IFitnessFunction<T> 
    {
        private readonly IFitnessFunction<T> _inner;

        public FitnessFunctionInverter(IFitnessFunction<T> inner)
        {
            _inner = inner;
        }

        public double EvaluateFitness(T individual)
        {
            return -_inner.EvaluateFitness(individual);
        }
    }
}
