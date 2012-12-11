using System;
using MonopolyKata.Core;

namespace MonopolyKata.Core.Board.Locations
{
    public class LuxuryTax : Location
    {
        public Int32 TaxAmount { get; private set; }

        public LuxuryTax(Int32 locationIndex, Int32 taxAmount)
            : base(locationIndex)
        {
            TaxAmount = taxAmount;
        }

        public override void LandedOn(Player player)
        {
            player.Pay(TaxAmount);
        }
    }
}
