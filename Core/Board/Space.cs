using System;

namespace MonopolyKata.Core.Board
{
    public class Space : BoardComponent
    {
        public Int32 LocationIndex { get; protected set; }

        public Space(Int32 locationIndex)
        {
            LocationIndex = locationIndex;
        }        

        public override Int32 NumberOfChildComponents
        {
            get { return 1; }
        }

        public override Boolean ContainsComponentIndex(Int32 index)
        {
            return LocationIndex == index;
        }
    }
}
