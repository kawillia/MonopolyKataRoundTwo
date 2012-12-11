using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.Board.Locations;
using Monopoly.Classic;

namespace MonopolyKata.Tests.Board
{
    [TestClass]
    public class GoToJailTests
    {
        private GoToJail goToJail;
        private Player horse;

        public GoToJailTests()
        {
            goToJail = new GoToJail(ClassicBoardFactory.GoToJailLocation, ClassicBoardFactory.JustVisitingLocation);
            horse = new Player("Horse");
        }

        [TestMethod]
        public void LandingOnGoToJailMovesPlayerToJustVisiting()
        {
            goToJail.LandedOnByPlayer(horse);

            Assert.AreEqual(ClassicBoardFactory.JustVisitingLocation, horse.CurrentLocation);
        }

        [TestMethod]
        public void PassingGoToJailDoesNotAffectPlayerLocation()
        {
            goToJail.PassedByPlayer(horse);

            Assert.AreEqual(0, horse.CurrentLocation);
        }
    }
}
