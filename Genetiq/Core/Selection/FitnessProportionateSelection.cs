using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genetiq.Core.Selection
{
    /// <summary>
    /// A strategy for selecting individuals with probablity directly proportional to their fitness.
    /// NOTE: this strategy fails to work without normalisation if negative fitness values exist. See: TODO
    /// </summary>
    public class FitnessProportionateSelection: ISelectionStrategy
    {
        private readonly Random _random;

        public FitnessProportionateSelection(Random random)
        {
            _random = random;
        }

        public T Select<T>(T[] genotypes, IDictionary<T, double> fitnessScores)
        {
            var total = 0.0;
            foreach (var score in fitnessScores.Values)
            {
                total += score;
            }
            // If everything has 0 fitness, return a random individual.
            if (total == 0.0)
            {
                return genotypes[_random.Next(genotypes.Length)];
            }

            var position = _random.NextDouble() * total;
            total = 0.0;
            foreach (var scoreEntry in fitnessScores)
            {
                total += scoreEntry.Value;
                if (scoreEntry.Value > 0 && total > position)
                {
                    return scoreEntry.Key;
                }
            }
            throw new Exception("This point should not be reached");
        }
    }
}
