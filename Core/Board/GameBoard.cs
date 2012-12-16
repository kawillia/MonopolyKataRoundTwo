using System;
using System.Collections.Generic;
using System.Linq;
using MonopolyKata.Core.Rules;
using MonopolyKata.Core.Strategies;

namespace MonopolyKata.Core.Board
{
    public class GameBoard
    {
        private IEnumerable<BoardComponent> boardComponents;
        private IEnumerable<IMovementRule> movementRules;

        public GameBoard(IEnumerable<BoardComponent> boardComponents, IEnumerable<IMovementRule> movementRules)
        {
            this.boardComponents = boardComponents;
            this.movementRules = movementRules;
        }

        public void MovePlayerSpaceBySpace(Player player, Int32 numberOfSpaces)
        {
            foreach (var rule in movementRules)
                rule.Apply(player, numberOfSpaces);

            var newLocation = (player.CurrentLocation + numberOfSpaces) % boardComponents.Sum(c => c.NumberOfChildComponents);
            player.MoveTo(newLocation);

            var componentToLandOn = boardComponents.First(c => c.ContainsComponentIndex(newLocation));
            componentToLandOn.LandOn(player);
        }

        public void MovePlayerDirectlyToLocation(Player player, Int32 location)
        {
            player.MoveTo(location);
        }
    }
}