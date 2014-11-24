#region

using CallPlanner.Core.Entities;

#endregion

namespace CallPlanner.Core.Interfaces
{
    public interface IOriginatorDataProvider
    {
        Originator Provide(Interaction interaction);
    }
}