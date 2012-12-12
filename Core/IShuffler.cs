using System;
using System.Collections.Generic;

namespace MonopolyKata.Core
{
    public interface IShuffler<T>
    {
        IEnumerable<T> Shuffle(IEnumerable<T> items);
    }
}
