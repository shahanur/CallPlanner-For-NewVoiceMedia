﻿#region

using CallPlanner.Core.Helpers;
using CallPlanner.Core.Interfaces;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

#endregion

namespace CallPlanner.Core.IOC
{
    internal class AssignmentHelperInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IAssignmentHelper>().ImplementedBy<AssignmentHelper>().LifestyleSingleton());
        }
    }
}