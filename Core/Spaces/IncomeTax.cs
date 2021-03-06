﻿using System;

namespace MonopolyKata.Core.Spaces
{
    public class IncomeTax : Space
    {
        private Int32 taxPercentage;
        private Int32 maximumTaxPayment;
        private Banker banker;

        public IncomeTax(Int32 index, Int32 taxPercentage, Int32 maximumTaxPayment, Banker banker)
            : base(index)
        {
            this.taxPercentage = taxPercentage;
            this.maximumTaxPayment = maximumTaxPayment;
            this.banker = banker;
        }

        public override void LandOn(String player)
        {
            var playerBalance = banker.GetBalance(player);
            var incomeTaxAmount = (Int32)Math.Min(playerBalance / taxPercentage, maximumTaxPayment);

            banker.Charge(player, incomeTaxAmount);
        }
    }
}
