 using System;

namespace MonopolyKata.Core.Spaces
{
    public class GoToJail : Space
    {
        private Int32 jailLocation;
        private Board board;

        public GoToJail(Int32 index, Int32 jailLocation, Board board)
            : base(index)
        {
            this.jailLocation = jailLocation;
            this.board = board;
        }

        public override void LandOn(String player)
        {
            board.TeleportPlayer(player, jailLocation);
        }
    }
}
