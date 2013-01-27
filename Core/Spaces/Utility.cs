using System;

namespace MonopolyKata.Core.Spaces
{
    public class Utility : Property
    {
        private Dice dice;

        public Utility(Int32 index, Int32 price, String group, Banker banker, PropertyManager propertyManager, Dice dice) 
            : base(index, price, 0, group, banker, propertyManager)
        {
            this.dice = dice;
        }

        public override Int32 CalculateRent()
        {
            if (propertyManager.GroupIsOwned(group))
                return dice.CurrentValue * 10;

            return dice.CurrentValue * 4;
        }
    }
}
