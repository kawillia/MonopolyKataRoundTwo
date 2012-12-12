using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Classic;
using MonopolyKata.Core;
using MonopolyKata.Core.Board;

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
            goToJail.LandOn(horse);

            Assert.AreEqual(ClassicBoardFactory.JustVisitingLocation, horse.CurrentLocation);
        }
    }
}
