#region

using CallPlanner.Core.Interfaces;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

#endregion

namespace CallPlanner.Core.IOC
{
    public class AssignmentManagerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IAssignerManager>().ImplementedBy<AssignmentManager>().LifestyleSingleton());
        }
    }
}