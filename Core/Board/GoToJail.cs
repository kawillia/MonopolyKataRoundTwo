 using System;

namespace MonopolyKata.Core.Board
{
    public class GoToJail : Space
    {
        public Int32 LocationToSendPlayerTo { get; private set; }

        public GoToJail(Int32 locationIndex, Int32 locationToSendPlayerTo)
            : base(locationIndex)
        {
            LocationToSendPlayerTo = locationToSendPlayerTo;
        }

        public override void LandOn(Player player)
        {
            player.MoveTo(LocationToSendPlayerTo);
        }
    }
}
