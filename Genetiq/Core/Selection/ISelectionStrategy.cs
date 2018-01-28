using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Genetiq.Core.Genotype;

namespace Genetiq.Core.Selection
{
    public interface ISelectionStrategy
    {
        T Select<T>(T[] genotypes, IDictionary<T, double> fitnessScores);
    }
}
