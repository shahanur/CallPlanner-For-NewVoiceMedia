#region

using System;
using CallPlanner.Core.Entities;
using CallPlanner.Core.Interfaces;

#endregion

namespace CallPlanner.Core.Assigners
{
    public abstract class AssignerBase
    {
        private readonly IAgentGroupRepository _agentGroupRepository;
        private readonly IAssignmentHelper _assignmentHelper;


        protected AssignerBase(IAgentGroupRepository agentGroupRepository, IAssignmentHelper assignmentHelper)
        {
            _agentGroupRepository = agentGroupRepository;
            _assignmentHelper = assignmentHelper;
        }

        protected abstract GroupTypeEnumerator.GroupType GroupType { get; }

        public IPrinter Printer { get; set; }
        public bool Active { get; set; }
        public string Key { get; set; }

        public bool Assign(OriginatorResponse response)
        {
            var assigned = true;
            try
            {
                var availablGroup = _agentGroupRepository.GetAgentGroup(GroupType);
                var assigneId = _assignmentHelper.UpdateAgentActivities(availablGroup, response.InteractionType);
                Printer.Write(string.Format("Deliver to group {0} and Agent {1}", GroupType, assigneId));
            }
            catch (Exception)
            {
                assigned = false;
            }
            return assigned;
        }
    }
}