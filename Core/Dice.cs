using System;

namespace MonopolyKata.Core
{
    public class Dice
    {
        private static Random randomDieValueGenerator = new Random(1);

        public virtual Int32 Roll()
        {
            return randomDieValueGenerator.Next(1, 7) + randomDieValueGenerator.Next(1, 7);
        }
    }
}
