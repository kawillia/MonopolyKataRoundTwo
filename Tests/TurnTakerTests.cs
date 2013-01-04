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
        private Player player;
        private ClassicTurnTaker turnTaker;

        [TestInitialize]
        public void Initialize()
        {
            fakeDice = new FakeDice();
            player = new Player("Horse");

            var boardComponents = ClassicBoardFactory.GetComponents(fakeDice);
            turnTaker = new ClassicTurnTaker(fakeDice, new GameBoard(boardComponents, Enumerable.Empty<IMovementRule>(), ClassicBoardFactory.NumberOfSpaces));
        }

        [TestMethod]
        public void StartOnGoRollDoublesOfSixAndNonDoublesOfFourEndsOnTen()
        {
            fakeDice.SetDieValues(3, 3, 1, 3);
            turnTaker.Take(player);

            Assert.AreEqual(10, player.CurrentLocation);
        }

        [TestMethod]
        public void PlayerDoesNotRollDoublesMovesRollValues()
        {
            fakeDice.SetDieValues(3, 1);
            turnTaker.Take(player);

            Assert.AreEqual(4, player.CurrentLocation);
        }

        [TestMethod]
        public void RollDoublesTwiceMovesThreeRollsTotal()
        {
            fakeDice.SetDieValues(1, 1, 2, 2, 1, 5);
            turnTaker.Take(player);

            Assert.AreEqual(12, player.CurrentLocation);
        }

        [TestMethod]
        public void RollDoublesThreeTimesEndOnJustVisiting()
        {
            fakeDice.SetDieValues(1, 1, 2, 2, 3, 3);
            turnTaker.Take(player);

            Assert.AreEqual(ClassicBoardFactory.JustVisitingLocation, player.CurrentLocation);
        }
    }
}
