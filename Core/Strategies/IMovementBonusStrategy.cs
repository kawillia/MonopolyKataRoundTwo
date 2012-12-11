using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Core.Strategies
{
    public interface IMovementBonusStrategy
    {
        Int32 GetBonus(Int32 startingLocation, Int32 numberOfSpaces);
    }
}
