#region

using System.Configuration;

#endregion

namespace CallPlanner.Core.Configuration
{
    public class AssignerCollection : ConfigurationElementCollection
    {
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.AddRemoveClearMap; }
        }

        public AssignerConfigElement this[int index]
        {
            get { return (AssignerConfigElement) BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public new AssignerConfigElement this[string Name]
        {
            get { return (AssignerConfigElement) BaseGet(Name); }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new AssignerConfigElement();
        }

        protected override ConfigurationElement CreateNewElement(string elementName)
        {
            return new AssignerConfigElement(elementName);
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((AssignerConfigElement) element).Name;
        }

        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }
    }
}