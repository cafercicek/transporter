using System;
using System.Linq;

namespace Transporter6
{
    public static class NewTurnCheckTruckLogic
    {
        public static void NewTurnCheckTrucks(Company company)
        {
            foreach (var truck in company.ListOfOwnTrucks.Where(truck => truck.DaysOnTheWay > 0))
            {
                if (truck.DaysOnTheWay > 1)
                {
                   truck.DaysOnTheWay -= 1;
                }
                else
                {
                    var fuelConsume= truck.ConsumeFuelInLiterBetweenTwoCities * ConfigParameter.PriceForFuelInEuro;
                    company.Amount -= fuelConsume;
                    WriteTableOnConsole.WriteInfoOnConsoleForNewRound(company, truck,fuelConsume);
                    NewTurnValueForTruck(truck);

                }
            }
        }

        private static void NewTurnValueForTruck(Truck truck)
        {
            
            truck.DaysOnTheWay = 0;

            truck.ConsumeFuelInLiterBetweenTwoCities = 0;

            truck.CurrentCity = truck.TargetCity;
        }
    }
}