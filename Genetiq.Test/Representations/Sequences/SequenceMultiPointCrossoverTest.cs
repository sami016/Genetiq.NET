using FluentAssertions;
using Genetiq.Representations.Sequences;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Genetiq.Tests.Representations.Sequences
{
    public class SequenceMultiPointCrossoverTest
    {
        private ITestOutputHelper _out;

        public SequenceMultiPointCrossoverTest(ITestOutputHelper @out)
        {
            _out = @out;
        }

        [Fact]
        public void Test()
        {
            var a = Sequence.OfCharacterBytes("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            var b = Sequence.OfCharacterBytes("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbb");

            var combiner = new SequenceMultiPointCrossover<byte>(new Random());
            combiner.N = 3;

            this.Expect(() =>
            {
                var c = combiner.Combine(new Sequence<byte>[] { a, b });
                c.GetEncodedString().Should().Contain("a");
                c.GetEncodedString().Should().Contain("b");

                _out.WriteLine(c.ToString());
            });
        }
    }
}
