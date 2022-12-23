using System.Linq;
using Xunit;

namespace Transporter6
{
    public class TestAppointAJob
    {
        [Fact]
        public void CheckAppointAJob()
        {
            var listOfGoods = new GenerateRandomGood().GenerateRandomGoods();
            var listOfTrucks = new GenerateRandomTrucker().FillListOfTrucks();
            var testGood = listOfGoods.ElementAt(2);
            var testTruck = listOfTrucks.ElementAt(2);
            
            UIAppointAJob.MatchJobAndTruck(testTruck, testGood);
            Assert.NotNull(testTruck.Good);
        }
    }
}