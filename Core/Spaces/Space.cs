using System;

namespace MonopolyKata.Core.Spaces
{
    public class Space
    {
        public Int32 Index { get; private set; }

        public Space(Int32 index)
        {
            this.Index = index;
        }

        public virtual void LandOn(String player) { }
    }
}
