using System;
using System.Collections.Generic;
using System.Linq;
using MonopolyKata.Core.Strategies;
using MonopolyKata.Core.Board;
using MonopolyKata.Core.Rules;

namespace MonopolyKata.Core.Board.Properties
{
    public class PropertyGroup
    {
        private IEnumerable<Property> properties;

        public IEnumerable<Property> Properties { get { return properties.ToList(); } }

        public PropertyGroup(params Property[] properties)
        {
            this.properties = properties;

            foreach (var property in properties)
                property.ChangePropertyGroup(this);
        }
    }
}
