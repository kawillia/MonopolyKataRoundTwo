using System;
using System.Collections.Generic;
using System.Linq;
using MonopolyKata.Core.Board.Properties;
using MonopolyKata.Core.Rules;

namespace MonopolyKata.Classic.Rules
{
    public class ClassicRailroadRentRule : IChargeRentRule
    {
        public Int32 CalculateRent(Property railroadLandedOn, IEnumerable<Property> railroadsInGroup)
        {
            var numberOwned = GetNumberOfRailroadsOwned(railroadLandedOn, railroadsInGroup);
            return (Int32)Math.Pow(2, numberOwned - 1) * railroadLandedOn.BaseRent;
        }

        private static Int32 GetNumberOfRailroadsOwned(Property railroadLandedOn, IEnumerable<Property> railroadsInGroup)
        {
            return railroadsInGroup.Count(l => l.IsOwned && l.Owner == railroadLandedOn.Owner);
        }
    }
}
