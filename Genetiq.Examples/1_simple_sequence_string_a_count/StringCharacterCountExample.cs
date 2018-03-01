using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Genetiq.Core;
using Genetiq.Core.Environment;
using Genetiq.Core.Epoch;
using Genetiq.Core.Selection.Fitness;
using Genetiq.Core.Variation.Mutation;
using Genetiq.Core.Environment.Populations;
using Genetiq.Core.Epoch.Termination;
using Genetiq.Core.Selection;
using Genetiq.Core.Selection.Strategies;
using Genetiq.Core.Variation;
using Genetiq.Execution;
using Genetiq.Representations.Sequences;
using Genetiq.Core.Selection.Fitness.Explicit;

namespace Genetiq.Examples._1_simple_sequence_string_a_count
{
    public class StringCharacterCountExample
    {

        public static void Main(string[] args)
        {
            new StringCharacterCountExample().Run();
        }

        private readonly Random _random = new Random();

        // A factory function for generation genotypes. This is used to seed the initial population.
        private Sequence<byte> SeedFunction()
        {

            var data = new byte[10];
            for (var i = 0; i < 10; i++)
            {
                data[i] = (byte)_random.Next(255);
            }
            return new Sequence<byte>(data);
        }

        public void Run()
        {

            // Employ a generational round strategy which replaces the entire population each round with new children.
            var roundStrategy = new GenerationalEpochStrategy();
            // Keep the most elite 5% of the population alive at all times.
            roundStrategy.ShortlistStrategies.Add(new ElitismShortlistStrategy(0.05));

            var algorithmProfile = new ExecutionProfile<Sequence<byte>>
            {
                // Epoch profile - determining how each epoch (round) is executed.
                EpochProfile = new EpochProfile<Sequence<byte>>
                {
                    EpochStrategy = roundStrategy,
                    // Terminate the algorithm after 500 rounds/epochs.
                    TerminationCondition = new RoundThresholdTerminationCondition<Sequence<byte>>(100)
                },
                EnvironmentProfile = new EnvironmentProfile<Sequence<byte>>
                {
                    // Single Population of 500.
                    Environment = new SimplePopulationEnvironment<Sequence<byte>>(new Population<Sequence<byte>>(500)),
                    GenomeSeeder = SeedFunction
                },
                // Selection profile - determining how individuals are selected from the population.
                SelectionProfile = new ExplicitSelectionProfile<Sequence<byte>>
                {
                    // The explicit fitness function mapping each individual to a fitness value.
                    FitnessFunction = new AFitnessFunction(),
                    // Select individuals with a probability proportionate to their fitness.
                    SelectionStrategy = new FitnessProportionateSelection(_random),
                },
                // Variation profile determines mutation and recombination to use.
                VariationProfile = new VariationProfile<Sequence<byte>>()
                {
                    // Create a mutator set - we replace a byte at a random location with any byte in the range 0-255.
                    Mutator = new Mutators<Sequence<byte>>(_random)
                    {
                        // 0.8 chance of mutation.
                        {
                            new SequenceReplaceMutation<byte>(_random, SequenceReplaceMutation.RandomReplacementByte(_random, 0, (byte)255))
                                .SetNumberOfMutations(1),
                            0.8
                        }
                    },
                    // Perform sexual recombination via uniform crossover.
                    Combiner = new SequenceUniformCrossover<byte>(_random),
                }
            };

            // Create an executor - this is the object which runs our evolutionary algorithm.
            var executor = new SequentialExecutor<Sequence<byte>>();
            // Create stopwatch to time process.
            var stopWatch = new Stopwatch();

            // Run the algorithm.
            stopWatch.Start();
            executor.Run(algorithmProfile);
            stopWatch.Stop();

            Debug.WriteLine($"Execution time: {stopWatch.ElapsedMilliseconds} ms");

            var pop = algorithmProfile.EnvironmentProfile.Environment.Populations.First();
            Debug.WriteLine($"Completed... pop has {pop.Count} individuals");
            foreach (var entry in pop.FitnessCache.Ordered.Take(5).ToList())
            {
                Debug.WriteLine($"{entry.Genome} {entry.Fitness}");
            }
        }
    }

    class AFitnessFunction : IExplicitFitnessFunction<Sequence<byte>>
    {
        public static byte aCode = Encoding.UTF8.GetBytes("a")[0];

        public double EvaluateFitness(Sequence<byte> sequence)
        {
            var str = sequence;
            var count = 0.0;
            if (sequence == null)
            {
                throw new Exception("null sequence detected");
            }
            var length = sequence.Length;
            var data = sequence.Data;
            for (var i=0; i < length; i++)
            {
                if (data[i] == aCode)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
