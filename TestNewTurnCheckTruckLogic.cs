using System.Linq;
using Xunit;

namespace Transporter6
{
    public class TestNewTurnCheckTruckLogic
    {
        
        [Fact]
        public void CheckMoveTruckCheck()
        {
            var company = new Company();
            var listOfCities = new GetAllCitiesFromFile().GetListOfCities();
            var listOfTrucks = new GenerateRandomTrucker().FillListOfTrucks();
            var listOfDrivers = new GenerateRandomDriver().FillTheListOfDrivers();
            var testTruck = listOfTrucks.ElementAt(2);
            //Current City Amsterdam
            testTruck.CurrentCity = listOfCities.ElementAt(1);
            //Target City Berlin
            testTruck.TargetCity = listOfCities.ElementAt(2);
            testTruck.Driver = listOfDrivers.ElementAt(2);
            company.ListOfOwnTrucks.Add(testTruck);
            MoveTruckLogic.MoveTruckCheck( company.ListOfOwnTrucks.ElementAt(0));
            company.ListOfOwnTrucks.ElementAt(0).DaysOnTheWay = 1;
            var amountCompanyBeforeMoveTruck = company.Amount;
            NewTurnCheckTruckLogic.NewTurnCheckTrucks(company);
            var amountCompanyAfterMoveTruck = company.Amount;
            Assert.NotEqual(amountCompanyBeforeMoveTruck,amountCompanyAfterMoveTruck);
        }
        [Fact]
        public void CheckMoveTruckCheck2()
        {
            var company = new Company();
            var listOfCities = new GetAllCitiesFromFile().GetListOfCities();
            var listOfTrucks = new GenerateRandomTrucker().FillListOfTrucks();
            var listOfDrivers = new GenerateRandomDriver().FillTheListOfDrivers();
            var testTruck = listOfTrucks.ElementAt(2);
            //Current City Amsterdam
            testTruck.CurrentCity = listOfCities.ElementAt(1);
            //Target City Berlin
            testTruck.TargetCity = listOfCities.ElementAt(2);
            testTruck.Driver = listOfDrivers.ElementAt(2);
            company.ListOfOwnTrucks.Add(testTruck);
            MoveTruckLogic.MoveTruckCheck( company.ListOfOwnTrucks.ElementAt(0));
            company.ListOfOwnTrucks.ElementAt(0).DaysOnTheWay = 1;
            NewTurnCheckTruckLogic.NewTurnCheckTrucks(company);
            var dayOnTheWayAfterMoveTruck = company.ListOfOwnTrucks.ElementAt(0).DaysOnTheWay;
            Assert.Equal(0,dayOnTheWayAfterMoveTruck);
        }
    }
}