using System;
using System.Collections.Generic;
using System.Linq;
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

        public const Int32 GoIndex = 0;
        public const Int32 MediterraneanAvenueIndex = 1;
        public const Int32 CommunityChestOneIndex = 2;
        public const Int32 BalticAvenueIndex = 3;
        public const Int32 IncomeTaxIndex = 4;
        public const Int32 ReadingRailroadIndex = 5;
        public const Int32 OrientalAvenueIndex = 6;
        public const Int32 ChanceOneIndex = 7;
        public const Int32 VermontAvenueIndex = 8;
        public const Int32 ConnecticutAvenueIndex = 9;
        public const Int32 JustVisitingLocation = 10;
        public const Int32 StCharlesPlaceIndex = 11;
        public const Int32 ElectricCompanyIndex = 12;
        public const Int32 StatesAvenueIndex = 13;
        public const Int32 VirginiaAvenueIndex = 14;
        public const Int32 PennsylvaniaRailroadIndex = 15;
        public const Int32 StJamesPlaceIndex = 16;
        public const Int32 CommunityChestTwoIndex = 17;
        public const Int32 TennesseeAvenueIndex = 18;
        public const Int32 NewYorkAvenueIndex = 19;
        public const Int32 FreeParkingIndex = 20;
        public const Int32 KentuckyAvenueIndex = 21;
        public const Int32 ChanceTwoIndex = 22;
        public const Int32 IndianaAvenueIndex = 23;
        public const Int32 IllinoisAvenueIndex = 24;
        public const Int32 BoRailroadIndex = 25;
        public const Int32 AtlanticAvenueIndex = 26;
        public const Int32 VentnorAvenueIndex = 27;
        public const Int32 WaterWorksIndex = 28;
        public const Int32 MarvinGardensIndex = 29;
        public const Int32 GoToJailIndex = 30;
        public const Int32 PacificAvenueIndex = 31;
        public const Int32 NorthCarolinaAvenueIndex = 32;
        public const Int32 CommunityChestThreeIndex = 33;
        public const Int32 PennsylvaniaAvenueIndex = 34;
        public const Int32 ShortLineIndex = 35;
        public const Int32 ChanceThreeIndex = 36;
        public const Int32 ParkPlaceIndex = 37;
        public const Int32 LuxuryTaxIndex = 38;
        public const Int32 BoardwalkIndex = 39;
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

            var go = new Space(GoIndex);
            var communityChestOne = new Space(CommunityChestOneIndex);
            var incomeTax = new IncomeTax(IncomeTaxIndex, IncomeTaxPercentage, MaximumIncomeTaxPaymentAmount, banker);
            var chanceOne = new Space(ChanceOneIndex);
            var justVisiting = new Space(JustVisitingLocation);
            var communityChestTwo = new Space(CommunityChestTwoIndex);
            var freeParking = new Space(FreeParkingIndex);
            var chanceTwo = new Space(ChanceTwoIndex);
            var goToJail = new GoToJail(GoToJailIndex, JustVisitingLocation, board);
            var communityChestThree = new Space(CommunityChestThreeIndex);
            var chanceThree = new Space(ChanceThreeIndex);
            var luxuryTax = new LuxuryTax(LuxuryTaxIndex, LuxuryTaxPaymentAmount, banker);

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
            var mediterraneanAvenue = new Property(MediterraneanAvenueIndex, MediterraneanAvenuePrice, MediterraneanAvenueRent, PurpleGroup, banker, propertyManager);
            var balticAvenue = new Property(BalticAvenueIndex, BalticAvenuePrice, BalticAvenueRent, PurpleGroup, banker, propertyManager);
            var readingRailroad = new Property(ReadingRailroadIndex, RailroadPrice, BaseRailroadRent, RailroadGroup, banker, propertyManager);
            var orientalAvenue = new Property(OrientalAvenueIndex, OrientalAvenuePrice, OrientalAvenueRent, LightBlueGroup, banker, propertyManager);
            var vermontAvenue = new Property(VermontAvenueIndex, VermontAvenuePrice, VermontAvenueRent, LightBlueGroup, banker, propertyManager);
            var connecticutAvenue = new Property(ConnecticutAvenueIndex, ConnecticutAvenuePrice, ConnecticutAvenueRent, LightBlueGroup, banker, propertyManager);
            var stCharlesPlace = new Property(StCharlesPlaceIndex, StCharlesPlacePrice, StCharlesPlaceRent, VioletGroup, banker, propertyManager);
            var electricCompany = new Property(ElectricCompanyIndex, UtilityPrice, 0, UtilityGroup, banker, propertyManager);
            var statesAvenue = new Property(StatesAvenueIndex, StatesAvenuePrice, StatesAvenueRent, VioletGroup, banker, propertyManager);
            var virginiaAvenue = new Property(VirginiaAvenueIndex, VirginiaAvenuePrice, VirginiaAvenueRent, VioletGroup, banker, propertyManager);
            var pennsylvaniaRailroad = new Property(PennsylvaniaRailroadIndex, RailroadPrice, BaseRailroadRent, RailroadGroup, banker, propertyManager);
            var stJamesPlace = new Property(StJamesPlaceIndex, StJamesPlacePrice, StJamesPlaceRent, OrangeGroup, banker, propertyManager);
            var tennesseeAvenue = new Property(TennesseeAvenueIndex, TennesseeAvenuePrice, TennesseeAvenueRent, OrangeGroup, banker, propertyManager);
            var newYorkAvenue = new Property(NewYorkAvenueIndex, NewYorkAvenuePrice, NewYorkAvenueRent, OrangeGroup, banker, propertyManager);
            var kentuckyAvenue = new Property(KentuckyAvenueIndex, KentuckyAvenuePrice, KentuckyAvenueRent, RedGroup, banker, propertyManager);
            var indianaAvenue = new Property(IndianaAvenueIndex, IndianaAvenuePrice, IndianaAvenueRent, RedGroup, banker, propertyManager);
            var illinoisAvenue = new Property(IllinoisAvenueIndex, IllinoisAvenuePrice, IllinoisAvenueRent, RedGroup, banker, propertyManager);
            var boRailroad = new Property(BoRailroadIndex, RailroadPrice, BaseRailroadRent, RailroadGroup, banker, propertyManager);
            var atlanticAvenue = new Property(AtlanticAvenueIndex, AtlanticAvenuePrice, AtlanticAvenueRent, YellowGroup, banker, propertyManager);
            var ventnorAvenue = new Property(VentnorAvenueIndex, VentnorAvenuePrice, VentnorAvenueRent, YellowGroup, banker, propertyManager);
            var waterWorks = new Property(WaterWorksIndex, UtilityPrice, 0, UtilityGroup, banker, propertyManager);
            var marvinGardens = new Property(MarvinGardensIndex, MarvinGardensPrice, MarvinGardensRent, YellowGroup, banker, propertyManager);
            var pacificAvenue = new Property(PacificAvenueIndex, PacificAvenuePrice, PacificAvenueRent, DarkGreenGroup, banker, propertyManager);
            var northCarolinaAvenue = new Property(NorthCarolinaAvenueIndex, NorthCarolinaAvenuePrice, NorthCarolinaAvenueRent, DarkGreenGroup, banker, propertyManager);
            var pennsylvaniaAvenue = new Property(PennsylvaniaAvenueIndex, PennsylvaniaAvenuePrice, PennsylvaniaAvenueRent, DarkGreenGroup, banker, propertyManager);
            var shortLine = new Property(ShortLineIndex, RailroadPrice, BaseRailroadRent, RailroadGroup, banker, propertyManager);
            var parkPlace = new Property(ParkPlaceIndex, ParkPlacePrice, ParkPlaceRent, DarkBlueGroup, banker, propertyManager);
            var boardwalk = new Property(BoardwalkIndex, BoardwalkPrice, BoardwalkRent, DarkBlueGroup, banker, propertyManager);
            
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