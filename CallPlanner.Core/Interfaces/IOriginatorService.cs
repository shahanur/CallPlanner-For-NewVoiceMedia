#region

using CallPlanner.Core.Entities;

#endregion

namespace CallPlanner.Core.Interfaces
{
    public interface IOriginatorService
    {
        OriginatorResponse GetOriginatorSpecificData(Interaction interaction);
    }
}