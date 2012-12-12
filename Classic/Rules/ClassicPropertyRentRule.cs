using System;
using System.Collections.Generic;
using System.Linq;
using MonopolyKata.Core.Board.Properties;
using MonopolyKata.Core.Rules;

namespace MonopolyKata.Classic.Rules
{
    public class ClassicPropertyRentRule : IChargeRentRule
    {
        public Int32 CalculateRent(Property propertyLandedOn, IEnumerable<Property> propertiesInGroup)
        {
            if (AllPropertiesAreOwnedBySamePlayer(propertiesInGroup))
                return propertyLandedOn.BaseRent * 2;

            return propertyLandedOn.BaseRent;
        }

        private static Boolean AllPropertiesAreOwnedBySamePlayer(IEnumerable<Property> propertiesInGroup)
        {
            return propertiesInGroup.All(l => l.IsOwned) &&
                   propertiesInGroup.Select(l => l.Owner).Distinct().Count() == 1;
        }
    }
}
