using System;
using System.Collections.Generic;
using System.Text;

namespace Genetiq.Benchmark
{
    public class BenchmarkResults
    {
        public IDictionary<string, double> Scores { get; }

        public BenchmarkResults(IDictionary<string, double> scores)
        {
            Scores = scores;
        }
    }
}
