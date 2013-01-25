using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Core
{
    public class Banker
    {
        private Dictionary<String, Int32> balances;

        public Banker(IEnumerable<String> players)
        {
            balances = new Dictionary<String, Int32>();

            foreach (var player in players)
                balances.Add(player, 0);
        }

        public void Transfer(String from, String to, Int32 amount)
        {
            balances[from] -= amount;
            balances[to] += amount;
        }

        public void Pay(String player, Int32 amount)
        {
            balances[player] += amount;
        }

        public void Charge(String player, Int32 amount)
        {
            balances[player] -= amount;
        }

        public Int32 GetBalance(String player)
        {
            return balances[player];
        }
    }
}
