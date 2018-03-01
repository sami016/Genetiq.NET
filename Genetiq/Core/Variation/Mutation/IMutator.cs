namespace Genetiq.Core.Variation.Mutation
{
    /// <summary>
    /// Modifies
    /// </summary>
    public interface IMutator<T>
    {
        void Mutate(T genotype);
    }
}
