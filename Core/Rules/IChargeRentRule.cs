using System;
using System.Collections.Generic;
using MonopolyKata.Core.Spaces;

namespace MonopolyKata.Core.Rules
{
    public interface IChargeRentRule
    {
        Int32 Calculate(Property propertyLandedOn);
    }
}
