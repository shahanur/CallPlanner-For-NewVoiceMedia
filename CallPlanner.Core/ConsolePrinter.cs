#region

using System;
using CallPlanner.Core.Interfaces;

#endregion

namespace CallPlanner.Core
{
    public class ConsolePrinter : IPrinter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}