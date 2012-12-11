namespace MonopolyKata.Core
{
    public class TurnTaker
    {
        private Dice dice;
        private MovementHandler movementHandler;

        public TurnTaker(Dice dice, MovementHandler movementHandler)
        {
            this.dice = dice;
            this.movementHandler = movementHandler;
        }

        public void Take(Player player)
        {
            movementHandler.MovePlayer(player, dice.Roll());
        }
    }
}
