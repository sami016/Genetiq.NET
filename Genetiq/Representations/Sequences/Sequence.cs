using System;
using System.Linq;
using System.Text;

namespace Genetiq.Representations.Sequences
{
    public static class Sequence
    {
        public static Sequence<byte> OfCharacterBytes(string stringInput)
        {
            return new Sequence<byte>(Encoding.UTF8.GetBytes(stringInput));
        }
    }

    /// <summary>
    /// Basic string representation.
    /// Data is encoded as a byte array.
    /// </summary>
    public class Sequence<T>: ICloneable
    {
        public T[] Data { get; }

        public int Length => Data.Length;

        public Sequence(T[] data)
        {
            Data = data;
        }

        object ICloneable.Clone()
        {
            return new Sequence<T>(Data.Clone() as T[]);
        }

        public override string ToString()
        {
            // If encoded as bytes, stringify by decoding using UTF8.
            if (typeof(T) == typeof(byte))
            {
                var seq = this as Sequence<byte>;
                return seq.GetEncodedString();
            }
            return base.ToString();
        }
    }
}
