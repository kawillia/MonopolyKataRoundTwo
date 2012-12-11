using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata;
using MonopolyKata.Classic;
using MonopolyKata.Core.Board;
using MonopolyKata.Classic.Strategies;
using MonopolyKata.Core;
using MonopolyKata.Core.Strategies;
using MonopolyKata.Tests.Fakes;

namespace MonopolyKata.Tests
{
    [TestClass]
    public class MovementHandlerTests
    {
        private Player player;
        private GameBoard board;
        private FakeDice fakeDice;
        private MovementHandler movementHandler;

        [TestInitialize]
        public void Initialize()
        {
            player = new Player("Horse");
            fakeDice = new FakeDice();
            board = ClassicBoardFactory.Create();      
            movementHandler = new MovementHandler(board, new[] { new PassGoBonusStrategy() });
        }

        [TestMethod]
        public void PlayerIsMoved()
        {
            movementHandler.MovePlayer(player, 3);

            Assert.AreEqual(3, player.CurrentLocation);
        }

        [TestMethod]
        public void PlayerPositionWrapsAtEndOfBoard()
        {
            player.MoveTo(38);
            movementHandler.MovePlayer(player, 4);

            Assert.AreEqual(2, player.CurrentLocation);
        }

        [TestMethod]
        public void PlayerReceivesMovementBonusWhenStrategyIsMet()
        {
            var balanceBefore = player.Balance;
            player.MoveTo(38);
            movementHandler.MovePlayer(player, 4);

            Assert.AreEqual(ClassicGameConstants.GoSalaryBonus + balanceBefore, player.Balance);
        }
    }
}
