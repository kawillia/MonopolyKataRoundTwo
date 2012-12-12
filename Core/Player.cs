using System;
using MonopolyKata.Core.Strategies;

namespace MonopolyKata.Core
{
    public class Player
    {
        private IBuyingStrategy buyingStrategy;

        public String Name { get; private set; }
        public Int32 Balance { get; private set; }
        public Int32 CurrentLocation { get; private set; }
        public Int32 NetWorth { get { return Balance; } }

        public Player(String name) : this(name, 0) { }

        public Player(String name, Int32 initialBalance)
        {
            Name = name;
            Balance = initialBalance;
            buyingStrategy = new AlwaysBuy();
        }

        public void Pay(Int32 amount)
        {
            Balance -= amount;
        }

        public void Receive(Int32 amount)
        {
            Balance += amount;
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
