using System;

namespace Transporter6
{
    public class Goods
    {
        internal string Name { set; get; }
        internal Truck SuitableTruck { set; get; }
        internal int  MaxWeight { set; get; }
        internal int  Weight { set; get; }
        internal bool CheckTruck { set; get; } = false;
        public static int IdentificationNumberCounter = 1;
        internal  int IdNumber;
        internal City StartPoint { set; get; }
        internal City StopPoint { set; get; }
        internal int DeliveryDay{ set; get; }
        internal DateTime DeliveryDateTime { set; get; }
        internal int  MaxDay { set; get; }
        internal int MinPrice { set; get; }
        internal double Payment { set; get; }
        internal double Fine { set; get; }
        
    }
    public class Cigarette :Goods
    {
        public Cigarette()
        {
            Name="Zigaretten";
            SuitableTruck = new Truck
            {
                Type =  TruckType.TruckTypeFlatbedTruck
            };
            MaxWeight = ConfigParameter.ConstMaxWeightForCigarette;
            MaxDay = ConfigParameter.ConstMaxDayForCigarette;
            MinPrice = ConfigParameter.ConstMinPriceForCigarette;
            
    }
    }
    public class Textile :Goods
    {
        public Textile()
        {
            Name="Textilien";
            SuitableTruck = new Truck
            {
                Type =  TruckType.TruckTypeFlatbedTruck
            };
            MaxWeight = ConfigParameter.ConstMaxWeightForTextile;
            MaxDay = ConfigParameter.ConstMaxDayForTextile;
            MinPrice = ConfigParameter.ConstMinPriceForTextile;
        }
    }
    public class Chocolate  :Goods
    {
        public Chocolate()
        {
            Name="Schokolade";
            SuitableTruck = new Truck
            {
                Type = TruckType.TruckTypeFlatbedTruck
            };
            MaxWeight = ConfigParameter.ConstMaxWeightForChocolate;
            MaxDay = ConfigParameter.ConstMaxDayForChocolate;
            MinPrice = ConfigParameter.ConstMinPriceForChocolate;
        }

    }
    public class Fruit  :Goods
    {
        public Fruit()
        {
            Name="Früchte";
            SuitableTruck = new Truck
            {
                Type =  TruckType.TruckTypeRefrigeratedTruck
            };
            MaxWeight = ConfigParameter.ConstMaxWeightForFruit;
            MaxDay = ConfigParameter.ConstMaxDayForFruit;
            MinPrice = ConfigParameter.ConstMinPriceForFruit;
        }

    }
    public class IceCream :Goods
    {
        public IceCream()
        {
            Name="Eiscreme";
            SuitableTruck = new Truck
            {
                Type =  TruckType.TruckTypeRefrigeratedTruck
            };
            MaxWeight = ConfigParameter.ConstMaxWeightForIceCream;
            MaxDay = ConfigParameter.ConstMaxDayForIceCream;
            MinPrice = ConfigParameter.ConstMinPriceForIceCream;
        }

    }
    public class Meat  :Goods
    {
        public Meat()
        {
            Name="Fleisch";
            SuitableTruck = new Truck
            {
                Type =  TruckType.TruckTypeRefrigeratedTruck
            };
            MaxWeight = ConfigParameter.ConstMaxWeightForMeat;
            MaxDay = ConfigParameter.ConstMaxDayForMeat;
            MinPrice = ConfigParameter.ConstMinPriceForMeat;
        }

    }
    public class Crude  :Goods
    {
        public Crude()
        {
            Name="Rohoel";
            SuitableTruck = new Truck
            {
                Type = TruckType.TruckTypeTanker
            };
            MaxWeight = ConfigParameter.ConstMaxWeightForCrude;
            MaxDay = ConfigParameter.ConstMaxDayForCrude;
            MinPrice = ConfigParameter.ConstMinPriceForCrude;
            
        }

    }
    public class Fuel  :Goods
    {
        public Fuel()
        {
            Name="Heizoel";
            SuitableTruck = new Truck
            {
                Type = TruckType.TruckTypeTanker
            };
            
            MaxWeight = ConfigParameter.ConstMaxWeightForFuel;
            MaxDay = ConfigParameter.ConstMaxDayForFuel;
            MinPrice = ConfigParameter.ConstMinPriceForFuel;
        }

    }
    public class Gasoline  :Goods
    {
        public Gasoline()
        {
            Name="Benzin";
            SuitableTruck = new Truck
            {
                Type = TruckType.TruckTypeTanker
            };
            MaxWeight = ConfigParameter.ConstMaxWeightForGasoline;
            MaxDay = ConfigParameter.ConstMaxDayForGasoline;
            MinPrice = ConfigParameter.ConstMinPriceForGasoline;
        }
    }
}