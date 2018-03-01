using System;
using System.Collections.Generic;
using System.Text;
using Genetiq.Core.Selection.Fitness.Explicit;
using Genetiq.Core.Selection.Fitness.Implicit;

namespace Genetiq.Core.Selection
{
    /// <summary>
    /// Selection profile for an implicit fitness function.
    /// </summary>
    /// <typeparam name="T">genotype type</typeparam>
    public class ImplicitSelectionProfile<T> : ISelectionProfile<T>
    {
        private readonly Random _random;

        public ImplicitSelectionProfile(Random random)
        {
            _random = random;
        }

        public IImplicitFitnessFunction<T> FitnessFunction { get; set; }

        public T Select(T[] individuals, FitnessCache<T> fitnessCache)
        {
            var individualA = individuals[_random.Next(individuals.Length)];
            var individualB = individuals[_random.Next(individuals.Length)];

            return FitnessFunction.CompareFitnesses(individualA, individualB);
        }
    }
}
