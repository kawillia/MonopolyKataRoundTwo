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

        public Utility(Int32 price, String group, Banker banker, PropertyManager propertyManager, Dice dice) 
            : base(price, 0, group, banker, propertyManager)
        {
            this.dice = dice;
        }

        public override Int32 CalculateRent()
        {
            if (propertyManager.GroupIsOwned(Group))
                return dice.CurrentValue * 10;

            return dice.CurrentValue * 4;
        }
    }
}
