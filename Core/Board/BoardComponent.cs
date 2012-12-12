using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata.Core.Board
{
    public abstract class BoardComponent
    {
        public abstract Boolean ContainsComponentIndex(Int32 index);
        public virtual void LandOn(Player player) { }
        public abstract Int32 NumberOfComponents { get; }
    }
}
