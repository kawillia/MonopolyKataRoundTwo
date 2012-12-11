using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata.Core
{
    public class Shuffler<T>
    {
        public IEnumerable<T> Shuffle(IEnumerable<T> items)
        {
            return items.OrderBy(n => Guid.NewGuid());
        }
    }
}
