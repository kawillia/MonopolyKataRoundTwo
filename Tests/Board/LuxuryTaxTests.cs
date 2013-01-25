using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Classic;
using MonopolyKata.Core;
using MonopolyKata.Core.Board;

namespace MonopolyKata.Tests.Board
{
    [TestClass]
    public class LuxuryTaxTests
    {
        private Player horse;
        private Banker banker;
        private LuxuryTax luxuryTax;

        public LuxuryTaxTests()
        {
            horse = new Player("Horse");
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
