using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Transporter6
{
    public class GenerateRandomTrucker
    {
        public List<Truck> FillListOfTrucks()
        {
            var listOfCities = new GetAllCitiesFromFile().GetListOfCities();
            
            return Enumerable.Range(0, ConfigParameter.TrucksGenerateNumber).Select(_ => CreateATruck(listOfCities)).ToList();
        }


        private static Truck CreateATruck(List<City> listOfCities)
        {
            var truck = new Truck
            {
                Type = GetTypeForTruck(),
                CurrentCity = GetCityForTruck(listOfCities),
                Year = GetYearForTruck(),
                PowerInkW = CalculateRandomTruckPower()
                
            };
           
            CalculateTheSizeOfTruck(truck);
            
            GenerateMaxLoadOfTruck(truck);
            
            FindFuelEfficiency(truck);
            
            CalculatePriceOfTrucks(truck);
            
            truck.Capacity = truck.MaxLoad;
            
            truck.TypeOnConsole = ConfigParameter.TruckTypeText[truck.Type];
            
            return truck;
        }


        private static void CalculateTheSizeOfTruck(Truck truck)
        {

            if (9 < truck.PowerInkW && truck.PowerInkW < 26) truck.Size = TruckSize.SmallTruckSize;
            
            else if (25 < truck.PowerInkW && truck.PowerInkW < 51) truck.Size = TruckSize.NormalTruckSize;
            
            else if (50 < truck.PowerInkW && truck.PowerInkW < 66)  truck.Size =  TruckSize.BigTruckSize;
            
            else if (65 < truck.PowerInkW && truck.PowerInkW < 81)  truck.Size =  TruckSize.HugeTruckSize;

            truck.SizeText = ConfigParameter.TruckSizeText[ truck.Size];

        }

        private static void GenerateMaxLoadOfTruck(Truck truck)
        {
            var table = MakeATableOfLoading();
            
            var filteredRows = table.Select($"{ConfigParameter.TypeForTable} LIKE '%" + truck.TypeOnConsole + "%'");
            
            var matchLoad = filteredRows[0][truck.SizeText];
           
            truck.MaxLoad = Convert.ToInt32(matchLoad);
        }

        private static DataTable MakeATableOfLoading()
        {
            var table = new DataTable();
            table.Columns.Add(ConfigParameter.TypeForTable , typeof(string));
            table.Columns.Add(ConfigParameter.TruckSizeText[TruckSize.SmallTruckSize], typeof(int));
            table.Columns.Add(ConfigParameter.TruckSizeText[TruckSize.NormalTruckSize], typeof(int));
            table.Columns.Add(ConfigParameter.TruckSizeText[TruckSize.BigTruckSize], typeof(int));
            table.Columns.Add(ConfigParameter.TruckSizeText[TruckSize.HugeTruckSize], typeof(int));
            
            table.Rows.Add(TruckType.TruckTypeFlatbedTruck, 4, 6, 7, 10);
            table.Rows.Add(TruckType.TruckTypeTanker, 2, 4, 8, 10);
            table.Rows.Add(TruckType.TruckTypeRefrigeratedTruck, 3, 4, 5, 6);
            return table;
        }

        private static void FindFuelEfficiency(Truck truck)
        {
            var table = MakeATableOfFuelEfficiency();
            
            var filteredRows = table.Select($"{ConfigParameter.TypeForTable} LIKE '%" + truck.TypeOnConsole + "%'");

           
            var matchLoad = filteredRows[0][truck.SizeText];
           
            var howMany3Year = truck.Year % 3;
            
            truck.FuelEfficiencyDivideBy100Km = Convert.ToInt32(matchLoad) + howMany3Year;
        }

        private static DataTable MakeATableOfFuelEfficiency()
        {
            var table = new DataTable();
            table.Columns.Add(ConfigParameter.TypeForTable , typeof(string));
            
            table.Columns.Add(ConfigParameter.TruckSizeText[TruckSize.SmallTruckSize], typeof(int));
            table.Columns.Add(ConfigParameter.TruckSizeText[TruckSize.NormalTruckSize], typeof(int));
            table.Columns.Add(ConfigParameter.TruckSizeText[TruckSize.BigTruckSize], typeof(int));
            table.Columns.Add(ConfigParameter.TruckSizeText[TruckSize.HugeTruckSize], typeof(int));
            
            table.Rows.Add(TruckType.TruckTypeFlatbedTruck, 10, 12, 16, 22);
            table.Rows.Add(TruckType.TruckTypeTanker, 14, 18, 20, 30);
            table.Rows.Add(TruckType.TruckTypeRefrigeratedTruck, 14, 18, 20, 30);
            return table;
        }

        private static void CalculatePriceOfTrucks(Truck truck)
        {
            var table = MakeATableOfBasicPrice();
            
            
            var filteredRows = table.Select($"{ConfigParameter.SizeForTable} LIKE '%" + truck.SizeText + "%'");

            var priceFactor = CalculatePriceOfFactor(truck);
            
            var matchBasicPrice = filteredRows[0][ConfigParameter.BasicPriceForTable];
            
            truck.Price = priceFactor * (double)matchBasicPrice;
           
            if (truck.Type == TruckType.TruckTypeRefrigeratedTruck) truck.Price *= 1.1;
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
            
            table.Columns.Add(ConfigParameter.SizeForTable, typeof(string));
            
            table.Columns.Add(ConfigParameter.BasicPriceForTable, typeof(double));

            table.Rows.Add(ConfigParameter.TruckSizeText[TruckSize.SmallTruckSize], 25000);
            
            table.Rows.Add(ConfigParameter.TruckSizeText[TruckSize.NormalTruckSize], 65000);
            
            table.Rows.Add(ConfigParameter.TruckSizeText[TruckSize.BigTruckSize], 80000);
            
            table.Rows.Add(ConfigParameter.TruckSizeText[TruckSize.HugeTruckSize], 120000);
            return table;
        }

        
        
        private static int CalculateRandomTruckPower()
        {
            var rand = new Random();
            return rand.Next(ConfigParameter.BeginRandomNumberTruckPower, ConfigParameter.EndRandomNumberTruckPower);
        }

        private static int GetYearForTruck()
        {
            var rand = new Random();
            return rand.Next(0, ConfigParameter.RandomNumberYearForTruck);
        }

        private static City GetCityForTruck(IReadOnlyCollection<City> listOfCities)
        {
            var rand = new Random();
            return listOfCities.ElementAt(rand.Next(0, listOfCities.Count));
        }


        private static TruckType GetTypeForTruck()
        {
            var typeForTruck = new List<TruckType>
            {
                TruckType.TruckTypeRefrigeratedTruck,
                TruckType.TruckTypeFlatbedTruck,
                TruckType.TruckTypeTanker
            };
            return TakeARandomText(typeForTruck);
            
        }
        private static TruckType TakeARandomText(IReadOnlyList<TruckType> listOfText)
        {
            var rand = new Random();
            
            return listOfText[rand.Next(0, listOfText.Count)];
        }

        
    }
}
