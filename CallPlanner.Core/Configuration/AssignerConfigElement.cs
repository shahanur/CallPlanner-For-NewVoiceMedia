#region

using System.Configuration;

#endregion

namespace CallPlanner.Core.Configuration
{
    public class AssignerConfigElement : ConfigurationElement
    {
        public AssignerConfigElement(string elementName, string active, string key)
        {
            Name = elementName;
            Active = active;
            Key = key;
        }

        public AssignerConfigElement(string elementName)
        {
            Name = elementName;
        }

        public AssignerConfigElement()
        {
        }

        [ConfigurationProperty("name", DefaultValue = "", IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return (string) this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("active", DefaultValue = "true", IsRequired = true)]
        public string Active
        {
            get { return (string) this["active"]; }
            set { this["active"] = value; }
        }

        [ConfigurationProperty("key", DefaultValue = "even", IsRequired = true)]
        public string Key
        {
            get { return (string) this["key"]; }
            set { this["key"] = value; }
        }
    }
}