#region

using System.Configuration;

#endregion

namespace CallPlanner.Core.Configuration
{
    public class AssignerSection : ConfigurationSection
    {
        [ConfigurationProperty("name", DefaultValue = "AssignerSet", IsRequired = true, IsKey = false)]
        public string Name
        {
            get { return (string) this["name"]; }
            set { this["name"] = value; }
        }


        [ConfigurationProperty("assigners", IsDefaultCollection = false)]
        public AssignerCollection Assigners
        {
            get
            {
                var ruleCollection = (AssignerCollection) base["assigners"];
                return ruleCollection;
            }
        }

        protected override string SerializeSection(ConfigurationElement parentElement, string name,
            ConfigurationSaveMode saveMode)
        {
            string s = base.SerializeSection(parentElement, name, saveMode);
            return s;
        }
    }
}