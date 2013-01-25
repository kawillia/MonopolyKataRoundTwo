using System;
using System.Collections.Generic;
using System.Linq;
using MonopolyKata.Core.Spaces;
using MonopolyKata.Core.Rules;

namespace MonopolyKata.Classic.Rules
{
    public class ClassicRailroadRentRule : IChargeRentRule
    {
        private IEnumerable<Property> railroads;

        public ClassicRailroadRentRule(IEnumerable<Property> railroads)
        {
            this.railroads = railroads;
        }

        public Int32 Calculate(Property railroadLandedOn)
        {
            var numberOwned = GetNumberOfRailroadsOwned(railroadLandedOn);
            return (Int32)Math.Pow(2, numberOwned - 1) * railroadLandedOn.BaseRent;
        }

        private Int32 GetNumberOfRailroadsOwned(Property railroadLandedOn)
        {
            return railroads.Count(l => l.IsOwned && l.Owner == railroadLandedOn.Owner);
        }
    }
}
