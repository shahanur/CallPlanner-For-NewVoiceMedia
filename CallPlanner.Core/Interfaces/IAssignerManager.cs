#region

using CallPlanner.Core.Entities;

#endregion

namespace CallPlanner.Core.Interfaces
{
    public interface IAssignerManager
    {
        bool PerformAssingment(OriginatorResponse response, IPrinter printer);
    }
}