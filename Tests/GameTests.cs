using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Classic;
using MonopolyKata.Core;
using MonopolyKata.Tests.Fakes;

namespace MonopolyKata.Tests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreatingGameWithDuplicatePlayerThrowsException()
        {
            var players = new[] { "Horse", "Horse" };
            var game = new Game(players, new FakeTurnTaker(), new GuidShuffler<String>());
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreatingGameWithLessThanMinimumNumberOfPlayersThrowsException()
        {
            var game = new Game(Enumerable.Empty<String>(), new FakeTurnTaker(), new GuidShuffler<String>());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreatingGameWithGreaterThanMaximumNumberOfPlayersThrowsException()
        {
            var players = new[] 
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

            var game = new Game(players, new FakeTurnTaker(), new GuidShuffler<String>());
        }

        [TestMethod]
        public void StartingGameWithValidNumberOfPlayersDoesNotThrowException()
        {
            var players = new[] 
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

            var game = new Game(players, new FakeTurnTaker(), new GuidShuffler<String>());
        }
    }
}
