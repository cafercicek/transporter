using System.Linq;
using Xunit;

namespace Transporter6
{
    public class TestMoveTruckLogic
    {

        [Fact]
        public void CheckCalculateDistanceTwoCities()
        {
            var listOfCities = new GetAllCitiesFromFile().GetListOfCities();
            var listOfTrucks = new GenerateRandomTrucker().FillListOfTrucks();
            var testTruck = listOfTrucks.ElementAt(2);
            //Current City Amsterdam
            testTruck.CurrentCity = listOfCities.ElementAt(1);
            //Target City Berlin
            testTruck.TargetCity = listOfCities.ElementAt(2);
            var diffBetweenTwoCitiesInM = MoveTruckLogic.CalculateDistanceTwoCities(testTruck);
            Assert.InRange(diffBetweenTwoCitiesInM,500,650);
        }
        
        
        [Fact]
        public void CheckMoveTruckCheck()
        {
            var listOfCities = new GetAllCitiesFromFile().GetListOfCities();
            var listOfTrucks = new GenerateRandomTrucker().FillListOfTrucks();
            var listOfDrivers = new GenerateRandomDriver().FillTheListOfDrivers();
            var testTruck = listOfTrucks.ElementAt(2);
            //Current City Amsterdam
            testTruck.CurrentCity = listOfCities.ElementAt(1);
            //Target City Berlin
            testTruck.TargetCity = listOfCities.ElementAt(2);
            testTruck.Driver = listOfDrivers.ElementAt(2);
            
            MoveTruckLogic.MoveTruckCheck(testTruck);
            
            var daysOnTheWay = testTruck.DaysOnTheWay;
            
            Assert.InRange(daysOnTheWay,0,20);
        }
    }
}