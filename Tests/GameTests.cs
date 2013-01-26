using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Core;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata.Tests
{
    [TestClass]
    public class GameTests
    {
        private IEnumerable<String> players;
        private Mock<ITurn> mockTurn;
        private IShuffler<String> shuffler;

        public GameTests()
        {
            players = Enumerable.Empty<String>();
            mockTurn = new Mock<ITurn>();
            shuffler = new GuidShuffler<String>();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreatingGameWithDuplicatePlayerThrowsException()
        {
            players = new[] { "Horse", "Horse" };
            var game = new Game(players, mockTurn.Object, shuffler);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreatingGameWithLessThanMinimumNumberOfPlayersThrowsException()
        {
            var game = new Game(Enumerable.Empty<String>(), mockTurn.Object, shuffler);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreatingGameWithGreaterThanMaximumNumberOfPlayersThrowsException()
        {
            players = new[] 
            {
                "Horse",
                "Car",
                "Iron",
                "Ship",
                "Thimble",
                "Wheelbarrow",
                "Cannon",
                "Hat",
                "Hokie"
            };

            var game = new Game(players, mockTurn.Object, shuffler);
        }

        [TestMethod]
        public void StartingGameWithValidNumberOfPlayersDoesNotThrowException()
        {
            players = new[] 
            {
                "Horse",
                "Car",
                "Iron",
                "Ship",
                "Thimble",
                "Wheelbarrow",
                "Cannon",
                "Hat",
            };

            var game = new Game(players, mockTurn.Object, shuffler);
        }
    }
}
