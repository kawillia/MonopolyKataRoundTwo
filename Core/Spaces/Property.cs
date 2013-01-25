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
        private IChargeRentRule chargeRentRule;
        private Banker banker;

        public Int32 Price { get; private set; }
        public Int32 BaseRent { get; private set; }
        public Boolean IsOwned { get { return this.Owner != null; } }
        public String Owner { get; set; }

        public Property(Int32 price, Int32 baseRent, Banker banker)
            : base()
        {
            Price = price;
            BaseRent = baseRent;
            Owner = null;
            this.banker = banker;
        }

        public override void LandOn(String player)
        {
            if (IsOwned == false)
            {
                Owner = player;
                banker.Charge(player, Price);                
            }
            else if (player != Owner)
            {
                var rentAmount = chargeRentRule.Calculate(this);
                banker.Transfer(player, Owner, rentAmount);
            }
        }

        public void ChangeChargeRentRule(IChargeRentRule chargeRentRule)
        {
            this.chargeRentRule = chargeRentRule;
        }
    }
}
