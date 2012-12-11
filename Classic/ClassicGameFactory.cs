namespace Monopoly.Classic
{
    public class ClassicGameFactory
    {
        public static Game Create()
        {
            var dice = new Dice();
            var board = ClassicBoardFactory.Create();
            var movementHandler = new MovementHandler(board);
            var turnTaker = new TurnTaker(dice, movementHandler);

            return new Game(turnTaker);
        }
    }
}
