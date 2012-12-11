using System;

namespace Monopoly.Board.Locations
{
    public class LuxuryTax : Location
    {
        public Int32 TaxAmount { get; private set; }

        public LuxuryTax(Int32 locationIndex, Int32 taxAmount)
            : base(locationIndex)
        {
            TaxAmount = taxAmount;
        }

        public override void LandedOnByPlayer(Player player)
        {
            player.Pay(TaxAmount);
        }
    }
}
