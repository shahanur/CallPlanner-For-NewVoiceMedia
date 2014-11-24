#region

using CallPlanner.Core.Attributes;
using CallPlanner.Core.Entities;
using CallPlanner.Core.Interfaces;

#endregion

namespace CallPlanner.Core.Assigners
{
    [Assigner("OddGroupAssigner")]
    public class OddGroupAssigner : AssignerBase
    {
        public OddGroupAssigner(IAgentGroupRepository agentGroupRepository, IAssignmentHelper assignmentHelper)
            : base(agentGroupRepository, assignmentHelper)
        {
        }

        protected override GroupTypeEnumerator.GroupType GroupType
        {
            get { return GroupTypeEnumerator.GroupType.B; }
        }
    }
}