#region

using CallPlanner.Core.Entities;

#endregion

namespace CallPlanner.Core.Interfaces
{
    public interface IAgentGroupRepository
    {
        AgentGroup GetAgentGroup(GroupTypeEnumerator.GroupType groupType);
    }
}