using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly;

namespace Monopoly.Board.Locations
{
    public class Location
    {
        public Int32 LocationIndex { get; protected set; }

        public Location(Int32 locationIndex)
        {
            LocationIndex = locationIndex;
        }

        public virtual void LandedOnByPlayer(Player player) { }
        public virtual void PassedByPlayer(Player player) { }
    }
}
