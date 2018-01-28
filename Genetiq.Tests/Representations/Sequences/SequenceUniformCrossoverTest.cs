using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Genetiq.Representations.Sequences;
using FluentAssertions;

namespace Genetiq.Tests.Representations.Sequences
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
