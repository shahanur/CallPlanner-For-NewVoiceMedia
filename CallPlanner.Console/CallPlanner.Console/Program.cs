#region

using System.Collections.Generic;
using CallPlanner.Core;
using CallPlanner.Core.Entities;
using CallPlanner.Core.Interfaces;

#endregion

namespace CallPlanner.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            PerformInteraction();
            System.Console.ReadKey();
        }

        private static IEnumerable<Interaction> GetInteractions()
        {
            var interactions = new List<Interaction>
            {
                new Interaction {InteractionType = CpEnumerators.InteractionType.Email, Input = "bob@test.com"},
                new Interaction {InteractionType = CpEnumerators.InteractionType.Call, Input = "5678"},
                new Interaction {InteractionType = CpEnumerators.InteractionType.Call, Input = "246"},
                new Interaction {InteractionType = CpEnumerators.InteractionType.Email, Input = "charlie@test.com"},
                new Interaction {InteractionType = CpEnumerators.InteractionType.Call, Input = "1237"},
                new Interaction {InteractionType = CpEnumerators.InteractionType.Call, Input = "6734"},
                new Interaction {InteractionType = CpEnumerators.InteractionType.Email, Input = "alice@test.com"},
            };


            return interactions;
        }

        private static void PerformInteraction()
        {
            var windsorContainer = AppStart.RegisterDependencies();
            var printer = windsorContainer.Resolve<IPrinter>();
            var originatorDataProvider = windsorContainer.Resolve<IOriginatorDataProvider>();
            var assignerManager = windsorContainer.Resolve<IAssignerManager>();
            var callplanner = new Core.CallPlanner(assignerManager, printer, originatorDataProvider);
            foreach (var interaction in GetInteractions())
            {
                callplanner.Plan(interaction);
                System.Console.WriteLine();
            }
            AppStart.DisposeWindsorContainer();
        }

    }
}