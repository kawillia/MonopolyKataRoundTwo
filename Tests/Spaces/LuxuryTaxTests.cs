using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Classic;
using MonopolyKata.Core;
using MonopolyKata.Core.Spaces;
using System;

namespace MonopolyKata.Tests.Spaces
{
    [TestClass]
    public class LuxuryTaxTests
    {
        private String horse;
        private Banker banker;
        private LuxuryTax luxuryTax;

        public LuxuryTaxTests()
        {
            horse = "Horse";
            banker = new Banker(new[] { horse });
            luxuryTax = new LuxuryTax(ClassicGameConstants.LuxuryTaxPaymentAmount, banker);
        }

        [TestMethod]
        public void PlayerLandingOnLuxuryTaxDecreasesPlayerBalanceByLuxuryTaxAmount()
        {
            var balanceBefore = banker.GetBalance(horse);
            luxuryTax.LandOn(horse);

            Assert.AreEqual(balanceBefore - ClassicGameConstants.LuxuryTaxPaymentAmount, banker.GetBalance(horse));
        }
    }
}
