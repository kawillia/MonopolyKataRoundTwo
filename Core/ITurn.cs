using System;

namespace MonopolyKata.Core
{
    public interface ITurn
    {
        void Begin(String player);
        void Take(String player);
        void End(String player);
    }
}
