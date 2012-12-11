using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata.Core
{
    public class Game
    {
        private const Int32 MaximumNumberOfPlayers = 8;
        private const Int32 MinimumNumberOfPlayers = 2;

        private TurnTaker turnTaker;
        private Round currentRound;
        private List<Round> rounds;
        private List<Player> players;
        private Shuffler<Player> shuffler;
                
        public IEnumerable<Round> Rounds
        {
            get { return rounds.ToList(); }
        }

        public Game(TurnTaker turnTaker)
        {
            this.turnTaker = turnTaker;
            this.players = new List<Player>();
            this.shuffler = new Shuffler<Player>();
        }

        public void AddPlayer(Player playerToAdd)
        {
            if (players.Any(p => p.Name == playerToAdd.Name))
                throw new InvalidOperationException("Cannot add the same player to the game more than once.");

            players.Add(playerToAdd);
        }

        public void Start()
        {
            if (players.Count < MinimumNumberOfPlayers || players.Count > MaximumNumberOfPlayers)
                throw new InvalidOperationException("Cannot start the game with less than the minimum or greater than the maximum number of players.");

            rounds = new List<Round>();
            players = shuffler.Shuffle(players).ToList();
        }

        public void PlayRound()
        {
            currentRound = new Round();

            foreach (var player in players)
            {
                turnTaker.Take(player);
                currentRound.AddPlayerTurn(player);
            }

            rounds.Add(currentRound);
        }
    }
}
