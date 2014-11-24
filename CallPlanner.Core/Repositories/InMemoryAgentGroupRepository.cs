#region

using System.Collections.Generic;
using System.Linq;
using CallPlanner.Core.Entities;
using CallPlanner.Core.Interfaces;

#endregion

namespace CallPlanner.Core.Repositories
{
    public class InMemoryAgentGroupRepository : IAgentGroupRepository
    {
        private readonly IList<Agent> _agents = new[]
        {
            new Agent {Name = "Gautam", Group = GroupTypeEnumerator.GroupType.A, Id = 1},
            new Agent {Name = "Myles", Group = GroupTypeEnumerator.GroupType.A, Id = 2},
            new Agent {Name = "Barry", Group = GroupTypeEnumerator.GroupType.A, Id = 3},
            new Agent {Name = "Alice", Group = GroupTypeEnumerator.GroupType.B, Id = 1},
            new Agent {Name = "Farha", Group = GroupTypeEnumerator.GroupType.B, Id = 2},
            new Agent {Name = "Rob", Group = GroupTypeEnumerator.GroupType.B, Id = 3},
            new Agent {Name = "Mark", Group = GroupTypeEnumerator.GroupType.C, Id = 1},
            new Agent {Name = "Amir", Group = GroupTypeEnumerator.GroupType.C, Id = 2},
            new Agent {Name = "Sally", Group = GroupTypeEnumerator.GroupType.C, Id = 3}
        };

        public AgentGroup GetAgentGroup(GroupTypeEnumerator.GroupType groupType)
        {
            var agentGroup = new AgentGroup {Agents = _agents.Where(agent => agent.Group.Equals(groupType))};
            return agentGroup;
        }
    }
}