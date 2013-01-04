using System;
using System.Collections.Generic;
using System.Linq;
using MonopolyKata.Core.Rules;
using MonopolyKata.Core.Strategies;

namespace MonopolyKata.Core.Board
{
    public class GameBoard
    {
        private IEnumerable<Space> spaces;
        private IEnumerable<IMovementRule> movementRules;

        public GameBoard(IEnumerable<Space> spaces, IEnumerable<IMovementRule> movementRules)
        {
            this.spaces = spaces;
            this.movementRules = movementRules;
        }

        public void MovePlayerSpaceBySpace(Player player, Int32 numberOfSpaces)
        {
            foreach (var rule in movementRules)
                rule.Apply(player, numberOfSpaces);

            var newLocation = (player.CurrentLocation + numberOfSpaces) % spaces.Count();
            player.MoveTo(newLocation);

            var spaceToLandOn = spaces.ElementAt(newLocation);
            spaceToLandOn.LandOn(player);
        }

        public void MovePlayerDirectlyToLocation(Player player, Int32 location)
        {
            player.MoveTo(location);
        }
    }
}