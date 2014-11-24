#region

using CallPlanner.Core.Entities;

#endregion

namespace CallPlanner.Core.Interfaces
{
    public interface IAssignmentHelper
    {
        int UpdateAgentActivities(AgentGroup agentGroup, CpEnumerators.InteractionType interactionType);
    }
}