using System;

namespace MonopolyKata.Core.Strategies
{
    public class AlwaysBuy : IBuyingStrategy
    {
        public Boolean ShouldBuy()
        {
            return true;
        }
    }
}
