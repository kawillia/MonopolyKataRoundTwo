using System;

namespace MonopolyKata.Core
{
    public class GameController
    {
        public const Int32 NumberOfRoundsToPlay = 20;
        private Game game;

        public GameController(Game game)
        {
            this.game = game;
        }

        public void Play()
        {
            game.Start();

            for (var i = 0; i < NumberOfRoundsToPlay; i++)
                game.PlayRound();
        }
    }
}
