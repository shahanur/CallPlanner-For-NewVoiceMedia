#region

using System;
using System.ComponentModel;
using CallPlanner.Core.IOC;
using Castle.Windsor;

#endregion

namespace CallPlanner.Core
{
    public class AppStart
    {
        private static readonly IWindsorContainer Container = new WindsorContainer();

        public static IWindsorContainer RegisterDependencies()
        {
            Container.Install(new DependencyInstaller());
            return Container;
        }

        public static void DisposeWindsorContainer()
        {
            Container.Dispose();
        }
    }
}