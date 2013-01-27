using System;

namespace MonopolyKata.Core.Spaces
{
    public class LuxuryTax : Space
    {
        private Int32 taxAmount;
        private Banker banker;

        public LuxuryTax(Int32 index, Int32 taxAmount, Banker banker)
            : base(index)
        {
            this.taxAmount = taxAmount;
            this.banker = banker;
        }

        public override void LandOn(String player)
        {
            banker.Charge(player, taxAmount);
        }
    }
}
