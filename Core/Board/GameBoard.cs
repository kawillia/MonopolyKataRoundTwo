using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Board.Locations;

namespace Monopoly.Board
{
    public class GameBoard
    {
        protected IEnumerable<Location> locations;
        public Int32 TotalNumberOfLocations { get { return locations.Count(); } }
        
        public GameBoard(IEnumerable<Location> locations)
        {
            this.locations = locations;
        }

        public Location GetLocation(Int32 locationIndex)
        {
            return locations.First(bc => bc.LocationIndex == locationIndex);
        }
    }
}
