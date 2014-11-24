#region

using CallPlanner.Core.Interfaces;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

#endregion

namespace CallPlanner.Core.IOC
{
    public class OriginatorDataProviderInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IOriginatorDataProvider>().ImplementedBy<OriginatorDataProvider>().LifestyleSingleton());
        }
    }
}