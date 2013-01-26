using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata.Core
{
    public class Game
    {
        private const Int32 MaximumNumberOfPlayers = 8;
        private const Int32 MinimumNumberOfPlayers = 2;

        private IEnumerable<String> players;
        private ITurn turn;

        public Game(IEnumerable<String> players, ITurn turn, IShuffler<String> shuffler)
        {
            if (players.GroupBy(p => p).Any(g => g.Count() > 1))
                throw new InvalidOperationException("Cannot add the same player to the game more than once.");

            if (players.Count() < MinimumNumberOfPlayers || players.Count() > MaximumNumberOfPlayers)
                throw new InvalidOperationException("Cannot start the game with less than the minimum or greater than the maximum number of players.");

            this.turn = turn;
            this.players = shuffler.Shuffle(players).ToList();
        }

        public void PlayRound()
        {
            foreach (var player in players)
            {
                turn.Begin(player);
                turn.Take(player);
                turn.End(player);
            }
        }
    }
}