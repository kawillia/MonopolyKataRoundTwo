using System;

namespace MonopolyKata.Core.Board
{
    public class Location : BoardComponent
    {
        public Int32 LocationIndex { get; protected set; }

        public Location(Int32 locationIndex)
        {
            LocationIndex = locationIndex;
        }        

        public override Int32 NumberOfComponents
        {
            get { return 1; }
        }

        public override Boolean ContainsComponentIndex(Int32 index)
        {
            return LocationIndex == index;
        }
    }
}
