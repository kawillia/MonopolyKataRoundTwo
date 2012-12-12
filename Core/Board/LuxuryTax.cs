using System;

namespace MonopolyKata.Core.Board
{
    public class LuxuryTax : Location
    {
        private Int32 taxAmount;

        public LuxuryTax(Int32 locationIndex, Int32 taxAmount)
            : base(locationIndex)
        {
            this.taxAmount = taxAmount;
        }

        public override void LandOn(Player player)
        {
            player.Pay(taxAmount);
        }
    }
}
