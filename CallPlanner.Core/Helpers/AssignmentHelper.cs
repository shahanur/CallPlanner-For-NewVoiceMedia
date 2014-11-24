#region

using System;
using System.Collections.Generic;
using System.Linq;
using CallPlanner.Core.Entities;
using CallPlanner.Core.Interfaces;

#endregion

namespace CallPlanner.Core.Helpers
{
    public class AssignmentHelper : IAssignmentHelper
    {
        public int UpdateAgentActivities(AgentGroup agentGroup, CpEnumerators.InteractionType interactionType)
        {
            var availableAgents =
                agentGroup.Agents.Where(agent => agent.TotalCallAssignment == 0 || agent.TotalEmailAssignment < 5);
            var randomAgent = GetRandomAgent(availableAgents);
            if (interactionType.Equals(CpEnumerators.InteractionType.Email))
                randomAgent.TotalEmailAssignment = randomAgent.TotalEmailAssignment + 1;
            else
            {
                randomAgent.TotalCallAssignment = randomAgent.TotalCallAssignment + 1;
            }
            return randomAgent.Id;
        }

        private Agent GetRandomAgent(IEnumerable<Agent> availableAgents)
        {
            var random = new Random();
            var randomAgentIds = Enumerable.Range(1, 3);
            var availableAgent =
                availableAgents.FirstOrDefault(
                    agent => agent.Id.Equals(randomAgentIds.OrderBy(x => random.Next()).Take(2).First()));
            return availableAgent;
        }
    }
}