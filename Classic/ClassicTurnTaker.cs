using MonopolyKata.Core;

namespace MonopolyKata.Classic
{
    public class ClassicTurnTaker : ITurnTaker
    {
        private Dice dice;
        private MovementHandler movementHandler;

        public ClassicTurnTaker(Dice dice, MovementHandler movementHandler)
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
