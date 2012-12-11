using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata.Core
{
    public class Round
    {
        private List<Player> players;

        public Round()
        {
            players = new List<Player>();
        }

        public IEnumerable<Player> Players
        {
            get { return players.ToList(); }
        }

        public void AddPlayerTurn(Player player)
        {
            players.Add(player);
        }
    }
}
