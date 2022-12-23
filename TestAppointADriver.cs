using System.Linq;
using Xunit;

namespace Transporter6
{
    public class TestAppointADriver
    {
        [Fact]
        public void CheckAppointADriver()
        {
            var listOfDrivers = new GenerateRandomDriver().FillTheListOfDrivers();
            var listOfTrucks = new GenerateRandomTrucker().FillListOfTrucks();
            var testTruck = listOfTrucks.ElementAt(2);
            var testDriver = listOfDrivers.ElementAt(2);
            UIAppointADriver.MatchTruckerAndDriver(testTruck, testDriver);
            Assert.NotNull(testTruck.Driver);
        }
    }
}