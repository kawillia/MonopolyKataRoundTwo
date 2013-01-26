using MonopolyKata.Core.Spaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata.Core
{
    public class PropertyManager
    {
        private IEnumerable<Property> properties;

        public PropertyManager()
        {
            properties = Enumerable.Empty<Property>();
        }

        public IEnumerable<Property> GetMortgagedProperties(String player)
        {
            return properties.Where(p => p.Owner == player && p.IsMortgaged);
        }

        public IEnumerable<Property> GetUnmortgagedProperties(String player)
        {
            return properties.Where(p => p.Owner == player);
        }

        public Boolean GroupIsOwnedByOnePlayer(String group)
        {
            var propertiesInGroup = GetPropertiesInGroup(group);
            var allOwned = propertiesInGroup.All(l => l.IsOwned);
            var oneOwner = propertiesInGroup.Select(l => l.Owner).Distinct().Count() == 1;

            return allOwned && oneOwner;
        }

        public Int32 GetNumberOwnedByPlayer(String group, String owner)
        {
            var propertiesInGroup = GetPropertiesInGroup(group);
            return propertiesInGroup.Count(l => l.IsOwned && l.Owner == owner);
        }

        public Boolean GroupIsOwned(String group)
        {
            var propertiesInGroup = GetPropertiesInGroup(group);
            return propertiesInGroup.All(u => u.IsOwned);
        }

        private IEnumerable<Property> GetPropertiesInGroup(String group)
        {
            return properties.Where(p => p.Group == group);
        }

        public void ManageProperties(IEnumerable<Property> properties)
        {
            this.properties = properties;
        }
    }
}
