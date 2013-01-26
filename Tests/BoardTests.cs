using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata;
using MonopolyKata.Classic;
using MonopolyKata.Core.Spaces;
using MonopolyKata.Classic.Rules;
using MonopolyKata.Core;
using MonopolyKata.Core.Rules;
using System;
using System.Collections.Generic;
using Moq;

namespace MonopolyKata.Tests
{
    [TestClass]
    public class BoardTests
    {
        private String horse;
        private Board board;
        private IEnumerable<FakeMovementRule> movementRules;

        [TestInitialize]
        public void Initialize()
        {
            horse = "Horse";
            movementRules = new[] { new FakeMovementRule(), new FakeMovementRule() };

            var players = new[] { horse };
            var banker = new Banker(players);
            var propertyManager = new PropertyManager();
            var properties = ClassicBoardFactory.CreateProperties(banker, propertyManager);
            board = ClassicBoardFactory.CreateBoard(new Mock<Dice>().Object, movementRules, properties, banker, players);
        }

        [TestMethod]
        public void PlayerIsMoved()
        {
            board.MovePlayer(horse, 3);

            Assert.AreEqual(3, board.GetPlayerLocation(horse));
        }

        [TestMethod]
        public void PlayerPositionWrapsAtEndOfBoard()
        {
            board.TeleportPlayer(horse, 38);
            board.MovePlayer(horse, 4);

            Assert.AreEqual(2, board.GetPlayerLocation(horse));
        }

        [TestMethod]
        public void MovementRulesAreApplied()
        {
            board.MovePlayer(horse, 4);

            foreach (var rule in movementRules)
                Assert.IsTrue(rule.Applied);
        }

        [TestMethod]
        public void PlayerIsMovedDirectlyToPosition()
        {
            board.TeleportPlayer(horse, 20);
            Assert.AreEqual(20, board.GetPlayerLocation(horse));
        }

        private class FakeMovementRule : IMovementRule
        {
            public Boolean Applied { get; private set; }

            public void Apply(String player, Int32 currentLocation, Int32 numberOfSpaces)
            {
                Applied = true;
            }
        }
    }
}
