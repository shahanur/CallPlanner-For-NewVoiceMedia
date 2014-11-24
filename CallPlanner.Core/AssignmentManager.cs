#region

using System;
using CallPlanner.Core.Entities;
using CallPlanner.Core.Interfaces;

#endregion

namespace CallPlanner.Core
{
    public class AssignmentManager : IAssignerManager
    {
        private readonly AssignerContainer _container;

        public AssignmentManager(AssignerContainer container)
        {
            _container = container;
        }

        public bool PerformAssingment(OriginatorResponse response, IPrinter printer)
        {
            var result = true;
            try
            {
                var assigners = _container.GetActiveAssigners();
                var assigner = assigners[response.ResponseType.ToString().ToLower()];
                assigner.Printer = printer;
                assigner.Assign(response);
            }
            catch (Exception)
            {
                result = false;
            }
            return result;

        }
    }
}