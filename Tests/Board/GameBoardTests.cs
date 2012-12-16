using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata;
using MonopolyKata.Classic;
using MonopolyKata.Core.Board;
using MonopolyKata.Classic.Rules;
using MonopolyKata.Core;
using MonopolyKata.Core.Strategies;
using MonopolyKata.Tests.Fakes;
using MonopolyKata.Core.Rules;
using System;

namespace MonopolyKata.Tests.Board
{
    [TestClass]
    public class GameBoardTests
    {
        private Player player;
        private GameBoard board;
        private GameBoard movementHandler;

        [TestInitialize]
        public void Initialize()
        {
            player = new Player("Horse");

            var boardComponents = ClassicBoardFactory.GetComponents(new FakeDice());
            movementHandler = new GameBoard(boardComponents, new[] { new ClassicPassGoBonusRule() });
        }

        [TestMethod]
        public void PlayerIsMoved()
        {
            movementHandler.MovePlayerSpaceBySpace(player, 3);

            Assert.AreEqual(3, player.CurrentLocation);
        }

        [TestMethod]
        public void PlayerPositionWrapsAtEndOfBoard()
        {
            player.MoveTo(38);
            movementHandler.MovePlayerSpaceBySpace(player, 4);

            Assert.AreEqual(2, player.CurrentLocation);
        }

        [TestMethod]
        public void MovementRulesAreApplied()
        {
            var rules = new[] { new FakeMovementRule(), new FakeMovementRule() };
            var boardComponents = ClassicBoardFactory.GetComponents(new FakeDice());
            movementHandler = new GameBoard(boardComponents, rules);
            movementHandler.MovePlayerSpaceBySpace(player, 4);

            foreach (var rule in rules)
                Assert.IsTrue(rule.Applied);
        }

        [TestMethod]
        public void MovePlayerDirectlyToPositionTest()
        {
            movementHandler.MovePlayerDirectlyToLocation(player, 20);
            Assert.AreEqual(20, player.CurrentLocation);
        }

        private class FakeMovementRule : IMovementRule
        {
            public Boolean Applied { get; private set; }

            public void Apply(Player player, Int32 numberOfSpaces)
            {
                Applied = true;
            }
        }
    }
}
