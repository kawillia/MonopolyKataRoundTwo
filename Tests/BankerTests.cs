using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Core;

namespace MonopolyKata.Tests
{
    [TestClass]
    public class BankerTests
    {
        private String hat;
        private String horse;
        private Banker banker;

        public BankerTests()
        {
            hat = "Hat";
            horse = "Horse";
            banker = new Banker(new[] { hat, horse });
        }

        [TestMethod]
        public void PayIncreasesAPlayersBalanceByAmount()
        {
            var balanceBefore = banker.GetBalance(hat);
            banker.Pay(hat, 200);

            Assert.AreEqual(balanceBefore + 200, banker.GetBalance(hat));
        }

        [TestMethod]
        public void ChargeDecreasesAPlayersBalanceByAmount()
        {
            var balanceBefore = banker.GetBalance(hat);
            banker.Charge(hat, 200);

            Assert.AreEqual(balanceBefore - 200, banker.GetBalance(hat));
        }

        [TestMethod]
        public void TransferEffectsBothPlayersInTransaction()
        {
            var horseBalanceBefore = banker.GetBalance(horse);
            var hatBalanceBefore = banker.GetBalance(hat);
            banker.Transfer(horse, hat, 500);

            Assert.AreEqual(horseBalanceBefore - 500, banker.GetBalance(horse));
            Assert.AreEqual(hatBalanceBefore + 500, banker.GetBalance(hat));
        }
    }
}
