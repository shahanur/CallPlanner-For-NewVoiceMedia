#region

using CallPlanner.Core.Attributes;
using CallPlanner.Core.Entities;
using CallPlanner.Core.Interfaces;

#endregion

namespace CallPlanner.Core.Assigners
{
    [Assigner("EvenGroupAssigner")]
    public class EvenGroupAssigner : AssignerBase
    {
        public EvenGroupAssigner(IAgentGroupRepository agentGroupRepository, IAssignmentHelper assignmentHelper)
            : base(agentGroupRepository, assignmentHelper)
        {
        }

        protected override GroupTypeEnumerator.GroupType GroupType
        {
            get { return GroupTypeEnumerator.GroupType.A; }
        }
    }
}