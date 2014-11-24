#region

using System.Collections.Generic;

#endregion

namespace CallPlanner.Core.Entities
{
    public class AgentGroup
    {
        public IEnumerable<Agent> Agents { get; set; }
        private bool IsAllBusy { get; set; }
    }
}