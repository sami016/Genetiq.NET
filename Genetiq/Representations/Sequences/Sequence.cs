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

        public int Length { get; }

        public Sequence(T[] data)
        {
            Data = data;
            Length = Data.Length;
        }

        object ICloneable.Clone()
        {
            return new Sequence<T>(Data.Clone() as T[]);
        }

        public static Sequence<T> From(params T[] args)
        {
            return new Sequence<T>(args);
        }

        public override string ToString()
        {
            // If encoded as bytes, stringify by decoding using UTF8.
            if (typeof(T) == typeof(byte))
            {
                var seq = this as Sequence<byte>;
                return seq.GetEncodedString();
            }
            var sb = new StringBuilder();
            var first = true;
            sb.Append("[");
            foreach (var item in Data)
            {
                if (first)
                {
                    first = false;
                }else
                {
                    sb.Append(", ");
                }
                sb.Append(item.ToString());
            }
            sb.Append(" ]");
            return sb.ToString();
        }
    }
}
