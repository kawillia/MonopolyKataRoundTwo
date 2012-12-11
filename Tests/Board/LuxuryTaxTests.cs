using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.Board.Locations;
using Monopoly.Classic;

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
            luxuryTax.LandedOnByPlayer(horse);

            Assert.AreEqual(1500 - ClassicGameConstants.LuxuryTaxPaymentAmount, horse.Balance);
        }

        [TestMethod]
        public void PlayerPassingLuxuryTaxDoesNotAffectPlayerBalance()
        {
            horse = new Player("Horse", 1500);
            luxuryTax.PassedByPlayer(horse);

            Assert.AreEqual(1500, horse.Balance);
        }
    }
}
