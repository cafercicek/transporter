using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace Transporter6
{
    public class GenerateRandomTrucker
    {
        public List<Truck> FillListOfTrucks()
        {
            var listOfCities = new GetAllCitiesFromFile().GetListOfCities();
            
            return Enumerable.Range(0, 8).Select(_ => CreateATruck(listOfCities)).ToList();
        }


        private static Truck CreateATruck(List<City> listOfCities)
        {
            var truck = new Truck
            {
                Type = GetTypeForTruck(),
                City = GetCityForTruck(listOfCities),
                Year = GetYearForTruck(),
                PowerInkW = CalculateRandomTruckPower()
            };
            truck.CalculateTheSizeOfTruck();
            
            GenerateMaxLoadOfTruck(truck);
            
            FindFuelEfficiency(truck);
            
            CalculatePriceOfTrucks(truck);
            
            return truck;
        }


        private static void GenerateMaxLoadOfTruck(Truck truck)
        {
            var table = MakeATableOfLoading();
            
            var filteredRows = table.Select("Type LIKE '%" + truck.Type + "%'");
            
            var matchLoad = filteredRows[0][truck.Size];
           
            truck.MaxLoad = Convert.ToInt32(matchLoad);
        }

        private static DataTable MakeATableOfLoading()
        {
            var table = new DataTable();
            table.Columns.Add("Type", typeof(string));
            table.Columns.Add("Klein", typeof(int));
            table.Columns.Add("Medium", typeof(int));
            table.Columns.Add("Gross", typeof(int));
            table.Columns.Add("Riesig", typeof(int));

            table.Rows.Add("Pritschenwagen", 4, 6, 7, 10);
            table.Rows.Add("Tanklaster", 2, 4, 8, 10);
            table.Rows.Add("Kühllastwagen", 3, 4, 5, 6);
            return table;
        }

        private static void FindFuelEfficiency(Truck truck)
        {
            var table = MakeATableOfFuelEfficiency();
            
            var filteredRows = table.Select("Type LIKE '%" + truck.Type + "%'");
            
            var matchLoad = filteredRows[0][truck.Size];
           
            var howMany3Year = truck.Year % 3;
            
            truck.FuelEfficiencyDivideBy100Km = Convert.ToInt32(matchLoad) + howMany3Year;
        }

        private static DataTable MakeATableOfFuelEfficiency()
        {
            var table = new DataTable();
            table.Columns.Add("Type", typeof(string));
            table.Columns.Add("Klein", typeof(int));
            table.Columns.Add("Medium", typeof(int));
            table.Columns.Add("Gross", typeof(int));
            table.Columns.Add("Riesig", typeof(int));

            table.Rows.Add("Pritschenwagen", 10, 12, 16, 22);
            table.Rows.Add("Tanklaster", 14, 18, 20, 30);
            table.Rows.Add("Kühllastwagen", 14, 18, 20, 30);
            return table;
        }

        private static void CalculatePriceOfTrucks(Truck truck)
        {
            var table = MakeATableOfBasicPrice();
            
            var filteredRows = table.Select("Size LIKE '%" + truck.Size + "%'");
            
            var priceFactor = CalculatePriceOfFactor(truck);
            
            var matchBasicPrice = filteredRows[0]["BasicPreise"];
            
            truck.Price = priceFactor * (double)matchBasicPrice;
           
            if (truck.Type == "Kühllastwagen") truck.Price *= 1.1;
        }

        private static double CalculatePriceOfFactor(Truck truck)
        {
            var rand = new Random();
            var randomNumber = rand.Next(-20, 30);
            return (1 + randomNumber / 100.0) - truck.Year * 0.03;
        }

        private static DataTable MakeATableOfBasicPrice()
        {
            var table = new DataTable();
            
            table.Columns.Add("Size", typeof(string));
            
            table.Columns.Add("BasicPreise", typeof(double));

            table.Rows.Add("Klein", 25000);
            
            table.Rows.Add("Medium", 65000);
            
            table.Rows.Add("Gross", 80000);
            
            table.Rows.Add("Riesig", 120000);
            return table;
        }

        private static int CalculateRandomTruckPower()
        {
            var rand = new Random();
            return rand.Next(10, 81);
        }

        private static int GetYearForTruck()
        {
            var rand = new Random();
            return rand.Next(0, 11);
        }

        private static City GetCityForTruck(IReadOnlyList<City> listOfCities)
        {
            var rand = new Random();
            
            return listOfCities[rand.Next(0, listOfCities.Count)];
        }

        private static string GetTypeForTruck()
        {
            var typeForTruck = new List<string>
            {
                "Kühllastwagen",
                "Pritschenwagen",
                "Tanklaster"
            };
            return TakeARandomText(typeForTruck);
        }


        private static string TakeARandomText(IReadOnlyList<string> listOfText)
        {
            var rand = new Random();
            
            return listOfText[rand.Next(0, listOfText.Count)];
        }
        
    }
}