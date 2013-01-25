using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Classic;
using MonopolyKata.Core.Board;
using MonopolyKata.Core.Rules;
using System;
using System.Linq;

namespace MonopolyKata.Tests.Board
{
    [TestClass]
    public class GoToJailTests
    {
        private String horse;
        private GameBoard board;
        private GoToJail goToJail;

        public GoToJailTests()
        {
            horse = "Horse";
            board = new GameBoard(Enumerable.Empty<Space>(), Enumerable.Empty<IMovementRule>(), new[] { horse });
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
