 using System;

namespace MonopolyKata.Core.Spaces
{
    public class GoToJail : Space
    {
        private Int32 locationToSendPlayerTo;
        private Board board;

        public GoToJail(Int32 locationToSendPlayerTo, Board board)
            : base()
        {
            this.locationToSendPlayerTo = locationToSendPlayerTo;
            this.board = board;
        }

        public override void LandOn(String player)
        {
            board.TeleportPlayer(player, locationToSendPlayerTo);
        }
    }
}
