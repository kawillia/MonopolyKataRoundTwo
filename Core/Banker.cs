using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Core
{
    public class Banker
    {
        private Dictionary<Player, Int32> balances;

        public Banker(IEnumerable<Player> players)
        {
            balances = new Dictionary<Player, Int32>();

            foreach (var player in players)
                balances.Add(player, 0);
        }

        public void AddPlayer(Player player)
        {
            balances[player] = 0;
        }

        public void Transfer(Player from, Player to, Int32 amount)
        {
            balances[from] -= amount;
            balances[to] += amount;
        }

        public void Pay(Player player, Int32 amount)
        {
            balances[player] += amount;
        }

        public void Charge(Player player, Int32 amount)
        {
            balances[player] -= amount;
        }

        public Int32 GetBalance(Player player)
        {
            return balances[player];
        }
    }
}
