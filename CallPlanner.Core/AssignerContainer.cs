#region

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using CallPlanner.Core.Assigners;
using CallPlanner.Core.Attributes;
using CallPlanner.Core.Configuration;
using CallPlanner.Core.Interfaces;

#endregion

namespace CallPlanner.Core
{
    public sealed class AssignerContainer
    {
        private const string ActivefiltersFilterset = "ActiveAssigner/AssignerSet";
        private const string AssignerNamespace = "CallPlanner.Core.Assigners";
        private readonly IAgentGroupRepository _agentGroupRepository;
        private readonly IAssignmentHelper _assignmentHelper;
        private IDictionary<string, AssignerBase> _activeFilters;

        public AssignerContainer(IAgentGroupRepository agentGroupRepository, IAssignmentHelper assignmentHelper)
        {
            _agentGroupRepository = agentGroupRepository;
            _assignmentHelper = assignmentHelper;
        }


        public IDictionary<string, AssignerBase> GetActiveAssigners()
        {
            return _activeFilters ?? (_activeFilters = LoadFilters(ActivefiltersFilterset));
        }

        private IDictionary<string, AssignerBase> LoadFilters(string assignerPath)
        {
            IDictionary<string, AssignerBase> assigners = new Dictionary<string, AssignerBase>();
            var assignerSection = (AssignerSection) ConfigurationManager.GetSection(assignerPath);
            var assembly = Assembly.GetExecutingAssembly();
            var types =
                assembly.GetTypes()
                    .Where(type => type.IsClass && type.Namespace == AssignerNamespace);

            foreach (var assignerElement in assignerSection.Assigners.Cast<AssignerConfigElement>()
                .Where(
                    assignerElement =>
                        String.Equals(assignerElement.Active, Boolean.TrueString,
                            StringComparison.CurrentCultureIgnoreCase)))
            {
                assigners[assignerElement.Key] = CreateFilter(assignerElement, types);
            }

            return assigners;
        }

        private AssignerBase CreateFilter(AssignerConfigElement assignerConfigElement, IEnumerable<Type> types)
        {
            Type assignerType = null;
            foreach (var type in from type in types
                let assignerAttribute = type.GetCustomAttributes(true).FirstOrDefault()
                let attribute = assignerAttribute as AssignerAttribute
                where attribute != null && (attribute.AssignerName == assignerConfigElement.Name)
                select type)
            {
                assignerType = type;
            }

            if (assignerType == null) return null;
            var assigner =
                Activator.CreateInstance(assignerType, new object[] {_agentGroupRepository, _assignmentHelper}) as
                    AssignerBase;
            if (assigner == null) return null;

            bool activeFilter;
            bool.TryParse(assignerConfigElement.Active, out activeFilter);
            assigner.Active = activeFilter;

            assigner.Key = assignerConfigElement.Key;
            return assigner;
        }
    }
}