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

namespace MonopolyKata.Tests.Board
{
    [TestClass]
    public class GameBoardTests
    {
        private Player horse;
        private GameBoard board;

        [TestInitialize]
        public void Initialize()
        {
            horse = new Player("Horse");

            var banker = new Banker(new[] { horse });
            var boardComponents = ClassicBoardFactory.GetSpaces(new FakeDice(), banker);
            board = new GameBoard(boardComponents, new[] { new ClassicPassGoBonusRule(banker) });
        }

        [TestMethod]
        public void PlayerIsMoved()
        {
            board.MovePlayerSpaceBySpace(horse, 3);

            Assert.AreEqual(3, horse.CurrentLocation);
        }

        [TestMethod]
        public void PlayerPositionWrapsAtEndOfBoard()
        {
            horse.MoveTo(38);
            board.MovePlayerSpaceBySpace(horse, 4);

            Assert.AreEqual(2, horse.CurrentLocation);
        }

        [TestMethod]
        public void MovementRulesAreApplied()
        {
            var rules = new[] { new FakeMovementRule(), new FakeMovementRule() };
            var banker = new Banker(new[] { horse });
            var boardComponents = ClassicBoardFactory.GetSpaces(new FakeDice(), banker);
            board = new GameBoard(boardComponents, rules);
            board.MovePlayerSpaceBySpace(horse, 4);

            foreach (var rule in rules)
                Assert.IsTrue(rule.Applied);
        }

        [TestMethod]
        public void MovePlayerDirectlyToPositionTest()
        {
            board.MovePlayerDirectlyToLocation(horse, 20);
            Assert.AreEqual(20, horse.CurrentLocation);
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
