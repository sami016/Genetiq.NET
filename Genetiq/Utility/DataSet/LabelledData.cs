using System;
using System.Collections.Generic;
using System.Text;

namespace Genetiq.Utility.DataSet
{
    /// <summary>
    /// Struct for a labelled data point.
    /// </summary>
    /// <typeparam name="TData">data type</typeparam>
    /// <typeparam name="TLabel">label type</typeparam>
    public struct LabelledData<TData, TLabel>
    {
        /// <summary>
        /// The data for the point.
        /// </summary>
        public TData Data { get; set; }

        /// <summary>
        /// The label class.
        /// </summary>
        public TLabel Label { get; set; }

        public LabelledData(TData data, TLabel label)
        {
            Data = data;
            Label = label;
        }
    }
}
