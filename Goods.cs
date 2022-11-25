using System;

namespace Transporter6
{
    public class Goods
    {
        internal string Name { set; get; }
        internal Truck Truck { set; get; }
        internal int  MaxWeight { set; get; }
        internal int  Weight { set; get; }
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
            Truck = new Truck
            {
                Type = "Pritschenwagen"
            };
            MaxWeight = 10;
            MaxDay = 20;
            MinPrice = 100;
        }
    }
    public class Textile :Goods
    {
        public Textile()
        {
            Name="Textilien";
            Truck = new Truck
            {
                Type = "Pritschenwagen"
            };
            MaxWeight = 10;
            MaxDay = 20;
            MinPrice = 50;
        }
    }
    public class Chocolate  :Goods
    {
        public Chocolate()
        {
            Name="Schokolade";
            Truck = new Truck
            {
                Type = "Pritschenwagen"
            };
            MaxWeight = 10;
            MaxDay = 10;
            MinPrice = 120;
        }

    }
    public class Fruit  :Goods
    {
        public Fruit()
        {
            Name="Früchte";
            Truck = new Truck
            {
                Type = "Kühllastwagen"
            };
            MaxWeight = 6;
            MaxDay = 14;
            MinPrice = 150;
        }

    }
    public class IceCream :Goods
    {
        public IceCream()
        {
            Name="Eiscreme";
            Truck = new Truck
            {
                Type = "Kühllastwagen"
            };
            MaxWeight = 6;
            MaxDay = 10;
            MinPrice = 180;
        }

    }
    public class Meat  :Goods
    {
        public Meat()
        {
            Name="Fleisch";
            Truck = new Truck
            {
                Type = "Kühllastwagen"
            };
            MaxWeight = 6;
            MaxDay = 14;
            MinPrice = 130;
        }

    }
    public class Crude  :Goods
    {
        public Crude()
        {
            Name="Rohoel";
            Truck = new Truck
            {
                Type = "Tanklaster"
            };
            MaxWeight = 10;
            MaxDay = 14;
            MinPrice = 120;
        }

    }
    public class Fuel  :Goods
    {
        public Fuel()
        {
            Name="Heizoel";
            Truck = new Truck
            {
                Type = "Tanklaster"
            };
            MaxWeight = 10;
            MaxDay = 25;
            MinPrice = 90;
        }

    }
    public class Gasoline  :Goods
    {
        public Gasoline()
        {
            Name="Benzin";
            Truck = new Truck
            {
                Type = "Tanklaster"
            };
            MaxWeight = 10;
            MaxDay = 28;
            MinPrice = 80;
        }
    }
}