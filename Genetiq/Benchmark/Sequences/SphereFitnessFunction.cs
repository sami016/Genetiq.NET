using System;
using System.Collections.Generic;
using System.Text;
using Genetiq.Core.Fitness;
using Genetiq.Representations.Sequences;

namespace Genetiq.Benchmark.Sequences
{
    /// <summary>
    /// Sphere fitness function - based on De Jong's test function F1.
    /// Limits: -5.12 <= x[i] <= 5.12
    /// </summary>
    public class SphereFitnessFunction : IFitnessFunction<Sequence<double>>
    {
        public double EvaluateFitness(Sequence<double> individual)
        {
            var sum = 0.0;
            for (var i = 0; i < individual.Length; i++)
            {
                sum += Math.Pow(individual.Data[i], 2);
            }
            return sum;
        }
    }
}
