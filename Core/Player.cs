using System;

namespace MonopolyKata.Core
{
    public class Player
    {
        public String Name { get; private set; }
        public Int32 CurrentLocation { get; private set; }

        public Player(String name)
        {
            Name = name;
        }

        public void MoveTo(Int32 location)
        {
            CurrentLocation = location;
        }
    }
}
