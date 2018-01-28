namespace Genetiq.Core.Genotype
{
    /// <summary>
    /// A genotype encodes hereditary information for an individual within a population.
    /// 
    /// In order to work correctly with mutation operators - implementing classes must always be mutable.
    /// </summary>
    public interface IGenotype
    {
        /// <summary>
        /// Creates an identical copy of the genotype.
        /// </summary>
        /// <returns>identity genotype clone</returns>
        IGenotype Clone();
    }
}
