using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Core.Spaces
{
    public class Utility : Property
    {
        private Dice dice;

        public Utility(Int32 price, Banker banker, IEnumerable<Property> propertiesInGroup, Dice dice) : base(price, 0, banker, propertiesInGroup)
        {
            this.dice = dice;
        }

        public override Int32 CalculateRent()
        {
            if (propertiesInGroup.All(u => u.IsOwned))
                return dice.CurrentValue * 10;

            return dice.CurrentValue * 4;
        }
    }
}
