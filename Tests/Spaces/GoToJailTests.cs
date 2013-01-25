using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Classic;
using MonopolyKata.Core.Spaces;
using MonopolyKata.Core.Rules;
using System;
using System.Linq;
using MonopolyKata.Core;

namespace MonopolyKata.Tests.Spaces
{
    [TestClass]
    public class GoToJailTests
    {
        private String horse;
        private Board board;
        private GoToJail goToJail;

        public GoToJailTests()
        {
            horse = "Horse";
            board = new Board(Enumerable.Empty<Space>(), Enumerable.Empty<IMovementRule>(), new[] { horse });
            goToJail = new GoToJail(ClassicBoardFactory.JustVisitingLocation, board);            
        }

        [TestMethod]
        public void LandingOnGoToJailMovesPlayerToJustVisiting()
        {
            goToJail.LandOn(horse);

            Assert.AreEqual(ClassicBoardFactory.JustVisitingLocation, board.GetPlayerLocation(horse));
        }
    }
}
