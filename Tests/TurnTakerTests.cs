using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Classic;
using MonopolyKata.Core.Board;
using MonopolyKata.Classic.Strategies;
using MonopolyKata.Core;
using MonopolyKata.Tests.Fakes;

namespace MonopolyKata.Tests
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
