using FluentAssertions;
using Genetiq.Representations.Sequences;
using System;
using Xunit;

namespace Genetiq.Test.Representations.Sequences
{
    public class SequenceSinglePointCrossoverTest
    {
        [Fact]
        public void Test()
        {
            var a = Sequence.OfCharacterBytes("aaaaaaaaaa");
            var b = Sequence.OfCharacterBytes("bbbbbbbbbb");

            var combiner = new SequenceSinglePointCrossover<byte>(new Random());

            this.Expect(() =>
            {
                var c = combiner.Combine(new Sequence<byte>[] { a, b });
                c.GetEncodedString().Should().Contain("a");
                c.GetEncodedString().Should().Contain("b");
            });
        }
    }
}
