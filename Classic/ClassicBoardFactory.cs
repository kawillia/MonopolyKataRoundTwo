using System;
using System.Collections.Generic;
using MonopolyKata.Classic.Rules;
using MonopolyKata.Core;
using MonopolyKata.Core.Spaces;
using MonopolyKata.Core.Rules;

namespace MonopolyKata.Classic
{
    public class ClassicBoardFactory
    {
        public const Int32 GoSalaryBonus = 200;
        public const Int32 IncomeTaxPercentage = 10;
        public const Int32 LuxuryTaxPaymentAmount = 75;
        public const Int32 MaximumIncomeTaxPaymentAmount = 200;

        public const Int32 RailroadPrice = 200;
        public const Int32 UtilityPrice = 150;

        public const Int32 BaseRailroadRent = 25;
        public const Int32 MediterraneanAvenueRent = 2;
        public const Int32 BalticAvenueRent = 4;
        public const Int32 OrientalAvenueRent = 6;
        public const Int32 VermontAvenueRent = 6;
        public const Int32 ConnecticutAvenueRent = 8;
        public const Int32 StCharlesPlaceRent = 10;
        public const Int32 StatesAvenueRent = 10;
        public const Int32 VirginiaAvenueRent = 12;
        public const Int32 StJamesPlaceRent = 14;
        public const Int32 TennesseeAvenueRent = 14;
        public const Int32 NewYorkAvenueRent = 16;
        public const Int32 KentuckyAvenueRent = 18;
        public const Int32 IndianaAvenueRent = 18;
        public const Int32 IllinoisAvenueRent = 20;
        public const Int32 AtlanticAvenueRent = 22;
        public const Int32 VentnorAvenueRent = 22;
        public const Int32 MarvinGardensRent = 24;
        public const Int32 PacificAvenueRent = 26;
        public const Int32 NorthCarolinaAvenueRent = 26;
        public const Int32 PennsylvaniaAvenueRent = 28;
        public const Int32 ParkPlaceRent = 35;
        public const Int32 BoardwalkRent = 50;

        public const Int32 MediterraneanAvenuePrice = 60;
        public const Int32 BalticAvenuePrice = 60;
        public const Int32 OrientalAvenuePrice = 100;
        public const Int32 VermontAvenuePrice = 100;
        public const Int32 ConnecticutAvenuePrice = 120;
        public const Int32 StCharlesPlacePrice = 140;
        public const Int32 StatesAvenuePrice = 140;
        public const Int32 VirginiaAvenuePrice = 160;
        public const Int32 StJamesPlacePrice = 180;
        public const Int32 TennesseeAvenuePrice = 180;
        public const Int32 NewYorkAvenuePrice = 200;
        public const Int32 KentuckyAvenuePrice = 220;
        public const Int32 IndianaAvenuePrice = 220;
        public const Int32 IllinoisAvenuePrice = 240;
        public const Int32 AtlanticAvenuePrice = 260;
        public const Int32 VentnorAvenuePrice = 260;
        public const Int32 MarvinGardensPrice = 280;
        public const Int32 PacificAvenuePrice = 300;
        public const Int32 NorthCarolinaAvenuePrice = 300;
        public const Int32 PennsylvaniaAvenuePrice = 320;
        public const Int32 ParkPlacePrice = 350;
        public const Int32 BoardwalkPrice = 400;

        public const Int32 JustVisitingLocation = 10;
        public const Int32 NumberOfSpaces = 40;

        public static Board CreateBoard(Dice dice, IEnumerable<IMovementRule> movementRules, IEnumerable<Property> properties, Banker banker, IEnumerable<String> players)
        {
            var spaces = new List<Space>();
            var board = new Board(spaces, movementRules, players);

            var go = new Space();
            var communityChestOne = new Space();
            var incomeTax = new IncomeTax(IncomeTaxPercentage, MaximumIncomeTaxPaymentAmount, banker);
            var chanceOne = new Space();
            var justVisiting = new Space();
            var communityChestTwo = new Space();
            var freeParking = new Space();
            var chanceTwo = new Space();
            var goToJail = new GoToJail(JustVisitingLocation, board);
            var communityChestThree = new Space();
            var chanceThree = new Space();
            var luxuryTax = new LuxuryTax(LuxuryTaxPaymentAmount, banker);

            spaces.Add(go);
            spaces.Add(communityChestOne);
            spaces.Add(incomeTax);
            spaces.Add(chanceOne);
            spaces.Add(justVisiting);
            spaces.Add(communityChestTwo);
            spaces.Add(freeParking);
            spaces.Add(chanceTwo);
            spaces.Add(goToJail);
            spaces.Add(communityChestThree);
            spaces.Add(chanceThree);
            spaces.Add(luxuryTax);

            spaces.AddRange(properties);

            return board;
        }

