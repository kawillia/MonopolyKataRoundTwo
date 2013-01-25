using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Classic;
using MonopolyKata.Core;
using MonopolyKata.Core.Board;
using MonopolyKata.Core.Rules;
using MonopolyKata.Tests.Fakes;

namespace MonopolyKata.Tests
{
    [TestClass]
    public class TurnTakerTests
    {
        private FakeDice fakeDice;
        private Player horse;
        private ClassicTurnTaker turnTaker;

        [TestInitialize]
        public void Initialize()
        {
            fakeDice = new FakeDice();
            horse = new Player("Horse");

            var banker = new Banker(new[] { horse });
            var spaces = ClassicBoardFactory.GetSpaces(fakeDice, banker);
            turnTaker = new ClassicTurnTaker(fakeDice, new GameBoard(spaces, Enumerable.Empty<IMovementRule>()));
        }

        [TestMethod]
        public void StartOnGoRollDoublesOfSixAndNonDoublesOfFourEndsOnTen()
        {
            fakeDice.SetDieValues(3, 3, 1, 3);
            turnTaker.Take(horse);

            Assert.AreEqual(10, horse.CurrentLocation);
        }

        [TestMethod]
        public void PlayerDoesNotRollDoublesMovesRollValues()
        {
            fakeDice.SetDieValues(3, 1);
            turnTaker.Take(horse);

            Assert.AreEqual(4, horse.CurrentLocation);
        }

        [TestMethod]
        public void RollDoublesTwiceMovesThreeRollsTotal()
        {
            fakeDice.SetDieValues(1, 1, 2, 2, 1, 5);
            turnTaker.Take(horse);

            Assert.AreEqual(12, horse.CurrentLocation);
        }

        [TestMethod]
        public void RollDoublesThreeTimesEndOnJustVisiting()
        {
            fakeDice.SetDieValues(1, 1, 2, 2, 3, 3);
            turnTaker.Take(horse);

            Assert.AreEqual(ClassicBoardFactory.JustVisitingLocation, horse.CurrentLocation);
        }
    }
}
