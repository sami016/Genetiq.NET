﻿using System;
using System.Collections.Generic;
using System.Text;
using Genetiq.Core;
using Genetiq.Core.Genotype;
using Genetiq.Core.Populations;

namespace Genetiq.Selection
{
    /// <summary>
    /// Defines a method of selecting from a population.
    /// </summary>
    interface ISelectionScheme<T>
    {
        T Select(IPopulation<T> population);
    }
}
