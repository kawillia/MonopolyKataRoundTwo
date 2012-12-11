using System;
using Monopoly.Board;

namespace Monopoly
{
    public class MovementHandler
    {
        private GameBoard board;
        public Int32 NumberOfLocationsLandedOn { get; private set; }

        public MovementHandler(GameBoard board)
        {
            this.board = board;
        }

        public void MovePlayerSpaceBySpace(Player player, Int32 numberOfSpaces)
        {
            for (var i = 1; i < numberOfSpaces; i++)
                PassNextLocation(player);

            LandOnNextLocation(player);
            NumberOfLocationsLandedOn++;
        }

        private void PassNextLocation(Player player)
        {
            MovePlayerOneLocation(player);

            var location = board.GetLocation(player.CurrentLocation);
            location.PassedByPlayer(player);
        }

        private void LandOnNextLocation(Player player)
        {
            MovePlayerOneLocation(player);

            var location = board.GetLocation(player.CurrentLocation);
            location.LandedOnByPlayer(player);
        }

        private void MovePlayerOneLocation(Player player)
        {
            player.MoveTo((player.CurrentLocation + 1) % board.TotalNumberOfLocations);
        }
    }
}