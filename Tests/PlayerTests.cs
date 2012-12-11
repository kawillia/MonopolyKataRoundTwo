using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;

namespace MonopolyTests
{
    [TestClass]
    public class PlayerTests
    {
        private Player player;

        public PlayerTests()
        {
            player = new Player("Horse");
        }

        [TestMethod]
        public void PayDecreasesBalance()
        {
            player.Pay(100);

            Assert.AreEqual(-100, player.Balance);
        }

        [TestMethod]
        public void ReceiveIncreasesBalance()
        {
            player.Receive(100);

            Assert.AreEqual(100, player.Balance);
        }
    }
}
