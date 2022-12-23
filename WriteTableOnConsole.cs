using System;
using System.Collections.Generic;
using System.Linq;

namespace Transporter6
{
    public class WriteTableOnConsole
    {
        public static void WriteAllDriverOnConsole(List<Driver> drivers)
        {
            var tablePrinter = new TablePrinter("#", "Fahrer", "Gehalt",
                "Typ");
            AddDriversOfTable(drivers, tablePrinter);

            tablePrinter.Print();
        }

        private static void AddDriversOfTable(List<Driver> drivers, TablePrinter tablePrinter)
        {
            var index = 1;
            foreach (var x in drivers)
            {
                tablePrinter.AddRow($"{index++}", $"{x.Firstname} {x.Lastname}", $"{x.Salary:0.00} EUR",
                    $"{x.ClassificationOfDriverText}");
            }
        }

        public static void WriteGoodsOnConsole(List<Goods> goods)
        {
            var tablePrinter = new TablePrinter("#", "Ware", "Typ", "Startort",
                "Zeilort", "Gewicht", "Liefererdatum", "Verguetung", "Strafe");
            AddGoodsOfTable(goods, tablePrinter);

            tablePrinter.Print();
        }
        
        public static void WriteAllCitiesOnConsole(List<City> cities)
        {//Amsterdam = Easting: 868851 / Northing: 297477
            var tablePrinter = new TablePrinter("#", "Name", "Easting", "Northing");
            AddCitysOfTable(cities, tablePrinter);

            tablePrinter.Print();
        }

        private static void AddCitysOfTable(List<City> cities, TablePrinter tablePrinter)
        {
            var index = 1;
            foreach (var x in cities)
            {
                tablePrinter.AddRow($"{index++}", $"{x.Name}", $"{x.XEasting}", $"{x.YNorthing}");
            }
        }


        private static void AddGoodsOfTable(List<Goods> goods, TablePrinter tablePrinter)
        {
            var index = 1;
            foreach (var x in goods)
            {
                var deliveryDayDisplay = x.DeliveryDateTime.ToString("dd.MM.yyyy");

                tablePrinter.AddRow($"{index++}", $"{x.Name}", $"{x.SuitableTruck.TypeOnConsole}", $"{x.StartPoint.Name}",
                    $"{x.StopPoint.Name}", $"{x.Weight} T", $"{deliveryDayDisplay}",
                    $"{x.Payment:0.00} EUR ", $"{x.Fine:0.00} EUR");
            }
        }

        public static void WriteTrucksOnConsole(List<Truck> trucks)
        {
            var tablePrinter = new TablePrinter("#", "Typ", "Alter",
                "Leistung", "Zuladung", "Verbrauch", "Preis", "Ort", "Unterwegs", "Fahrer");
            AddTrucksOfTable(trucks, tablePrinter);

            tablePrinter.Print();
        }

        private static void AddTrucksOfTable(List<Truck> trucks, TablePrinter tablePrinter)
        {
            var index = 1;
            foreach (var x in trucks)
            {
                var textForOnTheWay = x.DaysOnTheWay.ToString();
                var nameOfDriver = " ";
                if(x.DaysOnTheWay >0 ) textForOnTheWay = x.DaysOnTheWay.ToString();
                if(x.Driver != null) nameOfDriver = $"{x.Driver.Firstname} {x.Driver.Lastname}";
                tablePrinter.AddRow($"{index++}", $"{x.TypeOnConsole}", $"{x.Year} Jahre", $"{x.PowerInkW} kW",
                    $"{x.MaxLoad} T", $"{x.FuelEfficiencyDivideBy100Km} L",
                    $"{x.Price:0.00} EUR ", $"{x.CurrentCity.Name} ",$"{textForOnTheWay} ", $"{nameOfDriver} " );
            }
        }
        public static void WriteTrucksOnConsole(Truck truck)
        {
            var tablePrinter = new TablePrinter("#", "Typ", "Alter",
                "Leistung", "Zuladung", "Verbrauch", "Preis", "Ort", "Unterwegs", "Fahrer");
            AddTrucksOfTable(truck, tablePrinter);

            tablePrinter.Print();
        }
        private static void AddTrucksOfTable(Truck truck, TablePrinter tablePrinter)
        {
            const int index = 1;
            var textForOnTheWay = truck.DaysOnTheWay.ToString();
            var nameOfDriver = " ";
            if(truck.DaysOnTheWay >0 ) textForOnTheWay = truck.DaysOnTheWay.ToString();
            if(truck.Driver != null) nameOfDriver = $"{truck.Driver.Firstname} {truck.Driver.Lastname}";
            tablePrinter.AddRow($"{index}", $"{truck.TypeOnConsole}", $"{truck.Year} Jahre", $"{truck.PowerInkW} kW",
                    $"{truck.MaxLoad} T", $"{truck.FuelEfficiencyDivideBy100Km} L",
                    $"{truck.Price:0.00} EUR ", $"{truck.CurrentCity.Name} ",$"{textForOnTheWay} ", $"{nameOfDriver} ");
        }


        public void WriteTextInColorBox(string text,ConsoleColor background, ConsoleColor foreground, int countForLoop )
        {
            Console.BackgroundColor = background;
            
            Console.ForegroundColor = foreground;
            
            Console.Write("\n\t\t\t");
            
            foreach (var _ in Enumerable.Range(0, countForLoop)) Console.Write("#");
            
            Console.Write("\t\t\t\n");
            
            Console.Write($"\t\t\t#{text}#\t\t\t");
            
            Console.Write("\n\t\t\t");
            
            foreach (var _ in Enumerable.Range(0, countForLoop)) Console.Write("#");
            
            Console.Write("\t\t\t\n");
            Console.ResetColor();
        }
        
        
        public void WriteWarningOnConsole()
        {
            Console.Clear();
            WriteTextInColorBox("Ungültige Eingabe", ConsoleColor.Red, ConsoleColor.White, 19);
        }


        public static void WriteInfoOnConsoleForNewRound(Company company, Truck truck,double fuelConsume)
        {
            Console.WriteLine($"Der Benzinverbrauch ist {fuelConsume:0.00} EUR ");
            Console.WriteLine($"Aktueller Kontozustand ist {company.Amount:0.00} EUR ");
            Console.WriteLine($"{truck.TypeOnConsole} wurde in {truck.TargetCity.Name} erreicht. ");
            
        }
    }
}