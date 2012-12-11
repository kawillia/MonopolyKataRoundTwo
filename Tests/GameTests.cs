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
        private Game game;

        [TestInitialize]
        public void Initialize()
        {
            game = ClassicGameFactory.Create();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddingDuplicatePlayerThrowsException()
        {
            game.AddPlayer(new Player("Horse"));
            game.AddPlayer(new Player("Horse"));
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void StartingGameWithLessThanMinimumNumberOfPlayersThrowsException()
        {
            game.Start();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void StartingGameWithGreaterThanMaximumNumberOfPlayersThrowsException()
        {
            game.AddPlayer(new Player("Horse"));
            game.AddPlayer(new Player("Car"));
            game.AddPlayer(new Player("Iron"));
            game.AddPlayer(new Player("Ship"));
            game.AddPlayer(new Player("Thimble"));
            game.AddPlayer(new Player("Wheelbarrow"));
            game.AddPlayer(new Player("Cannon"));
            game.AddPlayer(new Player("Hat"));
            game.AddPlayer(new Player("Hokie"));
            game.Start();
        }

        [TestMethod]
        public void StartingGameWithValidNumberOfPlayersDoesNotThrowException()
        {
            game.AddPlayer(new Player("Horse"));
            game.AddPlayer(new Player("Car"));
            game.AddPlayer(new Player("Iron"));
            game.AddPlayer(new Player("Ship"));
            game.AddPlayer(new Player("Thimble"));
            game.AddPlayer(new Player("Wheelbarrow"));
            game.AddPlayer(new Player("Cannon"));
            game.AddPlayer(new Player("Hat"));
            game.Start();
        }
    }
}
