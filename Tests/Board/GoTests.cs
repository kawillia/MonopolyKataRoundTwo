using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Classic;
using MonopolyKata.Core;
using MonopolyKata.Core.Board;
using System;

namespace MonopolyKata.Tests.Board
{
    [TestClass]
    public class GoTests
    {
        private String horse;
        private Banker banker;
        private Go go;

        public GoTests()
        {
            horse = "Horse";
            banker = new Banker(new[] { horse });
            go = new Go(ClassicGameConstants.GoSalaryBonus, banker);
        }

        [TestMethod]
        public void PlayerLandingOnGoIncreasesPlayerBalanceByGoSalaryBonus()
        {
            var balanceBefore = banker.GetBalance(horse);
            go.LandOn(horse);

            Assert.AreEqual(balanceBefore + ClassicGameConstants.GoSalaryBonus, banker.GetBalance(horse));
        }
    }
}
