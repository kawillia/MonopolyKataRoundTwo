using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata.Core
{
    public class Dice
    {
        private static Random randomDieValueGenerator = new Random();

        private Int32 dieValueOne;
        private Int32 dieValueTwo;

        public Int32 CurrentValue { get { return dieValueOne + dieValueTwo; } }
        public Boolean IsDoubles { get { return dieValueOne == dieValueTwo; } }        

        public void Roll()
        {
            dieValueOne = RollDie();
            dieValueTwo = RollDie();
        }

        public virtual Int32 RollDie()
        {
            return randomDieValueGenerator.Next(1, 7);
        }
    }
}
