using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Genetiq.Representations.Sequences;
using FluentAssertions;

namespace Genetiq.Tests.Representations.Sequences
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
