#region

using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

#endregion

namespace CallPlanner.Core.IOC
{
    public class DependencyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            InitializeWindsor(container);
        }

        private static void InitializeWindsor(IWindsorContainer container)
        {
            container.Install(
                new PrinterInstaller(),
                new ValidatorFactoryInstaller(),
                new RepositoryInstaller(),
                new OriginatorDataProviderInstaller(),
                new AssignerContainerInstaller(),
                new AgentGroupRepositoryInstaller(),
                new AssignmentHelperInstaller(),
                new AssignmentManagerInstaller());
        }
    }
}