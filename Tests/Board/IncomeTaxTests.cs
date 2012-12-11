using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly.Board.Locations;
using Monopoly;
using Monopoly.Classic;
using System;

namespace MonopolyTests.Board
{
    [TestClass]
    public class IncomeTaxTests
    {
        private Player horse;
        private IncomeTax incomeTax;

        public IncomeTaxTests()
        {
            incomeTax = new IncomeTax(ClassicBoardFactory.IncomeTaxLocation, ClassicGameConstants.IncomeTaxPercentage, ClassicGameConstants.MaximumIncomeTaxPaymentAmount);
        }

        [TestMethod]
        public void PlayerLandingOnIncomeTaxWhenPercentageOfNetWorthIsBelowMaximumPaymentDecreasesPlayerBalanceByPercentage()
        {
            horse = new Player("Horse", 1800);
            incomeTax.LandedOnByPlayer(horse);

            Assert.AreEqual(1800 - (1800 / ClassicGameConstants.IncomeTaxPercentage), horse.Balance);
        }

        [TestMethod]
        public void PlayerLandingOnIncomeTaxWhenPercentageOfNetWorthIsAboveMaximumPaymentDecreasesPlayerBalanceByMaximumPayment()
        {
            horse = new Player("Horse", 2200);
            incomeTax.LandedOnByPlayer(horse);

            Assert.AreEqual(2200 - ClassicGameConstants.MaximumIncomeTaxPaymentAmount, horse.Balance);
        }

        [TestMethod]
        public void PlayerLandingOnIncomeTaxWheNetWorthIsZeroDecreasesPlayerBalanceByZero()
        {
            horse = new Player("Horse", 0);
            incomeTax.LandedOnByPlayer(horse);

            Assert.AreEqual(0, horse.Balance);
        }

        [TestMethod]
        public void PlayerLandingOnIncomeTaxWhenPercentageOfNetWorthEqualsMaximumPaymentDecreasesPlayerBonusByMaxiumumPayment()
        {
            horse = new Player("Horse", 2000);
            incomeTax.LandedOnByPlayer(horse);

            Assert.AreEqual(2000 - ClassicGameConstants.MaximumIncomeTaxPaymentAmount, horse.Balance);
        }

        [TestMethod]
        public void PlayerPassingIncomeTaxDoesNotAffectPlayerBalance()
        {
            horse = new Player("Horse", 500);
            incomeTax.PassedByPlayer(horse);

            Assert.AreEqual(500, horse.Balance);
        }
    }
}
