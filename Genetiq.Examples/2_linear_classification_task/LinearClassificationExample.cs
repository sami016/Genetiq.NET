using Genetiq.Core;
using Genetiq.Core.Environment;
using Genetiq.Core.Epoch;
using Genetiq.Core.Environment.Populations;
using Genetiq.Core.Selection;
using Genetiq.Core.Selection.Strategies;
using Genetiq.Core.Epoch.Termination;
using Genetiq.Core.Variation;
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
            var algorithmProfile = new ExecutionProfile<Sequence<double>>
            {
                EnvironmentProfile = new EnvironmentProfile<Sequence<double>>
                {
                    Environment = new SimplePopulationEnvironment<Sequence<double>>(new Population<Sequence<double>>(1000)),
                    GenomeSeeder = seedFunc
                },
                SelectionProfile = new ExplicitSelectionProfile<Sequence<double>>
                {
                    FitnessFunction = new ClassifierFitnessFunction(random, TestDataSet.TrainingData, false, true),
                    SelectionStrategy = new TournamentSelection(random, 10)
                },
                EpochProfile = new EpochProfile<Sequence<double>>
                {
                    TerminationCondition = new RoundThresholdTerminationCondition<Sequence<double>>(500),
                    EpochStrategy = new GenerationalEpochStrategy()
                },
                VariationProfile = new VariationProfile<Sequence<double>>()
                {

                    Mutator = new SequenceReplaceMutation<double>(random, d => d + random.NextDouble() * 0.05)
                        .SetNumberOfMutations(1),
                    Combiner = new SequenceUniformCrossover<double>(random),
                }
            };

            // Execute the EA.
            var executor = new SequentialExecutor<Sequence<double>>();
            executor.Run(algorithmProfile);

            // Create a function for evaluating against test set partition.
            var testFitness = new ClassifierFitnessFunction(random, TestDataSet.TestingData, false, false);

            // Output the top 5 individuals.
            var pop = algorithmProfile.EnvironmentProfile.Environment.Populations.First();
            Debug.WriteLine($"Completed... pop has {pop.Count} individuals");
            Debug.WriteLine("Top 5 individuals:");
            // OrderByDescending(x => x.Value)
            foreach (var entry in pop.Genotypes.Take(5).ToList())
            {
                // Plot the individual, it's fitness on the training set, then it's fitness on the testing set.
                //Debug.WriteLine($"{entry.Key}\n\tFitness (Training data): {entry.Value}\n\tPerformance (testing data): {testFitness.EvaluateFitness(entry.Key)*100}%\n\tFormula: {HumanReadableFunction(entry.Key)}");
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
