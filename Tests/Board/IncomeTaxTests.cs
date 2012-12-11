using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Classic;
using MonopolyKata.Core.Board.Locations;
using MonopolyKata.Core;

namespace MonopolyKata.Tests.Board
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
            incomeTax.LandOn(horse);

            Assert.AreEqual(1800 - (1800 / ClassicGameConstants.IncomeTaxPercentage), horse.Balance);
        }

        [TestMethod]
        public void PlayerLandingOnIncomeTaxWhenPercentageOfNetWorthIsAboveMaximumPaymentDecreasesPlayerBalanceByMaximumPayment()
        {
            horse = new Player("Horse", 2200);
            incomeTax.LandOn(horse);

            Assert.AreEqual(2200 - ClassicGameConstants.MaximumIncomeTaxPaymentAmount, horse.Balance);
        }

        [TestMethod]
        public void PlayerLandingOnIncomeTaxWheNetWorthIsZeroDecreasesPlayerBalanceByZero()
        {
            horse = new Player("Horse", 0);
            incomeTax.LandOn(horse);

            Assert.AreEqual(0, horse.Balance);
        }

        [TestMethod]
        public void PlayerLandingOnIncomeTaxWhenPercentageOfNetWorthEqualsMaximumPaymentDecreasesPlayerBonusByMaxiumumPayment()
        {
            horse = new Player("Horse", 2000);
            incomeTax.LandOn(horse);

            Assert.AreEqual(2000 - ClassicGameConstants.MaximumIncomeTaxPaymentAmount, horse.Balance);
        }
    }
}
