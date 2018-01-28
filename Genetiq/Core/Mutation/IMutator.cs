using Genetiq.Core.Genotype;
using System;
using System.Collections.Generic;
using System.Text;

namespace Genetiq.Core.Mutation
{
    /// <summary>
    /// Modifies
    /// </summary>
    public interface IMutator<T>
    {
        void Mutate(T genotype);
    }
}
