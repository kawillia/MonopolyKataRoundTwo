using System;
using System.Collections.Generic;
using System.Linq;
using MonopolyKata.Core.Strategies;
using MonopolyKata.Core.Board;
using MonopolyKata.Core.Rules;

namespace MonopolyKata.Core.Board.Properties
{
    public class PropertyGroup : BoardComponent
    {
        private IEnumerable<Property> properties;
        private Property currentPlayerLocation;
        private IChargeRentRule chargeRentRule;

        public override Int32 NumberOfComponents
        {
            get { return properties.Count(); }
        }

        public PropertyGroup(IChargeRentRule chargeRentRule, params Property[] properties)
        {
            this.chargeRentRule = chargeRentRule;
            this.properties = properties;
        }

        public override Boolean ContainsComponentIndex(Int32 index)
        {
            return properties.Any(l => l.LocationIndex == index);
        }

        public override void LandOn(Player player)
        {
            currentPlayerLocation = properties.FirstOrDefault(p => p.LocationIndex == player.CurrentLocation);

            if (ShouldBuyProperty(player))
                BuyProperty(player);
            else if (ShouldPayRent(player))
                PayRent(player);
        }

        private Boolean ShouldBuyProperty(Player player)
        {
            return !currentPlayerLocation.IsOwned && player.ShouldBuyProperty();
        }

        private Boolean ShouldPayRent(Player player)
        {
            return currentPlayerLocation.IsOwned && player != currentPlayerLocation.Owner;
        }

        private void BuyProperty(Player player)
        {
            player.Pay(currentPlayerLocation.Price);
            currentPlayerLocation.Owner = player;
        }

        private void PayRent(Player player)
        {
            var rentAmount = chargeRentRule.CalculateRent(currentPlayerLocation, properties);

            player.Pay(rentAmount);
            currentPlayerLocation.Owner.Receive(rentAmount);
        }
    }
}
