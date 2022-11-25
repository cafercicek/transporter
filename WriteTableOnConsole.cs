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
                    $"{x.ClassificationOfDriver}");
            }
        }

        public static void WriteGoodsOnConsole(List<Goods> goods)
        {
            var tablePrinter = new TablePrinter("#", "Ware", "Typ", "Startort",
                "Zeilort", "Gewicht", "Liefererdatum", "Verguetung", "Strafe");
            AddGoodsOfTable(goods, tablePrinter);

            tablePrinter.Print();
        }

        private static void AddGoodsOfTable(List<Goods> goods, TablePrinter tablePrinter)
        {
            var index = 1;
            foreach (var x in goods)
            {
                var deliveryDayDisplay = x.DeliveryDateTime.ToString("dd.MM.yyyy");

                tablePrinter.AddRow($"{index++}", $"{x.Name}", $"{x.Truck.Type}", $"{x.StartPoint.Name}",
                    $"{x.StopPoint.Name}", $"{x.Weight} T", $"{deliveryDayDisplay}",
                    $"{x.Payment:0.00} EUR ", $"{x.Fine:0.00} EUR");
            }
        }

        public static void WriteTrucksOnConsole(List<Truck> trucks)
        {
            var tablePrinter = new TablePrinter("#", "Typ", "Alter",
                "Leistung", "Zuladung", "Verbrauch", "Preis", "Ort");
            AddTrucksOfTable(trucks, tablePrinter);

            tablePrinter.Print();
        }

        private static void AddTrucksOfTable(List<Truck> trucks, TablePrinter tablePrinter)
        {
            var index = 1;
            foreach (var x in trucks)
            {
                tablePrinter.AddRow($"{index++}", $"{x.Type}", $"{x.Year} Jahre", $"{x.PowerInkW} kW",
                    $"{x.MaxLoad} T", $"{x.FuelEfficiencyDivideBy100Km} L",
                    $"{x.Price:0.00} EUR ", $"{x.City.Name} ");
            }
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
    }
}