using FluentAssertions;
using Genetiq.Core.Fitness;
using Genetiq.Core.Populations;
using Genetiq.Core.RoundStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Genetiq.Test.Core.RoundStrategy
{
    public class ElitismShortlistStrategyTest
    {
        [Fact]
        public void EnsureTopTaken()
        {
            var elitism = new ElitismShortlistStrategy(0.1);
            var pop = new Population<double>(22);
            for (var i=0; i<pop.Count; i++)
            {
                pop.Genotypes[i] = i;
            }
            pop.Evaluate(new DelegateFitnessFunction<double>(i => i));

            var result = elitism.GetShortlisted(pop);
            result.Should().Contain(20.0);
            result.Should().Contain(21.0);
            result.Count().Should().Be(2);
        }
    }
}
