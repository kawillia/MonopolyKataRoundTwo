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
            ApplyMovementBonus(player, numberOfSpaces);
            LandOnLocation(player, numberOfSpaces);
        }

        private void ApplyMovementBonus(Player player, Int32 numberOfSpaces)
        {
            var movementBonus = 0;
            foreach (var movementBonusStrategy in movementBonusStrategies)
                movementBonus += movementBonusStrategy.GetBonus(player.CurrentLocation, numberOfSpaces);

            player.Receive(movementBonus);
        }

        private void LandOnLocation(Player player, Int32 numberOfSpaces)
        {
            player.MoveTo((player.CurrentLocation + numberOfSpaces) % board.TotalNumberOfLocations);

            var location = board.GetLocation(player.CurrentLocation);
            location.LandedOn(player);
        }
    }
}