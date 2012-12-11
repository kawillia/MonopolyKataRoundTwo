using System;
using System.Collections.Generic;
using System.Linq;
using MonopolyKata.Core.Board.Locations;

namespace MonopolyKata.Core.Board
{
    public class GameBoard
    {
        protected IEnumerable<Location> locations;
        public Int32 TotalNumberOfLocations { get { return locations.Count(); } }
        
        public GameBoard(IEnumerable<Location> locations)
        {
            this.locations = locations;
        }

        public void HavePlayerLandOnCurrentLocation(Player player)
        {
            var location = locations.ElementAt(player.CurrentLocation);
            location.LandOn(player);
        }
    }
}
