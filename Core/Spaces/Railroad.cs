using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata.Core.Spaces
{
    public class Railroad : Property
    {
        public Railroad(Int32 price, Int32 baseRent, Banker banker, IEnumerable<Property> railroadsInGroup)
            : base(price, baseRent, banker, railroadsInGroup)
        { }

        public override Int32 CalculateRent()
        {
            var numberOwned = propertiesInGroup.Count(l => l.IsOwned && l.Owner == Owner);
            return (Int32)Math.Pow(2, numberOwned - 1) * BaseRent;
        }
    }
}
