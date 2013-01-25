using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata;
using MonopolyKata.Classic;
using MonopolyKata.Core.Board;
using MonopolyKata.Classic.Rules;
using MonopolyKata.Core;
using MonopolyKata.Tests.Fakes;
using MonopolyKata.Core.Rules;
using System;
using System.Collections.Generic;

namespace MonopolyKata.Tests.Board
{
    [TestClass]
    public class GameBoardTests
    {
        private String horse;
        private GameBoard board;
        private IEnumerable<FakeMovementRule> movementRules;

        [TestInitialize]
        public void Initialize()
        {
            horse = "Horse";
            movementRules = new[] { new FakeMovementRule(), new FakeMovementRule() };

            var players = new[] { horse };
            var banker = new Banker(players);
            board = ClassicBoardFactory.CreateBoard(new FakeDice(), movementRules, banker, players);
        }

        [TestMethod]
        public void PlayerIsMoved()
        {
            board.MovePlayerSpaceBySpace(horse, 3);

            Assert.AreEqual(3, board.GetPlayerLocation(horse));
        }

        [TestMethod]
        public void PlayerPositionWrapsAtEndOfBoard()
        {
            board.MovePlayerDirectlyToLocation(horse, 38);
            board.MovePlayerSpaceBySpace(horse, 4);

            Assert.AreEqual(2, board.GetPlayerLocation(horse));
        }

        [TestMethod]
        public void MovementRulesAreApplied()
        {
            board.MovePlayerSpaceBySpace(horse, 4);

            foreach (var rule in movementRules)
                Assert.IsTrue(rule.Applied);
        }

        [TestMethod]
        public void PlayerIsMovedDirectlyToPosition()
        {
            board.MovePlayerDirectlyToLocation(horse, 20);
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
