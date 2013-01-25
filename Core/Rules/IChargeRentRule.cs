using System;
using System.Collections.Generic;
using MonopolyKata.Core.Board;

namespace MonopolyKata.Core.Rules
{
    public interface IChargeRentRule
    {
        Int32 CalculateRent(Property propertyLandedOn);
    }
}
