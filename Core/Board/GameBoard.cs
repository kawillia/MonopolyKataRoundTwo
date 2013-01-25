using System;
using System.Collections.Generic;
using System.Linq;
using MonopolyKata.Core.Rules;

namespace MonopolyKata.Core.Board
{
    public class GameBoard
    {
        private IEnumerable<Space> spaces;
        private IEnumerable<IMovementRule> movementRules;
        private Dictionary<String, Int32> playerLocations;

        public GameBoard(IEnumerable<Space> spaces, IEnumerable<IMovementRule> movementRules, IEnumerable<String> players)
        {
            this.spaces = spaces;
            this.movementRules = movementRules;
            this.playerLocations = new Dictionary<String, Int32>();

            foreach (var player in players)
                playerLocations.Add(player, 0);
        }

        public void MovePlayer(String player, Int32 numberOfSpaces)
        {
            var currentLocation = playerLocations[player];

            foreach (var rule in movementRules)
                rule.Apply(player, currentLocation, numberOfSpaces);
            
            var newLocation = (currentLocation + numberOfSpaces) % spaces.Count();
            playerLocations[player] = newLocation;

            var spaceToLandOn = spaces.ElementAt(newLocation);
            spaceToLandOn.LandOn(player);
        }

        public void TeleportPlayer(String player, Int32 location)
        {
            playerLocations[player] = location;
        }

        public Int32 GetPlayerLocation(string player)
        {
            return playerLocations[player];
        }
    }
}