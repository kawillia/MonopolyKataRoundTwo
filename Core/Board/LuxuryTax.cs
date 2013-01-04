using System;

namespace MonopolyKata.Core.Board
{
    public class LuxuryTax : Space
    {
        private Int32 taxAmount;

        public LuxuryTax(Int32 taxAmount)
            : base()
        {
            this.taxAmount = taxAmount;
        }

        public override void LandOn(Player player)
        {
            player.Pay(taxAmount);
        }
    }
}
