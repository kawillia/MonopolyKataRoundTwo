using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.Board;
using Monopoly.Classic;
using MonopolyTests.Fakes;

namespace MonopolyTests
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
            movementHandler = new MovementHandler(board);
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
        public void MovePlayerSpaceBySpaceUpdatesNumberOfLocationsLandedOn()
        {
            movementHandler.MovePlayerSpaceBySpace(player, 4);
            movementHandler.MovePlayerSpaceBySpace(player, 10);

            Assert.AreEqual(2, movementHandler.NumberOfLocationsLandedOn);
        }
    }
}
