using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly;

namespace Monopoly.Board.Locations
{
    public class IncomeTax : Location
    {
        public Int32 TaxPercentage { get; private set; }
        public Int32 MaximumTaxPayment { get; private set; }

        public IncomeTax(Int32 locationIndex, Int32 taxPercentage, Int32 maximumTaxPayment)
            : base(locationIndex)
        {
            TaxPercentage = taxPercentage;
            MaximumTaxPayment = maximumTaxPayment;
        }

        public override void LandedOnByPlayer(Player player)
        {
            if (player.NetWorth > 0)
                player.Pay(Math.Min(player.NetWorth / TaxPercentage, MaximumTaxPayment));
        }
    }
}
