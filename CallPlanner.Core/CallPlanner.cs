#region

using System;
using CallPlanner.Core.Entities;
using CallPlanner.Core.Interfaces;

#endregion

namespace CallPlanner.Core
{
    public class CallPlanner
    {
        private readonly IAssignerManager _assignerManager;
        private readonly IOriginatorDataProvider _originatorDataProvider;
        private readonly IPrinter _printer;

        public CallPlanner(IAssignerManager assignerManager, IPrinter printer,
            IOriginatorDataProvider originatorDataProvider)
        {
            if (null == assignerManager)
                throw new ArgumentNullException("assignerManager");
            if (null == printer)
                throw new ArgumentNullException("printer");
            if (null == originatorDataProvider)
                throw new ArgumentNullException("originatorDataProvider");
            _assignerManager = assignerManager;
            _printer = printer;
            _originatorDataProvider = originatorDataProvider;
        }

        public bool Plan(Interaction interaction)
        {
            if(null == interaction)
                throw new ArgumentNullException("interaction");
            _printer.Write(string.Format("Receive {0} from {1}", interaction.InteractionType, interaction.Input));
            var originatorService = new OriginatorService(_originatorDataProvider, _printer);
            var originatorResponse = originatorService.GetOriginatorSpecificData(interaction);
            return _assignerManager.PerformAssingment(originatorResponse, _printer);
        }
    }
}