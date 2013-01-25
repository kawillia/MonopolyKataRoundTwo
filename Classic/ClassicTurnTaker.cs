using MonopolyKata.Core;
using MonopolyKata.Core.Spaces;
using System;

namespace MonopolyKata.Classic
{
    public class ClassicTurnTaker : ITurnTaker
    {
        private Dice dice;
        private Board board;

        public ClassicTurnTaker(Dice dice, Board board)
        {
            this.dice = dice;
            this.board = board;
        }

        public void Take(String player)
        {
            var numberOfConsecutiveDoubles = 0;

            do
            {
                dice.Roll();

                if (dice.IsDoubles)
                    numberOfConsecutiveDoubles++;

                if (numberOfConsecutiveDoubles == 3)
                    board.TeleportPlayer(player, 10);
                else
                    board.MovePlayer(player, dice.CurrentValue);
            }
            while (dice.IsDoubles && numberOfConsecutiveDoubles < 3);
        }
    }
}
