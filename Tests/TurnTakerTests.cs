using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Classic;
using MonopolyKata.Core;
using MonopolyKata.Core.Spaces;
using MonopolyKata.Core.Rules;
using MonopolyKata.Tests.Fakes;
using System;

namespace MonopolyKata.Tests
{
    [TestClass]
    public class TurnTakerTests
    {
        private FakeDice fakeDice;
        private String horse;
        private Board board;
        private ClassicTurnTaker turnTaker;

        [TestInitialize]
        public void Initialize()
        {
            fakeDice = new FakeDice();
            horse = "Horse";

            var banker = new Banker(new[] { horse });
            board = ClassicBoardFactory.CreateBoard(fakeDice, Enumerable.Empty<IMovementRule>(), banker, new[] { horse });
            turnTaker = new ClassicTurnTaker(fakeDice, board);
        }

        [TestMethod]
        public void StartOnGoRollDoublesOfSixAndNonDoublesOfFourEndsOnTen()
        {
            fakeDice.SetDieValues(3, 3, 1, 3);
            turnTaker.Take(horse);

            Assert.AreEqual(10, board.GetPlayerLocation(horse));
        }

        [TestMethod]
        public void PlayerDoesNotRollDoublesMovesRollValues()
        {
            fakeDice.SetDieValues(3, 1);
            turnTaker.Take(horse);

            Assert.AreEqual(4, board.GetPlayerLocation(horse));
        }

        [TestMethod]
        public void RollDoublesTwiceMovesThreeRollsTotal()
        {
            fakeDice.SetDieValues(1, 1, 2, 2, 1, 5);
            turnTaker.Take(horse);

            Assert.AreEqual(12, board.GetPlayerLocation(horse));
        }

        [TestMethod]
        public void RollDoublesThreeTimesEndOnJustVisiting()
        {
            fakeDice.SetDieValues(1, 1, 2, 2, 3, 3);
            turnTaker.Take(horse);

            Assert.AreEqual(ClassicBoardFactory.JustVisitingLocation, board.GetPlayerLocation(horse));
        }
    }
}
