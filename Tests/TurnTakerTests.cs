using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.Board;
using Monopoly.Classic;
using MonopolyTests.Fakes;

namespace MonopolyTests
{
    [TestClass]
    public class TurnTakerTests
    {
        private FakeDice fakeDice;
        private Player player;
        private GameBoard board;
        private TurnTaker turnTaker;

        [TestInitialize]
        public void Initialize()
        {
            fakeDice = new FakeDice();
            player = new Player("Horse");
            board = ClassicBoardFactory.Create();
            turnTaker = new TurnTaker(fakeDice, new MovementHandler(board));
        }

        [TestMethod]
        public void PlayerMovesRollValue()
        {
            fakeDice.SetDieValues(3, 1);
            turnTaker.Take(player);

            Assert.AreEqual(4, player.CurrentLocation);
        }
    }
}
