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
        private IEnumerable<FakeSpace> spaces;
        private Board board;
        private IEnumerable<FakeMovementRule> movementRules;

        [TestInitialize]
        public void Initialize()
        {
            horse = "Horse";
            movementRules = new[] { new FakeMovementRule(), new FakeMovementRule() };
            spaces = new[] { new FakeSpace(0), new FakeSpace(1), new FakeSpace(2), new FakeSpace(3) };
            board = new Board(spaces, movementRules, new[] { horse });
        }

        [TestMethod]
        public void PlayerIsMoved()
        {
            board.MovePlayer(horse, 3);

            Assert.AreEqual(3, board.GetPlayerLocation(horse));
            Assert.IsTrue(spaces.ElementAt(3).LandedOn);
        }

        [TestMethod]
        public void PlayerPositionWrapsAtEndOfBoard()
        {
            board.MovePlayer(horse, 5);

            Assert.AreEqual(1, board.GetPlayerLocation(horse));
            Assert.IsTrue(spaces.ElementAt(1).LandedOn);
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
            board.TeleportPlayer(horse, 3);

            Assert.AreEqual(3, board.GetPlayerLocation(horse));
            Assert.IsFalse(spaces.ElementAt(0).LandedOn);
        }

        private class FakeMovementRule : IMovementRule
        {
            public Boolean Applied { get; private set; }

            public void Apply(String player, Int32 currentLocation, Int32 numberOfSpaces)
            {
                Applied = true;
            }
        }

        private class FakeSpace : Space
        {
            public Boolean LandedOn { get; private set; }

            public FakeSpace(Int32 index)
                : base(index)
            { }

            public override void LandOn(String player)
            {
                LandedOn = true;
            }
        }
    }
}
