using System;
using System.Collections.Generic;
using System.Text;

namespace Genetiq.Utility
{
    public static class ArrayExtensions
    {
        public static ArraySegment<T>[] Partition<T>(this T[] array, int partitionCount)
        {
            var setSizeMax = (int)Math.Ceiling(array.Length / (double)partitionCount);

            var result = new ArraySegment<T>[partitionCount];
            for (var i = 0; i < partitionCount; i++)
            {
                result[i] = new ArraySegment<T>(
                    array,
                    setSizeMax * i,
                    Math.Min(setSizeMax, array.Length - setSizeMax * i)
                );
            }
            return result;
        }
    }
}
