using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.Board.Locations;
using Monopoly.Classic;

namespace MonopolyTests.Board.Locations
{
    [TestClass]
    public class GoTests
    {
        private Player horse;
        private Go go;

        public GoTests()
        {
            horse = new Player("Horse");
            go = new Go(ClassicBoardFactory.GoLocation, ClassicGameConstants.GoSalaryBonus);
        }

        [TestMethod]
        public void PlayerLandingOnGoIncreasesPlayerBalanceByGoSalaryBonus()
        {
            var balanceBefore = horse.Balance;
            go.LandedOnByPlayer(horse);

            Assert.AreEqual(balanceBefore + ClassicGameConstants.GoSalaryBonus, horse.Balance);
        }

        [TestMethod]
        public void PlayerPassingGoIncreasesPlayerBalanceByGoSalaryBonus()
        {
            var balanceBefore = horse.Balance;
            go.PassedByPlayer(horse);

            Assert.AreEqual(balanceBefore + ClassicGameConstants.GoSalaryBonus, horse.Balance);
        }

        [TestMethod]
        public void PlayerPassingGoTwiceIncreasesPlayerBalanceByTwoTimesTheGoSalaryBonus()
        {
            var balanceBefore = horse.Balance;
            go.PassedByPlayer(horse);
            go.PassedByPlayer(horse);

            Assert.AreEqual(balanceBefore + (2 * ClassicGameConstants.GoSalaryBonus), horse.Balance);
        }
    }
}
