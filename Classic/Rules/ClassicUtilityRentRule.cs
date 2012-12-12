using System;
using System.Collections.Generic;
using System.Linq;
using MonopolyKata.Core;
using MonopolyKata.Core.Board;
using MonopolyKata.Core.Board.Properties;
using MonopolyKata.Core.Rules;

namespace MonopolyKata.Classic.Rules
{
    public class ClassicUtilityRentRule : IChargeRentRule
    {
        private Dice dice;

        public ClassicUtilityRentRule(Dice dice)
        {
            this.dice = dice;
        }

        public Int32 CalculateRent(Property propertyLandedOn, IEnumerable<Property> propertiesInGroup)
        {
            if (AllUtilitiesAreOwned(propertiesInGroup))
                return dice.CurrentValue * 10;

            return dice.CurrentValue * 4;
        }

        private static Boolean AllUtilitiesAreOwned(IEnumerable<Property> utilitiesInGroup)
        {
            return utilitiesInGroup.All(u => u.IsOwned);
        }
    }
}
