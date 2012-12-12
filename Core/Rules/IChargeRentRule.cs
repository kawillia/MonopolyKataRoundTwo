using System;
using System.Collections.Generic;
using MonopolyKata.Core.Board.Properties;

namespace MonopolyKata.Core.Rules
{
    public interface IChargeRentRule
    {
        Int32 CalculateRent(Property propertyLandedOn, IEnumerable<Property> locationsInGroup);
    }
}
