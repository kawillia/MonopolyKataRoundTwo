using System;
using System.Collections.Generic;
using System.Linq;
using MonopolyKata.Core.Board;
using MonopolyKata.Core.Strategies;

namespace MonopolyKata.Core
{
    public class MovementHandler
    {
        private GameBoard board;
        private IEnumerable<IMovementBonusStrategy> movementBonusStrategies;

        public MovementHandler(GameBoard board) : this(board, Enumerable.Empty<IMovementBonusStrategy>()) { }

        public MovementHandler(GameBoard board, IEnumerable<IMovementBonusStrategy> movementBonusStrategies)
        {
            this.board = board;
            this.movementBonusStrategies = movementBonusStrategies;
        }

        public void MovePlayer(Player player, Int32 numberOfSpaces)
        {
            var movementBonus = movementBonusStrategies.Sum(s => s.GetBonus(player.CurrentLocation, numberOfSpaces));
            player.Receive(movementBonus);

            var newLocation = (player.CurrentLocation + numberOfSpaces) % board.TotalNumberOfLocations;
            player.MoveTo(newLocation);
            board.HavePlayerLandOnCurrentLocation(player);
        }
    }
}