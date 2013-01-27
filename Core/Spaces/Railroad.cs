using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata.Core.Spaces
{
    public class Railroad : Property
    {
        public Railroad(Int32 index, Int32 price, Int32 baseRent, String group, Banker banker, PropertyManager propertyManager)
            : base(index, price, baseRent, group, banker, propertyManager)
        { }

        public override Int32 CalculateRent()
        {
            var numberOwned = propertyManager.GetNumberOwnedByPlayer(group, owner);
            return (Int32)Math.Pow(2, numberOwned - 1) * BaseRent;
        }
    }
}
