using System;
using MonopolyKata.Core.Strategies;

namespace MonopolyKata.Core
{
    public class Player
    {
        private IBuyingStrategy buyingStrategy;

        public String Name { get; private set; }
        public Int32 CurrentLocation { get; private set; }

        public Player(String name)
        {
            Name = name;
            buyingStrategy = new AlwaysBuy();
        }

        public void MoveTo(Int32 location)
        {
            CurrentLocation = location;
        }

        public Boolean ShouldBuyProperty()
        {
            return buyingStrategy.ShouldBuy();
        }
    }
}
