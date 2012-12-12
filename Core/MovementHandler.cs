using System;
using System.Collections.Generic;
using System.Linq;
using MonopolyKata.Core.Board;
using MonopolyKata.Core.Rules;
using MonopolyKata.Core.Strategies;

namespace MonopolyKata.Core
{
    public class MovementHandler
    {
        private GameBoard board;
        private IEnumerable<IMovementBonusRule> movementBonusRules;

        public MovementHandler(GameBoard board) : this(board, Enumerable.Empty<IMovementBonusRule>()) { }

        public MovementHandler(GameBoard board, IEnumerable<IMovementBonusRule> movementBonusRules)
        {
            this.board = board;
            this.movementBonusRules = movementBonusRules;
        }

        public void MovePlayerSpaceBySpace(Player player, Int32 numberOfSpaces)
        {
            var movementBonus = movementBonusRules.Sum(s => s.GetBonus(player.CurrentLocation, numberOfSpaces));
            player.Receive(movementBonus);

            var newLocation = (player.CurrentLocation + numberOfSpaces) % board.TotalNumberOfLocations;
            player.MoveTo(newLocation);
            board.HavePlayerLandOnCurrentLocation(player);
        }

        public void MovePlayerDirectlyToLocation(Player player, Int32 location)
        {
            player.MoveTo(location);
        }
    }
}