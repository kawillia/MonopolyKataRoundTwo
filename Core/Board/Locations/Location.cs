using System;

namespace MonopolyKata.Core.Board.Locations
{
    public class Location
    {
        public Int32 LocationIndex { get; protected set; }

        public Location(Int32 locationIndex)
        {
            LocationIndex = locationIndex;
        }

        public virtual void LandOn(Player player) { }
    }
}
