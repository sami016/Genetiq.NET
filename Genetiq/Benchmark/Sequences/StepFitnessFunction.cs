﻿using System;
using System.Collections.Generic;
using System.Text;
using Genetiq.Core.Fitness;
using Genetiq.Representations.Sequences;

namespace Genetiq.Benchmark.Sequences
{
    /// <summary>
    /// 
    /// </summary>
    public class StepFitnessFunction : IFitnessFunction<Sequence<double>>
    {
        public double EvaluateFitness(Sequence<double> individual)
        {
            var sum = 0.0;
            for (var i = 0; i < individual.Length; i++)
            {
                sum += Math.Floor(individual.Data[i]);
            }
            return sum;
        }
    }
}
