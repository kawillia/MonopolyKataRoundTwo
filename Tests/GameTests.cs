using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Classic;
using MonopolyKata.Classic.Rules;
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

        [TestMethod]
        public void FullStackTest()
        {
            var players = new[] { "Horse", "Hat" };
            var mockDice = new Mock<Dice>();
            var dieValues = new Queue<Int32>(new[] { 1, 2, 3, 5, 5, 6 });

            mockDice.Setup(d => d.RollDie()).Returns(() => dieValues.Dequeue());

            var banker = new Banker(players);

            foreach (var player in players)
                banker.Pay(player, 2000);

            var propertyManager = new PropertyManager();
            var properties = ClassicBoardFactory.CreateProperties(banker, propertyManager);
            propertyManager.ManageProperties(properties);

            var board = ClassicBoardFactory.CreateBoard(mockDice.Object, new[] { new ClassicGoBonusRule(banker) }, properties, banker, players);
            var turn = new ClassicTurn(mockDice.Object, board, banker, propertyManager);
            var game =  new Game(players, turn, new GuidShuffler<String>());
            game.PlayRound();

            Assert.IsTrue(properties.First(p => p.Index == 3).IsOwned);
            Assert.IsTrue(properties.First(p => p.Index == 8).IsOwned);
        }
    }
}
