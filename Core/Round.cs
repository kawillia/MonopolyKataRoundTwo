using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata.Core
{
    public class Round
    {
        private IList<Player> players;

        public Round()
        {
            players = new List<Player>();
        }

        public IEnumerable<Player> Players
        {
            get { return new List<Player>(players); }
        }

        public Int32 NumberOfPlayers
        {
            get { return players.Count(); }
        }

        public void AddPlayerTurn(Player player)
        {
            players.Add(player);
        }
    }
}
