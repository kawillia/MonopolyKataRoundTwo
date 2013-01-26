using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonopolyKata.Core;
using MonopolyKata.Core.Rules;

namespace MonopolyKata.Core.Spaces
{
    public class Property : Space
    {
        private Banker banker;
        protected PropertyManager propertyManager;

        public Int32 Price { get; private set; }
        public Int32 BaseRent { get; private set; }
        public String Group { get; private set; }
        public Boolean IsMortgaged { get; private set; }
        public Boolean IsOwned { get { return this.Owner != null; } }        
        public String Owner { get; set; }

        public Property(Int32 price, Int32 baseRent, String group, Banker banker, PropertyManager propertyManager)
            : base()
        {
            Price = price;
            BaseRent = baseRent;
            Group = group;
            this.banker = banker;
            this.propertyManager = propertyManager;
        }

        public override void LandOn(String player)
        {
            if (IsOwned == false && banker.GetBalance(player) >= Price)
            {
                Sell(player);
            }
            else if (IsOwned && player != Owner)
            {
                var rentAmount = CalculateRent();
                banker.Transfer(player, Owner, rentAmount);
            }
        }

        public void Sell(String buyer)
        {
            Owner = buyer;
            banker.Charge(buyer, Price);
        }

        public virtual Int32 CalculateRent()
        {
            if (propertyManager.GroupIsOwnedByOnePlayer(Group))
                return BaseRent * 2;

            return BaseRent;
        }

        public void Mortgage()
        {
            var mortgageAmount = Price * 9 / 10;
            banker.Pay(Owner, mortgageAmount);
            IsMortgaged = true;
        }

        public void Unmortgage()
        {
            banker.Charge(Owner, Price);
            IsMortgaged = false;
        }
    }
}
