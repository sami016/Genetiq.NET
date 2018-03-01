using Genetiq.Core.Selection.Fitness.Explicit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genetiq.Core.Selection.Strategies
{
    /// <summary>
    /// Samples a set of individuals randomly, then selects the best of these.
    /// </summary>
    public class TournamentSelection : ISelectionStrategy
    {
        private readonly Random _random;
        private readonly int _participants;

        public TournamentSelection(Random random, int participants)
        {
            _random = random;
            _participants = participants;
        }

        public T Select<T>(T[] genotypes, FitnessScore<T>[] fitnessScores)
        {
            var count = fitnessScores.Count();
            T best = default(T);
            var max = double.NegativeInfinity;

            for (var i = 0; i < _participants; i++)
            {
                var entry = fitnessScores[_random.Next(count)];
                var fitness = entry.Fitness;
                if (fitness > max)
                {
                    best = entry.Genome;
                    max = fitness;
                }
            }

            return best;
        }
    }
}
