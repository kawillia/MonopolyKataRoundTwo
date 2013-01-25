using System;
using System.Collections.Generic;
using System.Linq;
using MonopolyKata.Core.Board;
using MonopolyKata.Core.Rules;

namespace MonopolyKata.Classic.Rules
{
    public class ClassicPropertyRentRule : IChargeRentRule
    {
        private IEnumerable<Property> properties;

        public ClassicPropertyRentRule(IEnumerable<Property> properties)
        {
            this.properties = properties;
        }

        public Int32 CalculateRent(Property propertyLandedOn)
        {
            if (AllPropertiesAreOwnedBySamePlayer())
                return propertyLandedOn.BaseRent * 2;

            return propertyLandedOn.BaseRent;
        }

        private Boolean AllPropertiesAreOwnedBySamePlayer()
        {
            return properties.All(l => l.IsOwned) &&
                   properties.Select(l => l.Owner).Distinct().Count() == 1;
        }
    }
}
