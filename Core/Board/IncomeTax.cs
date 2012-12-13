using System;

namespace MonopolyKata.Core.Board
{
    public class IncomeTax : Space
    {
        private Int32 taxPercentage;
        private Int32 maximumTaxPayment;

        public IncomeTax(Int32 locationIndex, Int32 taxPercentage, Int32 maximumTaxPayment)
            : base(locationIndex)
        {
            this.taxPercentage = taxPercentage;
            this.maximumTaxPayment = maximumTaxPayment;
        }

        public override void LandOn(Player player)
        {
            if (player.NetWorth > 0)
                player.Pay(Math.Min(player.NetWorth / taxPercentage, maximumTaxPayment));
        }
    }
}
