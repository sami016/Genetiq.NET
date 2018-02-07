using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Genetiq.Core;
using Genetiq.Core.Fitness;
using Genetiq.Core.PopulationEnvironments;
using Genetiq.Core.Populations;
using Genetiq.Core.RoundStrategy;
using Genetiq.Core.Selection;
using Genetiq.Core.Termination;
using Genetiq.Execution;
using Genetiq.Representations.Sequences;

namespace Genetiq.Tests.Integration
{
    public class StringCharacterCountExample
    {

        static void Main(string[] args)
        {
            new StringCharacterCountExample().Run();
        }

        public void Run()
        {
            var random = new Random();

            // Create a factory function for generation genotypes. This is used to seed the initial population.
            Func<Sequence<byte>> seedFunc = () =>
            {
                var data = new byte[10];
                for (var i=0; i<10; i++)
                {
                    data[i] = (byte)random.Next(255);
                }
                return new Sequence<byte>(data);
            };

            // Create a mutator - we replace a byte at a random location with any byte in the range 0-255.
            var mutator = new SequenceReplaceMutation<byte>(random, SequenceReplaceMutation.RandomReplacementByte(random, 0, (byte)255));
            mutator.SetNumberOfMutations(1);
            // Employ a generational round strategy which replaces the entire population each round with new children.
            var roundStrategy = new GenerationalRoundStrategy();
            // Keep the most elite 5% of the population alive at all times.
            roundStrategy.ShortlistStrategies.Add(new ElitismShortlistStrategy(0.05));

            var algorithmProfile = new AlgorithmProfile<Sequence<byte>>
            {
                FitnessFunction = new AFitnessFunction(),
                RoundStrategy = roundStrategy,
                Mutator = mutator,
                SeedFactory = seedFunc,

                // Single Population of 1000.
                PopulationEnvironment = new SimplePopulationEnvironment<Sequence<byte>>(new Population<Sequence<byte>>(1000)),
                // Select individuals with a probability proportionate to their fitness.
                SelectionStrategy = new FitnessProportionateSelection(random),
                // Perform sexual recombination via uniform crossover.
                Combiner = new SequenceUniformCrossover<byte>(random),
            };

            // Create an executor - this is the object which runs our evolutionary algorithm.
            var executor = new SequentialExecutor<Sequence<byte>>();
            // Create stopwatch to time process.
            var stopWatch = new Stopwatch();


            // Terminate the algorithm after 500 rounds/epochs.
            var terminationCondition = new RoundThresholdTerminationCondition<Sequence<byte>>(500);
            // Run the algorithm.
            stopWatch.Start();
            executor.Run(algorithmProfile, terminationCondition);
            stopWatch.Stop();

            Debug.WriteLine($"Execution time: {stopWatch.ElapsedMilliseconds} ms");

            var pop = algorithmProfile.PopulationEnvironment.Populations.First();
            Debug.WriteLine($"Completed... pop has {pop.Count} individuals");
            foreach (var entry in pop.Fitnesses.OrderByDescending(x => x.Value).ToList())
            {
                Debug.WriteLine($"{entry.Key} {entry.Value}");
            }
        }
    }

    class AFitnessFunction : IFitnessFunction<Sequence<byte>>
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
            for (var i=0; i < sequence.Length; i++)
            {
                if (sequence.Data[i] == aCode)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
