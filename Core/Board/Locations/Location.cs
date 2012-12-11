using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonopolyKata;
using MonopolyKata.Core;

namespace MonopolyKata.Core.Board.Locations
{
    public class Location
    {
        public Int32 LocationIndex { get; protected set; }

        public Location(Int32 locationIndex)
        {
            LocationIndex = locationIndex;
        }

        public virtual void LandedOn(Player player) { }
    }
}
