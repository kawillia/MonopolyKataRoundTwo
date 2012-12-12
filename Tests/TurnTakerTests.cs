using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Classic;
using MonopolyKata.Core;
using MonopolyKata.Core.Board;
using MonopolyKata.Tests.Fakes;

namespace MonopolyKata.Tests
{
    [TestClass]
    public class TurnTakerTests
    {
        private FakeDice fakeDice;
        private Player player;
        private GameBoard board;
        private ClassicTurnTaker turnTaker;

        [TestInitialize]
        public void Initialize()
        {
            fakeDice = new FakeDice();
            player = new Player("Horse");
            board = ClassicBoardFactory.Create(fakeDice);
            turnTaker = new ClassicTurnTaker(fakeDice, new MovementHandler(board));
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
