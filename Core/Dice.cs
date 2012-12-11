using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata.Core
{
    public class Dice
    {
        private static Random randomDieValueGenerator = new Random(1);

        protected Int32 dieValueOne;
        protected Int32 dieValueTwo;

        public virtual Int32 Roll()
        {
            dieValueOne = randomDieValueGenerator.Next(1, 7);
            dieValueTwo = randomDieValueGenerator.Next(1, 7);

            return dieValueOne + dieValueTwo;
        }
    }
}
