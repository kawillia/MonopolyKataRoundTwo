using System;
using System.Collections.Generic;
using MonopolyKata.Core;

namespace MonopolyTests.Fakes
{
    public class FakeDice : Dice
    {
        private Queue<Int32> dieValues;

        public void SetDieValues(params Int32[] dieValues)
        {
            this.dieValues = new Queue<Int32>(dieValues);
        }

        public override Int32 Roll()
        {
            dieValueOne = dieValues.Dequeue();
            dieValueTwo = dieValues.Dequeue();

            return dieValueOne + dieValueTwo;
        }
    }
}
