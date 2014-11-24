﻿#region

using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

#endregion

namespace CallPlanner.Core.IOC
{
    internal class AssignerContainerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<AssignerContainer>().LifestyleSingleton());
        }
    }
}