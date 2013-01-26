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

        public const String PurpleGroup = "Purple";
        public const String LightBlueGroup = "LightBlue";
        public const String VioletGroup = "Violet";
        public const String OrangeGroup = "Orange";
        public const String RedGroup = "Red";
        public const String YellowGroup = "Yellow";
        public const String DarkGreenGroup = "DarkGreen";
        public const String DarkBlueGroup = "DarkBlue";
        public const String RailroadGroup = "Railroad";
        public const String UtilityGroup = "Utility";

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

        public static IEnumerable<Property> CreateProperties(Banker banker, PropertyManager propertyManager)
        {
            var mediterraneanAvenue = new Property(MediterraneanAvenuePrice, MediterraneanAvenueRent, PurpleGroup, banker, propertyManager);
            var balticAvenue = new Property(BalticAvenuePrice, BalticAvenueRent, PurpleGroup, banker, propertyManager);
            var readingRailroad = new Property(RailroadPrice, BaseRailroadRent, RailroadGroup, banker, propertyManager);
            var orientalAvenue = new Property(OrientalAvenuePrice, OrientalAvenueRent, LightBlueGroup, banker, propertyManager);
            var vermontAvenue = new Property(VermontAvenuePrice, VermontAvenueRent, LightBlueGroup, banker, propertyManager);
            var connecticutAvenue = new Property(ConnecticutAvenuePrice, ConnecticutAvenueRent, LightBlueGroup, banker, propertyManager);
            var stCharlesPlace = new Property(StCharlesPlacePrice, StCharlesPlaceRent, VioletGroup, banker, propertyManager);
            var electricCompany = new Property(UtilityPrice, 0, UtilityGroup, banker, propertyManager);
            var statesAvenue = new Property(StatesAvenuePrice, StatesAvenueRent, VioletGroup, banker, propertyManager);
            var virginiaAvenue = new Property(VirginiaAvenuePrice, VirginiaAvenueRent, VioletGroup, banker, propertyManager);
            var pennsylvaniaRailroad = new Property(RailroadPrice, BaseRailroadRent, RailroadGroup, banker, propertyManager);
            var stJamesPlace = new Property(StJamesPlacePrice, StJamesPlaceRent, OrangeGroup, banker, propertyManager);
            var tennesseeAvenue = new Property(TennesseeAvenuePrice, TennesseeAvenueRent, OrangeGroup, banker, propertyManager);
            var newYorkAvenue = new Property(NewYorkAvenuePrice, NewYorkAvenueRent, OrangeGroup, banker, propertyManager);
            var kentuckyAvenue = new Property(KentuckyAvenuePrice, KentuckyAvenueRent, RedGroup, banker, propertyManager);
            var indianaAvenue = new Property(IndianaAvenuePrice, IndianaAvenueRent, RedGroup, banker, propertyManager);
            var illinoisAvenue = new Property(IllinoisAvenuePrice, IllinoisAvenueRent, RedGroup, banker, propertyManager);
            var boRailroad = new Property(RailroadPrice, BaseRailroadRent, RailroadGroup, banker, propertyManager);
            var atlanticAvenue = new Property(AtlanticAvenuePrice, AtlanticAvenueRent, YellowGroup, banker, propertyManager);
            var ventnorAvenue = new Property(VentnorAvenuePrice, VentnorAvenueRent, YellowGroup, banker, propertyManager);
            var waterWorks = new Property(UtilityPrice, 0, UtilityGroup, banker, propertyManager);
            var marvinGardens = new Property(MarvinGardensPrice, MarvinGardensRent, YellowGroup, banker, propertyManager);
            var pacificAvenue = new Property(PacificAvenuePrice, PacificAvenueRent, DarkGreenGroup, banker, propertyManager);
            var northCarolinaAvenue = new Property(NorthCarolinaAvenuePrice, NorthCarolinaAvenueRent, DarkGreenGroup, banker, propertyManager);
            var pennsylvaniaAvenue = new Property(PennsylvaniaAvenuePrice, PennsylvaniaAvenueRent, DarkGreenGroup, banker, propertyManager);
            var shortLine = new Property(RailroadPrice, BaseRailroadRent, RailroadGroup, banker, propertyManager);
            var parkPlace = new Property(ParkPlacePrice, ParkPlaceRent, DarkBlueGroup, banker, propertyManager);
            var boardwalk = new Property(BoardwalkPrice, BoardwalkRent, DarkBlueGroup, banker, propertyManager);
            
            var properties = new List<Property>();
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