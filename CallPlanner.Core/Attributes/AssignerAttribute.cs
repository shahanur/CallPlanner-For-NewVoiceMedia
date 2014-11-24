#region

using System;

#endregion

namespace CallPlanner.Core.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class AssignerAttribute : Attribute
    {
        private readonly string _assignerName;

        public AssignerAttribute(string assignerName)
        {
            _assignerName = assignerName;
        }

        public string AssignerName
        {
            get { return _assignerName; }
        }
    }
}