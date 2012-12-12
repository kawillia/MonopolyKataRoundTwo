using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata.Core
{
    public class Dice
    {
        public Int32 CurrentValue { get { return dieValueOne + dieValueTwo; } }
        public Boolean IsDoubles { get { return dieValueOne == dieValueTwo; } }
        public Int32 NumberOfConsecutiveDoubles { get; private set; }

        private static Random randomDieValueGenerator = new Random();

        private Int32 dieValueOne;
        private Int32 dieValueTwo;

        public Int32 Roll()
        {
            dieValueOne = RollDie();
            dieValueTwo = RollDie();

            if (IsDoubles)
                NumberOfConsecutiveDoubles++;

            return CurrentValue;
        }

        public virtual Int32 RollDie()
        {
            return randomDieValueGenerator.Next(1, 7);
        }
    }
}
