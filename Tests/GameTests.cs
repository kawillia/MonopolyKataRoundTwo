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
            var players = new[] { new Player("Horse"), new Player("Horse") };
            var game = new Game(players, new FakeTurnTaker(), new GuidShuffler<Player>());
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreatingGameWithLessThanMinimumNumberOfPlayersThrowsException()
        {
            var game = new Game(Enumerable.Empty<Player>(), new FakeTurnTaker(), new GuidShuffler<Player>());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreatingGameWithGreaterThanMaximumNumberOfPlayersThrowsException()
        {
            var players = new[] 
            {
                new Player("Horse"),
                new Player("Car"),
                new Player("Iron"),
                new Player("Ship"),
                new Player("Thimble"),
                new Player("Wheelbarrow"),
                new Player("Cannon"),
                new Player("Hat"),
                new Player("Hokie")
            };

            var game = new Game(players, new FakeTurnTaker(), new GuidShuffler<Player>());
        }

        [TestMethod]
        public void StartingGameWithValidNumberOfPlayersDoesNotThrowException()
        {
            var players = new[] 
            {
                new Player("Horse"),
                new Player("Car"),
                new Player("Iron"),
                new Player("Ship"),
                new Player("Thimble"),
                new Player("Wheelbarrow"),
                new Player("Cannon"),
                new Player("Hat"),
            };

            var game = new Game(players, new FakeTurnTaker(), new GuidShuffler<Player>());
        }
    }
}
