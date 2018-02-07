using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Genetiq.Benchmark.Sequences;
using Genetiq.Core;
using Genetiq.Core.Fitness;
using Genetiq.Core.Termination;
using Genetiq.Execution;
using Genetiq.Representations.Sequences;

namespace Genetiq.Benchmark
{
    public class BenchmarkRunner
    {
        private static readonly IDictionary<string, IFitnessFunction<Sequence<double>>> _benchmarkCases;

        static BenchmarkRunner()
        {
            _benchmarkCases = new Dictionary<string, IFitnessFunction<Sequence<double>>>
            {
                {"F1", new FitnessFunctionInverter<Sequence<double>>(new SphereFitnessFunction())}
            };
        }

        private readonly Func<AlgorithmProfile<Sequence<double>>> _algorithmProfileFactory;

        public BenchmarkRunner(Func<AlgorithmProfile<Sequence<double>>> algorithmProfileFactory)
        {
            _algorithmProfileFactory = algorithmProfileFactory;
        }

        public BenchmarkResults Run()
        {
            var results = new BenchmarkResults();
            var executor = new SequentialExecutor<Sequence<double>>();
            foreach (var benchmark in _benchmarkCases)
            {
                var profile = _algorithmProfileFactory();
                profile.FitnessFunction = benchmark.Value;

                executor.Run(profile, new RoundThresholdTerminationCondition<Sequence<double>>(100));
                results.Scores[benchmark.Key] = profile.PopulationEnvironment.Populations.SelectMany(x => x.Fitnesses.Values).Max();
            }

            return results;
        }
    }
}
