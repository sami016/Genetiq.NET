using System;
using System.Collections.Generic;
using System.Text;

namespace Genetiq.Examples._2_linear_classification_task
{
    public class LinearClassifier
    {
        public static double Multiply(double[] data, double[] weights)
        {
            var total = 0.0;
            for (var i = 0; i < data.Length; i++)
            {
                total += data[i] * weights[i];
            }
            // add the bias term.
            total += weights[data.Length];
            return total;
        }

        public bool Classify(double[] data, double[] weights)
        {
            return Multiply(data, weights) >= 0;
        }
    }
}
