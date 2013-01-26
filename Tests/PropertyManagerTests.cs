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
        public void GetUnmortgagedPropertiesOwnedByPlayerWithOneOwner()
        {
            properties.ElementAt(0).Sell(horse);

            var ownedProperties = propertyManager.GetUnmortgagedProperties(horse);

            Assert.AreEqual(1, ownedProperties.Count());
        }

        [TestMethod]
        public void GetUnmortgagedPropertiesOwnedByPlayerWithMultipleOwners()
        {
            properties.ElementAt(0).Sell(horse);
            properties.ElementAt(1).Sell(hat);

            var unmortgagedProperties = propertyManager.GetUnmortgagedProperties(horse);

            Assert.AreEqual(1, unmortgagedProperties.Count());
        }

        [TestMethod]
        public void GetMortgagedPropertiesWithOneOwner()
        {
            var propertyOne = properties.ElementAt(0);
            propertyOne.Sell(horse);
            propertyOne.Mortgage();

            var mortgagedProperties = propertyManager.GetMortgagedProperties(horse);

            Assert.AreEqual(1, mortgagedProperties.Count());
        }

        [TestMethod]
        public void GetMortgagedPropertiesWithMultipleOwners()
        {
            var propertyOne = properties.ElementAt(0);
            propertyOne.Sell(horse);
            propertyOne.Mortgage();

            var propertyTwo = properties.ElementAt(1);
            propertyTwo.Sell(hat);

            var mortgagedProperties = propertyManager.GetMortgagedProperties(horse);

            Assert.AreEqual(1, mortgagedProperties.Count());
        }
    }
}
