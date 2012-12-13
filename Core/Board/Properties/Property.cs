using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonopolyKata.Core;

namespace MonopolyKata.Core.Board.Properties
{
    public class Property : Space
    {
        public Int32 Price { get; private set; }
        public Int32 BaseRent { get; private set; }
        public Boolean IsOwned { get { return this.Owner != null; } }
        public Player Owner { get; set; }

        public Property(Int32 locationIndex, Int32 price, Int32 baseRent)
            : base(locationIndex)
        {
            Price = price;
            BaseRent = baseRent;
            Owner = null;
        }
    }
}
