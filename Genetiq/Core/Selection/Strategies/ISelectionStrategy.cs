using Genetiq.Core.Selection.Fitness.Explicit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Genetiq.Core.Selection.Strategies
{
    public interface ISelectionStrategy
    {
        T Select<T>(T[] genotypes, FitnessScore<T>[] fitnessScores);
    }
}
