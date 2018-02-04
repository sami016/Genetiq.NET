using System;
using System.Collections.Generic;
using System.Text;

namespace Genetiq.Tests
{
    public static class TestHelperExtensions
    {
        /// <summary>
        /// Run some logic multiple times. 
        /// If it throws, restart and try again up to n times.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="times"></param>
        public static void Expect(this object test, Action action, int times = 10)
        {
            Exception lastException = null;
            for (var attempt = 0; attempt < times; attempt++)
            {
                try
                {
                    action();
                    // Passed if we reached here.
                    return;
                }
                catch (Exception e)
                {
                    lastException = e;
                }
            }
            throw lastException;
        }
    }
}
