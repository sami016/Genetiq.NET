using Genetiq.Core.Fitness;
using Genetiq.Representations.Sequences;
using Genetiq.Utility.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genetiq.Examples._2_linear_classification_task
{
    public class ClassifierFitnessFunction : IFitnessFunction<Sequence<double>>
    {
        private readonly LabelledDataSet<Sequence<double>, LocationClass> _data;
        private readonly LinearClassifier _classifier = new LinearClassifier();
        private readonly Random _random;
        private readonly bool _stochastic;
        private readonly bool _continuous;

        /// <summary>
        /// Classifier fitness function.
        /// </summary>
        /// <param name="random">random</param>
        /// <param name="data">data</param>
        /// <param name="stochastic">Should the function be stochastic and take a random sample, or evaluate all samples.</param>
        /// <param name="continuous">Should the function be continuous - will be discrete if false.</param>
        public ClassifierFitnessFunction(Random random, LabelledDataSet<Sequence<double>, LocationClass> data, bool stochastic, bool continuous)
        {
            _data = data;
            _random = random;
            _stochastic = stochastic;
            _continuous = continuous;
        }

        private double ApplyThresholding(double val)
        {
            // If discrete, output 1 or 0 to make calculation of percentage easier.
            if (!_continuous)
            {
                if (val > 0)
                {
                    return 1;
                }else
                {
                    return 0;
                }
            }
            return val;
        }

        private double EvaluateReading(Sequence<double> individual, LabelledData<Sequence<double>, LocationClass> sample)
        {
            var result = LinearClassifier.Multiply(sample.Data.Data, individual.Data);

            // Max fitness: 1.
            if (sample.Label == LocationClass.UnitedKingdom)
            {
                // Target: -1 and below.
                return ApplyThresholding(Math.Min(-result, 1));
            }
            else
            {
                // Target: 1 and above.
                return ApplyThresholding(Math.Min(result, 1));
            }
        }

        public double EvaluateFitness(Sequence<double> individual)
        {
            if (_stochastic)
            {
                var sample = _data.Sample();
                return EvaluateReading(individual, sample);
            }
            else
            {
                return _data.All
                    .Select(x => EvaluateReading(individual, x))
                    .Average();
            }
        }
    }
}
