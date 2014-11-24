#region

using CallPlanner.Core.Interfaces;
using CallPlanner.Core.Repositories;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

#endregion

namespace CallPlanner.Core.IOC
{
    internal class AgentGroupRepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IAgentGroupRepository>()
                    .ImplementedBy<InMemoryAgentGroupRepository>()
                    .LifestyleSingleton());
        }
    }
}