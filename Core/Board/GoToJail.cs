 using System;

namespace MonopolyKata.Core.Board
{
    public class GoToJail : Space
    {
        private Int32 locationToSendPlayerTo;
        private GameBoard board;

        public GoToJail(Int32 locationToSendPlayerTo, GameBoard board)
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
