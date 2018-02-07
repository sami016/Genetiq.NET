using Genetiq.Core;
using Genetiq.Core.PopulationEnvironments;
using Genetiq.Core.Populations;
using Genetiq.Core.RoundStrategy;
using Genetiq.Core.Selection;
using Genetiq.Core.Termination;
using Genetiq.Execution;
using Genetiq.Representations.Sequences;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Genetiq.Examples._2_linear_classification_task
{
    public class LinearClassificationExample
    {
        public static void Main(string[] args)
        {
            var random = new Random();

            // Configuration:
            Func<Sequence<double>> seedFunc = () =>
            {
                var data = new double[3];
                for (var i = 0; i < 3; i++)
                {
                    data[i] = random.NextDouble() * 2 - 1;
                }
                return new Sequence<double>(data);
            };
            var mutator = new SequenceReplaceMutation<double>(random, d => d + random.NextDouble() * 0.05);
            mutator.SetNumberOfMutations(1);
            var algorithmProfile = new AlgorithmProfile<Sequence<double>>
            {
                PopulationEnvironment = new SimplePopulationEnvironment<Sequence<double>>(new Population<Sequence<double>>(1000)),
                SelectionStrategy = new TournamentSelection(random, 10),
                FitnessFunction = new ClassifierFitnessFunction(random, TestDataSet.TrainingData, false, true),
                RoundStrategy = new GenerationalRoundStrategy(),
                Mutator = mutator,
                Combiner = new SequenceUniformCrossover<double>(random),
                SeedFactory = seedFunc
            };

            // Execute the EA.
            var executor = new SequentialExecutor<Sequence<double>>();
            executor.Run(algorithmProfile, new RoundThresholdTerminationCondition<Sequence<double>>(500));

            // Create a function for evaluating against test set partition.
            var testFitness = new ClassifierFitnessFunction(random, TestDataSet.TestingData, false, false);

            // Output the top 5 individuals.
            var pop = algorithmProfile.PopulationEnvironment.Populations.First();
            Debug.WriteLine($"Completed... pop has {pop.Count} individuals");
            Debug.WriteLine("Top 5 individuals:");
            foreach (var entry in pop.Fitnesses.OrderByDescending(x => x.Value).Take(5).ToList())
            {
                // Plot the individual, it's fitness on the training set, then it's fitness on the testing set.
                Debug.WriteLine($"{entry.Key}\n\tFitness (Training data): {entry.Value}\n\tPerformance (testing data): {testFitness.EvaluateFitness(entry.Key)*100}%\n\tFormula: {HumanReadableFunction(entry.Key)}");
            }

        }

        private static string HumanReadableFunction(Sequence<double> weightVector)
        {
            var x = (-weightVector.Data[0]) / weightVector.Data[1];
            var c = (-weightVector.Data[2]) / weightVector.Data[1];
            var op = c >= 0 ? "+" : "-";
            return $"y = {x}x {op} {Math.Abs(c)}";
        }
    }
}
