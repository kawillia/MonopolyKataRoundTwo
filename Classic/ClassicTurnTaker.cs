using MonopolyKata.Core;
using MonopolyKata.Core.Board;

namespace MonopolyKata.Classic
{
    public class ClassicTurnTaker : ITurnTaker
    {
        private Dice dice;
        private GameBoard movementHandler;

        public ClassicTurnTaker(Dice dice, GameBoard movementHandler)
        {
            this.dice = dice;
            this.movementHandler = movementHandler;
        }

        public void Take(Player player)
        {
            do
            {
                dice.Roll();

                if (dice.NumberOfConsecutiveDoubles == 3)
                    movementHandler.MovePlayerDirectlyToLocation(player, 10);
                else
                    movementHandler.MovePlayerSpaceBySpace(player, dice.CurrentValue);
            }
            while (dice.IsDoubles && dice.NumberOfConsecutiveDoubles < 3);
        }
    }
}
