using System;
using System.Collections.Generic;
using System.Text;
using Genetiq.Core.Fitness;
using Genetiq.Representations.Sequences;

namespace Genetiq.Benchmark.Sequences
{

    /// <summary>
    /// Rosenbrock fitness function - based on De Jong's test function F2.
    /// Limits: -5.12 <= x[i] <= 5.12
    /// Global minimum: f(x) = 0; x[i] = 1.
    /// </summary>
    public class RosenbrockFitnessFunction : IFitnessFunction<Sequence<double>>
    {
        public double EvaluateFitness(Sequence<double> individual)
        {
            var sum = 0.0;
            for (var i = 0; i < individual.Length - 1; i++)
            {
                sum += 100.0 * Math.Pow(individual.Data[i+1] - Math.Pow(individual.Data[i], 2), 2);
                sum += Math.Pow(1.0 - individual.Data[i], 2);
            }
            return sum;
        }
    }
}
