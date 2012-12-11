using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Core;
using MonopolyKata.Core.Board;
using MonopolyKata.Tests.Fakes;

namespace MonopolyKata.Tests.Board
{
    [TestClass]
    public class GameBoardTests
    {
        private Player horse;
        private IEnumerable<FakeLocation> fakeLocations;
        private GameBoard board;

        public GameBoardTests()
        {
            horse = new Player("Horse");
            fakeLocations = new[] { new FakeLocation(0) };
            board = new GameBoard(fakeLocations);
        }

        [TestMethod]
        public void HavePlayerLandOnCurrentLocationCallsLandOn()
        {
            board.HavePlayerLandOnCurrentLocation(horse);

            Assert.IsTrue(fakeLocations.ElementAt(0).LandedOnCalled);
        }

        [TestMethod]
        public void TotalNumberOfLocationsEqualsTotalLocationsPassedIn()
        {
            Assert.AreEqual(1, board.TotalNumberOfLocations);
        }
    }
}
