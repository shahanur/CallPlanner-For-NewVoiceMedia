#region

using CallPlanner.Core.Factories;
using CallPlanner.Core.Interfaces;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

#endregion

namespace CallPlanner.Core.IOC
{
    internal class ValidatorFactoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IValidatorFactory>().ImplementedBy<ValidatorFactory>().LifestyleSingleton());
        }
    }
}