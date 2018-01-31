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
    public class StringCharacterCountTest
    {

        static void Main(string[] args)
        {
            new StringCharacterCountTest().Run();
        }

        public void Run()
        {
            var random = new Random();

            Func<Sequence<byte>> seedFunc = () =>
            {
                var data = new byte[10];
                for (var i=0; i<10; i++)
                {
                    data[i] = (byte)random.Next(255);
                }
                return new Sequence<byte>(data);
            };

            Debug.WriteLine($"Trying to get string of 'a's");

            var a = Sequence.OfCharacterBytes("ababababab");
            var f = new AFitnessFunction().EvaluateFitness(a);
            Debug.WriteLine($"{a} {f}");

            var mutator = new SequenceReplaceMutation<byte>(random, SequenceReplaceMutation.RandomReplacementByte(random, 0, (byte)255));
            mutator.SetNumberOfMutations(1);

            var algorithmProfile = new AlgorithmProfile<Sequence<byte>>
            {
                // Single Population of 100.
                PopulationEnvironment = new SimplePopulationEnvironment<Sequence<byte>>(new Population<Sequence<byte>>(100)),

                SelectionStrategy = new FitnessProportionateSelection(random),
                FitnessFunction = new AFitnessFunction(),
                RoundStrategy = new GenerationalRoundStrategy(),
                TerminationCondition = new RoundThresholdTerminationCondition<Sequence<byte>>(5000),
                
                Mutator = mutator,
                Combiner = new SequenceUniformCrossover<byte>(random),

                SeedFactory = seedFunc
            };

            //new SequentialExecutor<Sequence<byte>>().Run(algorithmProfile);
            new ParallelExecutor<Sequence<byte>>().Run(algorithmProfile);

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
