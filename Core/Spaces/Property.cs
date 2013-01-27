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
        protected Int32 price;
        protected Int32 baseRent;
        protected String group;
        protected Banker banker;
        protected String owner;
        protected Boolean isMortgaged;
        protected PropertyManager propertyManager;

        public Int32 Price { get { return price; } }
        public Int32 BaseRent { get { return baseRent; } }
        public String Group { get { return group; } }
        public Boolean IsMortgaged { get { return isMortgaged; } }
        public Boolean IsOwned { get { return this.Owner != null; } }
        public String Owner { get { return owner; } }

        public Property(Int32 index, Int32 price, Int32 baseRent, String group, Banker banker, PropertyManager propertyManager)
            : base(index)
        {
            this.price = price;
            this.baseRent = baseRent;
            this.group = group;
            this.banker = banker;
            this.propertyManager = propertyManager;
        }

        public override void LandOn(String player)
        {
            if (IsOwned == false && banker.GetBalance(player) >= price)
            {
                Sell(player);
            }
            else if (IsOwned && player != owner)
            {
                banker.Transfer(player, owner, CalculateRent());
            }
        }

        public void Sell(String buyer)
        {
            banker.Charge(buyer, price);
            owner = buyer;            
        }

        public virtual Int32 CalculateRent()
        {
            if (propertyManager.GroupIsOwnedByOnePlayer(group))
                return baseRent * 2;

            return baseRent;
        }

        public void Mortgage()
        {
            banker.Pay(owner, price * 9 / 10);
            isMortgaged = true;
        }

        public void Unmortgage()
        {
            banker.Charge(owner, price);
            isMortgaged = false;
        }
    }
}
