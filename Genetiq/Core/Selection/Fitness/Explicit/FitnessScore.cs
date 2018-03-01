using System;
using System.Collections.Generic;
using System.Text;

namespace Genetiq.Core.Selection.Fitness.Explicit
{
    /// <summary>
    /// Struct storing genome and fitness value to avoid having to ever recalculate a fitness.
    /// 
    /// No accessors for performance reasons.
    /// </summary>
    /// <typeparam name="T">genotype type</typeparam>
    public struct FitnessScore<T>
    {
        public T Genome;
        public double Fitness;
    }
}
