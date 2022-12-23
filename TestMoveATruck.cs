using System.Linq;
using Xunit;

namespace Transporter6
{
    public class TestMoveATruck
    {
        [Fact]
        public void CheckMoveATruck()
        {
            var listOfCities = new GetAllCitiesFromFile().GetListOfCities();
            var listOfTrucks = new GenerateRandomTrucker().FillListOfTrucks();
            var testCity = listOfCities.ElementAt(2);
            var testTruck = listOfTrucks.ElementAt(2);
            
            UIMoveATruck.MatchATruckAndACity(testTruck, testCity);
            Assert.NotEqual(0,testTruck.DaysOnTheWay);
        }
    }
}