using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Classic;
using MonopolyKata.Core.Board.Locations;
using MonopolyKata.Core;

namespace MonopolyTests.Board
{
    [TestClass]
    public class LuxuryTaxTests
    {
        private Player horse;
        private LuxuryTax luxuryTax;

        public LuxuryTaxTests()
        {
            luxuryTax = new LuxuryTax(ClassicBoardFactory.LuxuryTaxLocation, ClassicGameConstants.LuxuryTaxPaymentAmount);
        }

        [TestMethod]
        public void PlayerLandingOnLuxuryTaxDecreasesPlayerBalanceByLuxuryTaxAmount()
        {
            horse = new Player("Horse", 1500);
            luxuryTax.LandedOn(horse);

            Assert.AreEqual(1500 - ClassicGameConstants.LuxuryTaxPaymentAmount, horse.Balance);
        }
    }
}
