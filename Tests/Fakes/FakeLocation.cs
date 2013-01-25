using System;
using MonopolyKata.Core;
using MonopolyKata.Core.Board;

namespace MonopolyKata.Tests.Fakes
{
    public class FakeLocation : Space
    {
        public Boolean LandedOnCalled { get; set; }

        public FakeLocation() : base() { }

        public override void LandOn(String player)
        {
            LandedOnCalled = true;
        }
    }
}
