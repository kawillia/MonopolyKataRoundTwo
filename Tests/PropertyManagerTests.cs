using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Core;
using MonopolyKata.Classic;
using MonopolyKata.Core.Spaces;
using System.Collections.Generic;

namespace MonopolyKata.Tests
{
    [TestClass]
    public class PropertyManagerTests
    {
        private String horse;
        private String hat;
        private IEnumerable<Property> properties;
        private PropertyManager propertyManager;

        public PropertyManagerTests()
        {
            horse = "Horse";
            hat = "Hat";
            var banker = new Banker(new[] { horse, hat });
            properties = ClassicBoardFactory.CreateProperties(banker);
            propertyManager = new PropertyManager(properties);
        }

        [TestMethod]
        public void GetPropertiesOwnedByPlayerWithOneOwner()
        {
            properties.ElementAt(0).LandOn(horse);

            var ownedProperties = propertyManager.GetPropertiesOwnedByPlayer(horse);

            Assert.AreEqual(1, ownedProperties.Count());
        }

        [TestMethod]
        public void GetPropertiesOwnedByPlayerWithMultipleOwners()
        {
            properties.ElementAt(0).LandOn(horse);
            properties.ElementAt(1).LandOn(hat);

            var ownedProperties = propertyManager.GetPropertiesOwnedByPlayer(horse);

            Assert.AreEqual(1, ownedProperties.Count());
        }
    }
}
