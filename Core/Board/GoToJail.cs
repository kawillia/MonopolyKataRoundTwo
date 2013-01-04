 using System;

namespace MonopolyKata.Core.Board
{
    public class GoToJail : Space
    {
        public Int32 LocationToSendPlayerTo { get; private set; }

        public GoToJail(Int32 locationToSendPlayerTo)
            : base()
        {
            LocationToSendPlayerTo = locationToSendPlayerTo;
        }

        public override void LandOn(Player player)
        {
            player.MoveTo(LocationToSendPlayerTo);
        }
    }
}
