using Xunit;

namespace Transporter6
{
    public class TestHireADriver
    {
        [Fact]
        public void CheckCountOfDriversOfTestCompany()
        { 
            var listOfDrivers = new GenerateRandomDriver().FillTheListOfDrivers();

            var company = new Company();
            
            UIHireADriver.TheCompanyChoosesADriver(company, listOfDrivers,2);
            
            var countOfAllDriversOfTestCompany = company.ListOfOwnDrivers.Count;
            
            var expectedValue = 1;
            
            Assert.Equal(expectedValue, countOfAllDriversOfTestCompany);
        }
        [Fact]
        public void CheckCountOfListOfGoods()
        { 
            var listOfDrivers = new GenerateRandomDriver().FillTheListOfDrivers();

            var company = new Company();
            
            var countOfDriversBeforeHiring = listOfDrivers.Count;
            
            UIHireADriver.TheCompanyChoosesADriver(company, listOfDrivers,2);

            var countOfDriversAfterHiring = listOfDrivers.Count;
            
            var expectedValue = countOfDriversBeforeHiring - 1;
            
            Assert.Equal(expectedValue, countOfDriversAfterHiring);
        }
    }
}