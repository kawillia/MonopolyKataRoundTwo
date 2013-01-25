using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonopolyKata.Core;
using MonopolyKata.Core.Rules;

namespace MonopolyKata.Core.Board
{
    public class Property : Space
    {
        private IChargeRentRule chargeRentRule;
        private Banker banker;

        public Int32 Price { get; private set; }
        public Int32 BaseRent { get; private set; }
        public Boolean IsOwned { get { return this.Owner != null; } }
        public Player Owner { get; set; }

        public Property(Int32 price, Int32 baseRent, Banker banker)
            : base()
        {
            Price = price;
            BaseRent = baseRent;
            Owner = null;
            this.banker = banker;
        }

        public override void LandOn(Player player)
        {
            if (ShouldBuyProperty(player))
                BuyProperty(player);
            else if (ShouldPayRent(player))
                PayRent(player);
        }

        private Boolean ShouldBuyProperty(Player player)
        {
            return !IsOwned && player.ShouldBuyProperty();
        }

        private Boolean ShouldPayRent(Player player)
        {
            return IsOwned && player != Owner;
        }

        private void BuyProperty(Player player)
        {
            banker.Charge(player, Price);
            Owner = player;
        }

        private void PayRent(Player player)
        {
            var rentAmount = chargeRentRule.CalculateRent(this);
            banker.Transfer(player, Owner, rentAmount);
        }

        public void ChangeChargeRentRule(IChargeRentRule chargeRentRule)
        {
            this.chargeRentRule = chargeRentRule;
        }
    }
}
