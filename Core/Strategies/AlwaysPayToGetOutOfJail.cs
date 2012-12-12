using System;

namespace MonopolyKata.Core.Strategies
{
    public class AlwaysPayToGetOutOfJail : IGetOutOfJailStrategy
    {
        public Boolean PayToGetOutOfJail()
        {
            return true;
        }
    }
}
