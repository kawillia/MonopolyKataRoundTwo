﻿using System;
using System.Collections.Generic;
using System.Linq;
using MonopolyKata.Core.Rules;
using MonopolyKata.Core.Spaces;

namespace MonopolyKata.Core
{
    public class Board : IBoard
    {
        private IEnumerable<Space> spaces;
        private IEnumerable<IMovementRule> movementRules;
        private Dictionary<String, Int32> playerLocations;

        public Board(IEnumerable<Space> spaces, IEnumerable<IMovementRule> movementRules, IEnumerable<String> players)
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
            spaces.ElementAt(newLocation).LandOn(player);
        }

        public void TeleportPlayer(String player, Int32 location)
        {
            playerLocations[player] = location;
        }

        public Int32 GetPlayerLocation(String player)
        {
            return playerLocations[player];
        }
    }
}