        public static IEnumerable<Property> CreateProperties(Banker banker)
        {
            var properties = new List<Property>();
            var purpleGroup = new List<Property>();
            var lightBlueGroup = new List<Property>();
            var violetGroup = new List<Property>();
            var orangeGroup = new List<Property>();
            var redGroup = new List<Property>();
            var yellowGroup = new List<Property>();
            var darkGreenGroup = new List<Property>();
            var darkBlueGroup = new List<Property>();
            var railroadGroup = new List<Property>();
            var utilitiesGroup = new List<Property>();

            var mediterraneanAvenue = new Property(MediterraneanAvenuePrice, MediterraneanAvenueRent, banker, purpleGroup);
            var balticAvenue = new Property(BalticAvenuePrice, BalticAvenueRent, banker, purpleGroup);
            var readingRailroad = new Property(RailroadPrice, BaseRailroadRent, banker, railroadGroup);
            var orientalAvenue = new Property(OrientalAvenuePrice, OrientalAvenueRent, banker, lightBlueGroup);
            var vermontAvenue = new Property(VermontAvenuePrice, VermontAvenueRent, banker, lightBlueGroup);
            var connecticutAvenue = new Property(ConnecticutAvenuePrice, ConnecticutAvenueRent, banker, lightBlueGroup);
            var stCharlesPlace = new Property(StCharlesPlacePrice, StCharlesPlaceRent, banker, violetGroup);
            var electricCompany = new Property(UtilityPrice, 0, banker, utilitiesGroup);
            var statesAvenue = new Property(StatesAvenuePrice, StatesAvenueRent, banker, violetGroup);
            var virginiaAvenue = new Property(VirginiaAvenuePrice, VirginiaAvenueRent, banker, violetGroup);
            var pennsylvaniaRailroad = new Property(RailroadPrice, BaseRailroadRent, banker, railroadGroup);
            var stJamesPlace = new Property(StJamesPlacePrice, StJamesPlaceRent, banker, orangeGroup);
            var tennesseeAvenue = new Property(TennesseeAvenuePrice, TennesseeAvenueRent, banker, orangeGroup);
            var newYorkAvenue = new Property(NewYorkAvenuePrice, NewYorkAvenueRent, banker, orangeGroup);
            var kentuckyAvenue = new Property(KentuckyAvenuePrice, KentuckyAvenueRent, banker, redGroup);
            var indianaAvenue = new Property(IndianaAvenuePrice, IndianaAvenueRent, banker, redGroup);
            var illinoisAvenue = new Property(IllinoisAvenuePrice, IllinoisAvenueRent, banker, redGroup);
            var boRailroad = new Property(RailroadPrice, BaseRailroadRent, banker, railroadGroup);
            var atlanticAvenue = new Property(AtlanticAvenuePrice, AtlanticAvenueRent, banker, yellowGroup);
            var ventnorAvenue = new Property(VentnorAvenuePrice, VentnorAvenueRent, banker, yellowGroup);
            var waterWorks = new Property(UtilityPrice, 0, banker, utilitiesGroup);
            var marvinGardens = new Property(MarvinGardensPrice, MarvinGardensRent, banker, yellowGroup);
            var pacificAvenue = new Property(PacificAvenuePrice, PacificAvenueRent, banker, darkGreenGroup);
            var northCarolinaAvenue = new Property(NorthCarolinaAvenuePrice, NorthCarolinaAvenueRent, banker, darkGreenGroup);
            var pennsylvaniaAvenue = new Property(PennsylvaniaAvenuePrice, PennsylvaniaAvenueRent, banker, darkGreenGroup);
            var shortLine = new Property(RailroadPrice, BaseRailroadRent, banker, railroadGroup);
            var parkPlace = new Property(ParkPlacePrice, ParkPlaceRent, banker, darkBlueGroup);
            var boardwalk = new Property(BoardwalkPrice, BoardwalkRent, banker, darkBlueGroup);

            properties.Add(mediterraneanAvenue);
            properties.Add(balticAvenue);
            properties.Add(readingRailroad);
            properties.Add(orientalAvenue);
            properties.Add(vermontAvenue);
            properties.Add(connecticutAvenue);
            properties.Add(stCharlesPlace);
            properties.Add(electricCompany);
            properties.Add(statesAvenue);
            properties.Add(virginiaAvenue);
            properties.Add(pennsylvaniaRailroad);
            properties.Add(stJamesPlace);
            properties.Add(tennesseeAvenue);
            properties.Add(newYorkAvenue);
            properties.Add(kentuckyAvenue);
            properties.Add(indianaAvenue);
            properties.Add(illinoisAvenue);
            properties.Add(boRailroad);
            properties.Add(atlanticAvenue);
            properties.Add(ventnorAvenue);
            properties.Add(waterWorks);
            properties.Add(marvinGardens);
            properties.Add(pacificAvenue);
            properties.Add(northCarolinaAvenue);
            properties.Add(pennsylvaniaAvenue);
            properties.Add(shortLine);
            properties.Add(parkPlace);
            properties.Add(boardwalk);

            return properties;
        }
    }
}