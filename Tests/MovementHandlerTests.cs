using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata;
using MonopolyKata.Classic;
using MonopolyKata.Core.Board;
using MonopolyKata.Classic.Rules;
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
        private MovementHandler movementHandler;

        [TestInitialize]
        public void Initialize()
        {
            player = new Player("Horse");
            board = ClassicBoardFactory.Create(new FakeDice());      
            movementHandler = new MovementHandler(board, new[] { new ClassicPassGoBonusRule() });
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
        public void PlayerReceivesMovementBonusWhenStrategyIsMet()
        {
            var balanceBefore = player.Balance;
            player.MoveTo(38);
            movementHandler.MovePlayerSpaceBySpace(player, 4);

            Assert.AreEqual(ClassicGameConstants.GoSalaryBonus + balanceBefore, player.Balance);
        }

        [TestMethod]
        public void MovePlayerDirectlyToPositionTest()
        {
            movementHandler.MovePlayerDirectlyToLocation(player, 20);
            Assert.AreEqual(20, player.CurrentLocation);
        }
    }
}
