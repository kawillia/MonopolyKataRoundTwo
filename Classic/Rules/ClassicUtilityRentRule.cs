using System;
using System.Collections.Generic;
using System.Linq;
using MonopolyKata.Core;
using MonopolyKata.Core.Board;
using MonopolyKata.Core.Rules;

namespace MonopolyKata.Classic.Rules
{
    public class ClassicUtilityRentRule : IChargeRentRule
    {
        private Dice dice;
        private IEnumerable<Property> utilities;

        public ClassicUtilityRentRule(Dice dice, IEnumerable<Property> utilities)
        {
            this.dice = dice;
            this.utilities = utilities;
        }

        public Int32 CalculateRent(Property propertyLandedOn)
        {
            if (AllUtilitiesAreOwned())
                return dice.CurrentValue * 10;

            return dice.CurrentValue * 4;
        }

        private Boolean AllUtilitiesAreOwned()
        {
            return utilities.All(u => u.IsOwned);
        }
    }
}
