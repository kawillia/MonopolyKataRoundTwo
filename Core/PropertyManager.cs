using MonopolyKata.Core.Spaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata.Core
{
    public class PropertyManager
    {
        private IEnumerable<Property> properties;

        public PropertyManager(IEnumerable<Property> properties)
        {
            this.properties = properties;
        }

        public IEnumerable<Property> GetMortgagedProperties(String player)
        {
            return properties.Where(p => p.Owner == player && p.IsMortgaged);
        }

        public IEnumerable<Property> GetUnmortgagedProperties(String player)
        {
            return properties.Where(p => p.Owner == player);
        }
    }
}
