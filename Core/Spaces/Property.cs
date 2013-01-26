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
        protected IEnumerable<Property> propertiesInGroup;

        public Int32 Price { get; private set; }
        public Int32 BaseRent { get; private set; }
        public Boolean IsMortgaged { get; private set; }
        public Boolean IsOwned { get { return this.Owner != null; } }        
        public String Owner { get; set; }

        public Property(Int32 price, Int32 baseRent, Banker banker, IEnumerable<Property> propertiesInGroup)
            : base()
        {
            Price = price;
            BaseRent = baseRent;
            Owner = null;
            this.banker = banker;
            this.propertiesInGroup = propertiesInGroup;
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
            var allPropertiesAreOwnedBySamePlayer = 
                propertiesInGroup.All(l => l.IsOwned) &&
                propertiesInGroup.Select(l => l.Owner).Distinct().Count() == 1;

            if (allPropertiesAreOwnedBySamePlayer)
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
