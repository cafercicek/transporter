using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Transporter6
{
    public static class MoveTruckLogic
    {
        public static void MoveTruckCheck(Truck truck)
        {
            truck.ConsumeFuelInLiterBetweenTwoCities= CalculateConsumeFuelForTruck(truck);
            truck.DaysOnTheWay = CalculateDiffBetweenTwoCitiesInDay(truck);
        }
        private static int CalculateDiffBetweenTwoCitiesInDay(Truck truck)
        {
            //it has to be fix
           var driveDay = ( CalculateDistanceTwoCities(truck) / (ConfigParameter.MaximalDriveHour * CalculateAverageVelocityForDriver(truck)));
           return (int) Math.Round(driveDay);

        }
        
        private static double CalculateAverageVelocityForDriver(Truck truck)
        {
            return CalculateAverageVelocityForTruck(truck) * ConfigParameter.DriverKmFactorPerDay[truck.Driver.ClassificationOfDriver];
        }

        private static int CalculateConsumeFuelForTruck(Truck truck)
        {
            var consumeFuelFactor = 1.0;
            if (truck.Driver.ClassificationOfDriver == DriverClassification.ClassificationRacingDriver)
            {
                consumeFuelFactor = 1.2;
            }
            return (int)(consumeFuelFactor * CalculateDistanceTwoCities(truck) * truck.FuelEfficiencyDivideBy100Km / 100) ;
        }

        private static double CalculateAverageVelocityForTruck(Truck truck)
        {
            var currentLoadedTruck = truck.MaxLoad - truck.Capacity;
           
            var needPower = currentLoadedTruck * ConfigParameter.PowerPerTInKw;
            
            if (needPower > truck.PowerInkW)
            {
               return ConfigParameter.AverageKmPerHour * truck.PowerInkW / needPower;
            }
            else
            {
                return ConfigParameter.AverageKmPerHour;
            }
        }

        public static int CalculateDistanceTwoCities(Truck truck)
        {
            var diffOfXEasting = (truck.TargetCity.XEasting - truck.CurrentCity.XEasting)/1000;
            
            var diffOfYNorthing = (truck.TargetCity.YNorthing - truck.CurrentCity.YNorthing)/1000;
           
            var powerAdd = diffOfXEasting * diffOfXEasting + diffOfYNorthing * diffOfYNorthing;
            
            var diffBetweenTwoCitiesInM = Math.Sqrt(powerAdd);
            
            return (int)diffBetweenTwoCitiesInM;
        }
      
    }
}