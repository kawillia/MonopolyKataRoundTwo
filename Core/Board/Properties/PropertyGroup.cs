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
        private Property propertyLandedOn;
        private IChargeRentRule chargeRentRule;

        public override Int32 NumberOfChildComponents
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
            propertyLandedOn = properties.FirstOrDefault(p => p.LocationIndex == player.CurrentLocation);

            if (ShouldBuyProperty(player))
                BuyProperty(player);
            else if (ShouldPayRent(player))
                PayRent(player);
        }

        private Boolean ShouldBuyProperty(Player player)
        {
            return !propertyLandedOn.IsOwned && player.ShouldBuyProperty();
        }

        private Boolean ShouldPayRent(Player player)
        {
            return propertyLandedOn.IsOwned && player != propertyLandedOn.Owner;
        }

        private void BuyProperty(Player player)
        {
            player.Pay(propertyLandedOn.Price);
            propertyLandedOn.Owner = player;
        }

        private void PayRent(Player player)
        {
            var rentAmount = chargeRentRule.CalculateRent(propertyLandedOn, properties);

            player.Pay(rentAmount);
            propertyLandedOn.Owner.Receive(rentAmount);
        }
    }
}
