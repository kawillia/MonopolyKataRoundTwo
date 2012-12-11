using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Classic;
using MonopolyKata.Core.Board.Locations;
using MonopolyKata.Core;

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
            goToJail.LandedOn(horse);

            Assert.AreEqual(ClassicBoardFactory.JustVisitingLocation, horse.CurrentLocation);
        }
    }
}
