using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genetiq.Utility.DataSet
{
    /// <summary>
    /// Utility class for providing labelled data sets.
    /// Allows for the partitioning of testing/training data.
    /// </summary>
    /// <typeparam name="TData">Type of data</typeparam>
    /// <typeparam name="TLabel">Type of label</typeparam>
    public class LabelledDataSet<TData, TLabel>
    {
        // Data sets for each label.
        private IDictionary<TLabel, IList<TData>> _dataSets = new Dictionary<TLabel, IList<TData>>();
        // All data sets.
        private IList<LabelledData<TData, TLabel>> _all = new List<LabelledData<TData, TLabel>>();
        // RNG provider.
        private readonly Random _random;

        public LabelledDataSet(Random random)
        {
            _random = random;
        }


        public LabelledDataSet(Random random, IDictionary<TLabel, IList<TData>> dataSets) : this(random)
        {
            foreach (var key in dataSets.Keys)
            {
                _dataSets[key] = new List<TData>(dataSets[key]);
            }
        }


        /// <summary>
        /// Get the entire data set as an enumerable.
        /// </summary>
        public IEnumerable<LabelledData<TData, TLabel>> All
        {
            get
            {
                return _all;
            }
        }

        // Ensure index initialised.
        private void CheckInitialised(TLabel label)
        {
            if (!_dataSets.ContainsKey(label))
            {
                _dataSets.Add(label, new List<TData>());
            }
        }

        /// <summary>
        /// Adds a data point for a particular label class.
        /// </summary>
        /// <param name="label">label class</param>
        /// <param name="data">data</param>
        public void Add(TLabel label, TData data)
        {
            CheckInitialised(label);
            _dataSets[label].Add(data);

            _all.Add(new LabelledData<TData, TLabel>(data, label));
        }

        /// <summary>
        /// Takes a random individual from the whole data set.
        /// </summary>
        /// <returns>random sample</returns>
        public LabelledData<TData, TLabel> Sample()
        {
            if (_all.Count() == 0)
            {
                throw new Exception("No sampled exist");
            }
            return _all[_random.Next(_all.Count)];
        }

        /// <summary>
        /// Sample a data point randomly for a particular label.
        /// </summary>
        /// <param name="label">label</param>
        /// <returns>random sample</returns>
        public LabelledData<TData, TLabel> Sample(TLabel label)
        {
            if (!_dataSets.ContainsKey(label))
            {
                throw new Exception($"No data exists in calss {label}");
            }
            var set = _dataSets[label];
            var item = set[_random.Next(set.Count)];
            return new LabelledData<TData, TLabel>(item, label);
        }

        /// <summary>
        /// Sample a set of data points randomly for a given label class.
        /// </summary>
        /// <param name="label">label class</param>
        /// <param name="numSamples">number of samples to take</param>
        /// <returns></returns>
        public IList<LabelledData<TData, TLabel>> Sample(TLabel label, int numSamples)
        {
            if (!_dataSets.ContainsKey(label))
            {
                throw new Exception($"No data exists in class {label}");
            }
            if (_dataSets[label].Count < numSamples) {
                throw new Exception($"Not enough data in set, only {_dataSets[label].Count} exist");
            }
            var set = new List<TData>(_dataSets[label]);
            var output = new List<LabelledData<TData, TLabel>>();
            for (var i=0; i<numSamples; i++)
            {
                var index = _random.Next(numSamples);
                var item = set[index];
                set.RemoveAt(index);
                output.Add(new LabelledData<TData, TLabel>(item, label));
            }
            return output;
        }

        /// <summary>
        /// Splits a dataset into a training and testing set.
        /// If there are not enough data points to train using, this may fail.
        /// </summary>
        /// <param name="trainingSetFraction">fraction of each label set to be used for training</param>
        /// <param name="trainingSet">traing set</param>
        /// <param name="testingSet">testing set</param>
        public void Split(float trainingSetFraction, out LabelledDataSet<TData, TLabel> trainingSet, out LabelledDataSet<TData, TLabel> testingSet)
        {
            trainingSet = new LabelledDataSet<TData, TLabel>(_random);
            testingSet = new LabelledDataSet<TData, TLabel>(_random);

            foreach (var key in _dataSets.Keys)
            {
                var numTraining = (int)Math.Ceiling(_dataSets[key].Count * trainingSetFraction);
                var numTesting = (int)(_dataSets[key].Count - numTraining);

                var set = _dataSets[key]
                    .OrderBy(x => _random.NextDouble())
                    .ToList();

                for (var i=0; i<numTraining; i++)
                {
                    trainingSet.Add(key, set[i]);
                }
                for (var i=numTraining; i<numTraining+numTesting; i++)
                {
                    testingSet.Add(key, set[i]);
                }
            }
        }

    }
}
