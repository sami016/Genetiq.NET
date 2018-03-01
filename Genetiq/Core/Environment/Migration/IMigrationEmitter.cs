using Genetiq.Core.Environment.Populations;

namespace Genetiq.Core.Environment.Migration
{
    public interface IMigrationEmitter
    {
        T Emit<T>(IPopulation<T> population);
    }
}
