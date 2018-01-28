using System;
using System.Collections.Generic;
using System.Text;

namespace Genetiq.Core.Fitness
{
    /// <summary>
    /// A mapping between a genotype and a phenotype.
    /// 
    /// This is an optional module for transforming an individual before evaluating it's fitness.
    /// </summary>
    /// <typeparam name="TGenotype">genotype</typeparam>
    /// <typeparam name="TPhenotype">phenotype</typeparam>
    public interface IPhenotypeMapping<TGenotype, TPhenotype>
    {
        TPhenotype Map(TGenotype genotype);
    }
}
