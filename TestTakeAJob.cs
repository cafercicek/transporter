using System.Linq;
using Xunit;

namespace Transporter6
{
    public class TestTakeAJob
    {
        [Fact]
        public void CheckCountOfJobListOfTestCompany()
        { 
            var listOfGoods = new GenerateRandomGood().GenerateRandomGoods();
            
            var company = new Company();
            
            UITakeAJob.TheCompanyChoosesAJob(company, listOfGoods,4);
            
            var countOfAllTruckersOfTestCompany = company.ListOfOwnJobs.Count;
            
            var expectedValue = 1;
            
            Assert.Equal(expectedValue, countOfAllTruckersOfTestCompany);
        }
        [Fact]
        public void CheckCountOfListOfGoods()
        { 
            var listOfGoods = new GenerateRandomGood().GenerateRandomGoods();
            
            var company = new Company();
            
            var countOfListOfGoodsBeforeSale = listOfGoods.Count;
            
            UITakeAJob.TheCompanyChoosesAJob(company, listOfGoods,4);

            var countOfListOfGoodsAfterSale = listOfGoods.Count;
            
            var expectedValue = countOfListOfGoodsBeforeSale - 1;
            
            Assert.Equal(expectedValue, countOfListOfGoodsAfterSale);
        }
    }
}