using System;
using System.Collections.Generic;
using System.Text;
using Genetiq.Core.Fitness;
using Genetiq.Representations.Sequences;

namespace Genetiq.Benchmark.Sequences
{

    /// <summary>
    /// Griewangk fitness function - based on De Jong's test function F8.
    /// Limits: -512 <= x[i] <= 511
    /// Global minimum: f(x) = 0; x[i] = 1.
    /// </summary>
    public class GriewangkFitnessFunction : IFitnessFunction<Sequence<double>>
    {
        public double EvaluateFitness(Sequence<double> individual)
        {
            var sum = 1.0;
            for (var i = 0; i < individual.Length; i++)
            {
                sum += Math.Pow(individual.Data[i], 2) / 4000;
            }

            var productTerm = 1.0;
            for (var i = 0; i < individual.Length; i++)
            {
                productTerm *= Math.Cos(individual.Data[i]/Math.Sqrt(i));
            }


            return 1 + sum - productTerm;
        }
}
}
