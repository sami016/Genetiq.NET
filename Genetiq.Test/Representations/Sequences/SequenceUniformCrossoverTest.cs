using FluentAssertions;
using Genetiq.Representations.Sequences;
using System;
using Xunit;

namespace Genetiq.Test.Representations.Sequences
{
    public class SequenceUniformCrossoverTest
    {
        [Fact]
        public void Test()
        {
            var a = Sequence.OfCharacterBytes("aaaaaaaaaa");
            var b = Sequence.OfCharacterBytes("bbbbbbbbbb");

            var combiner = new SequenceUniformCrossover<byte>(new Random());

            this.Expect(() =>
            {
                var c = combiner.Combine(new Sequence<byte>[] { a, b });
                c.ToString().Should().Contain("a");
                c.ToString().Should().Contain("b");
            });
        }
    }
}
