using System;
using System.Collections.Generic;
using System.Text;

namespace Genetiq.Representations.Sequences
{
    public static class SequenceExtensions
    {
        public static string GetEncodedString(this Sequence<byte> sequence, Encoding encoding = null)
        {
            return (encoding ?? Encoding.UTF8).GetString(sequence.Data);
        }
    }
}
