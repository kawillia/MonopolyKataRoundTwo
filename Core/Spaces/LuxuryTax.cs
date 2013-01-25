using System;

namespace MonopolyKata.Core.Spaces
{
    public class LuxuryTax : Space
    {
        private Int32 taxAmount;
        private Banker banker;

        public LuxuryTax(Int32 taxAmount, Banker banker)
            : base()
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
