#region

using System;

#endregion

namespace CallPlanner.Core.Exceptions
{
    public class InvalidInteractionException : Exception
    {
        public override string Message
        {
            get { return "Invalid interaction."; }
        }
    }
}