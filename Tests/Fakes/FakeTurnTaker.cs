using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata.Core;

namespace MonopolyKata.Tests.Fakes
{
    public class FakeTurnTaker : ITurnTaker
    {
        private List<Player> turns;
        public List<Player> Turns { get { return turns.ToList(); } }

        public FakeTurnTaker()
        {
            turns = new List<Player>();
        }

        public void Take(Player player) 
        {
            turns.Add(player);
        }
    }
}
