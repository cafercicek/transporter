
using System;
using System.Collections.Generic;

namespace Transporter6
{
    public static class ConfigParameter
    {
        //Game Start
        public const double GameStartMoney = 50000;
        
        public const int DriverGenerateNumber = 5;
        public const int GoodsGenerateNumber = 8;
        public const int TrucksGenerateNumber = 8;
        
        
        //Create Driver
        public static Dictionary<DriverClassification, String> DriverClassificationText = new Dictionary<DriverClassification, String>
        {
            {DriverClassification.ClassificationRacingDriver , "Rennfahrer"},
            {DriverClassification.ClassificationDreamyDriver , "Verträumt"},
            {DriverClassification.ClassificationHardDriver , "Liebt seinen Job"},
            {DriverClassification.ClassificationGhostDriver , "Unauffällig"}
            
        };

        

        public const int LessRandomSalaryOfDrivers = 2000;
        
        public const int HighestRandomSalaryOfDrivers = 5000;


        //Create Goods
        
        public const int BeginRandomNumberForFine = 50;
        public const int FinishRandomNumberForFine = 200;
        public const double PercentNumberForFine = 0.01;
        
        
        public const int ConstMaxWeightForCigarette = 10;
        public const int ConstMaxDayForCigarette = 20;
        public const int ConstMinPriceForCigarette = 100; 
        
        public const int ConstMaxWeightForTextile = 10;
        public const int ConstMaxDayForTextile = 20;
        public const int ConstMinPriceForTextile = 50;
        
        public const int ConstMaxWeightForChocolate = 10;
        public const int ConstMaxDayForChocolate = 10;
        public const int ConstMinPriceForChocolate = 120;

        public const int ConstMaxWeightForFruit = 6;
        public const int ConstMaxDayForFruit = 14;
        public const int ConstMinPriceForFruit = 150;
        
        public const int ConstMaxWeightForIceCream = 6;
        public const int ConstMaxDayForIceCream = 10;
        public const int ConstMinPriceForIceCream = 180;
        
        public const int ConstMaxWeightForMeat = 6;
        public const int ConstMaxDayForMeat = 14;
        public const int ConstMinPriceForMeat = 130;
        
                
        public const int ConstMaxWeightForCrude = 10;
        public const int ConstMaxDayForCrude = 14;
        public const int ConstMinPriceForCrude = 120;

        
        public const int ConstMaxWeightForFuel = 10;
        public const int ConstMaxDayForFuel = 25;
        public const int ConstMinPriceForFuel = 90;
        
        public const int ConstMaxWeightForGasoline = 10;
        public const int ConstMaxDayForGasoline = 28;
        public const int ConstMinPriceForGasoline = 80;
        
        
        //Create Truck
        public static Dictionary<TruckType, String> TruckTypeText = new Dictionary<TruckType, String>
        {
            {TruckType.TruckTypeFlatbedTruck , "Pritschenwagen"},
            {TruckType.TruckTypeTanker , "Tanklaster"},
            {TruckType.TruckTypeRefrigeratedTruck , "Kühllastwagen"}
            
        };
        
        public static Dictionary<TruckSize, String> TruckSizeText = new Dictionary<TruckSize, String>
        {
            {TruckSize.SmallTruckSize , "Klein"},
            {TruckSize.NormalTruckSize , "Medium"},
            {TruckSize.BigTruckSize , "Gross"},
            {TruckSize.HugeTruckSize , "Riesig"}
            
        };
        
        public static Dictionary<TruckSize, int> TruckSizeInTon = new Dictionary<TruckSize, int>
        {
            {TruckSize.SmallTruckSize ,2},
            {TruckSize.NormalTruckSize , 3},
            {TruckSize.BigTruckSize ,4},
            {TruckSize.HugeTruckSize , 5}
            
        };
        
        
        public const int RandomNumberYearForTruck = 11;
        public const int BeginRandomNumberTruckPower =10;
        public const int EndRandomNumberTruckPower =81;
        
        //Language 
        public const string TypeForTable = "Typ";
        public const string BasicPriceForTable = "Grundpreis";
        public const string SizeForTable = "Size";
        
        //MoveTruck
        public const int MaximalDriveHour = 8;
        public const int AverageKmPerHour = 70;
        public const double PowerPerTInKw = 7.5;
        public const int PriceForFuelInEuro = 1;
        
        public static Dictionary<DriverClassification, double> DriverKmFactorPerDay = new Dictionary<DriverClassification, double>
        {
            {DriverClassification.ClassificationRacingDriver ,1.3},
            {DriverClassification.ClassificationDreamyDriver ,0.7},
            {DriverClassification.ClassificationHardDriver , 1.1},
            {DriverClassification.ClassificationGhostDriver ,1.0}
            
        };
        
        
        
    }
}
