using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Classic;
using MonopolyKata.Core;
using MonopolyKata.Core.Board;
using System;

namespace MonopolyKata.Tests.Board
{
    [TestClass]
    public class IncomeTaxTests
    {
        private String horse;
        private Banker banker;
        private IncomeTax incomeTax;

        public IncomeTaxTests()
        {
            horse = "Horse";
            banker = new Banker(new[] { horse });
            incomeTax = new IncomeTax(ClassicGameConstants.IncomeTaxPercentage, ClassicGameConstants.MaximumIncomeTaxPaymentAmount, banker);
        }

        [TestMethod]
        public void PlayerLandingOnIncomeTaxWhenPercentageOfNetWorthIsBelowMaximumPaymentDecreasesPlayerBalanceByPercentage()
        {
            banker.Pay(horse, 1800);
            incomeTax.LandOn(horse);

            Assert.AreEqual(1800 - (1800 / ClassicGameConstants.IncomeTaxPercentage), banker.GetBalance(horse));
        }

        [TestMethod]
        public void PlayerLandingOnIncomeTaxWhenPercentageOfNetWorthIsAboveMaximumPaymentDecreasesPlayerBalanceByMaximumPayment()
        {
            banker.Pay(horse, 2200);
            incomeTax.LandOn(horse);

            Assert.AreEqual(2200 - ClassicGameConstants.MaximumIncomeTaxPaymentAmount, banker.GetBalance(horse));
        }

        [TestMethod]
        public void PlayerLandingOnIncomeTaxWheNetWorthIsZeroDecreasesPlayerBalanceByZero()
        {
            incomeTax.LandOn(horse);

            Assert.AreEqual(0, banker.GetBalance(horse));
        }

        [TestMethod]
        public void PlayerLandingOnIncomeTaxWhenPercentageOfNetWorthEqualsMaximumPaymentDecreasesPlayerBonusByMaxiumumPayment()
        {
            banker.Pay(horse, 2000);
            incomeTax.LandOn(horse);

            Assert.AreEqual(2000 - ClassicGameConstants.MaximumIncomeTaxPaymentAmount, banker.GetBalance(horse));
        }
    }
}
