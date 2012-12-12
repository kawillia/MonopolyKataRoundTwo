using System;

namespace MonopolyKata.Core.Strategies
{
    public class NeverPayToGetOutOfJail : IGetOutOfJailStrategy
    {
        public Boolean PayToGetOutOfJail()
        {
            return false;
        }
    }
}
