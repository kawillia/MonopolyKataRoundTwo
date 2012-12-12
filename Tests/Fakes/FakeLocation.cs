using System;
using MonopolyKata.Core;
using MonopolyKata.Core.Board;

namespace MonopolyKata.Tests.Fakes
{
    public class FakeLocation : Location
    {
        public Boolean LandedOnCalled { get; set; }

        public FakeLocation(Int32 locationIndex) : base(locationIndex) { }

        public override void LandOn(Player player)
        {
            LandedOnCalled = true;
        }
    }
}
