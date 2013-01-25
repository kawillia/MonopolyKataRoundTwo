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
        private List<String> turns;
        public List<String> Turns { get { return turns.ToList(); } }

        public FakeTurnTaker()
        {
            turns = new List<String>();
        }

        public void Take(String player) 
        {
            turns.Add(player);
        }
    }
}
