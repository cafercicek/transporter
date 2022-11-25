using System.Linq;
using Xunit;

namespace Transporter6
{
    public class TestBuyTruck
    {
        [Fact]
        public void CheckCountOfAllTruckersOfTestCompany()
        { 
            var listOfTrucks = new GenerateRandomTrucker().FillListOfTrucks();

            var company = new Company
            {
                Amount = 50000000
            };
            UIBuyTruck.TheCompanyChoosesATruck(company, listOfTrucks,4);
            var countOfAllTruckersOfTestCompany = company.ListOfOwnTrucks.Count;
            var expectedValue = 1;
            Assert.Equal(expectedValue, countOfAllTruckersOfTestCompany);
        }
        [Fact]
        public void CheckAmountOfCompany()
        { 
            var listOfTrucks = new GenerateRandomTrucker().FillListOfTrucks();
            var countOfListOfTrucksBeforeSale = listOfTrucks.Count;
            var company = new Company
            {
                Amount = 50000000
            };
            var amountOfCompanyBeforeSale = company.Amount;
            const int chooseOfCompany = 4;
            var priceOfChosenTruck = listOfTrucks.ElementAt(chooseOfCompany-1).Price;
            UIBuyTruck.TheCompanyChoosesATruck(company, listOfTrucks,chooseOfCompany);
            var amountOfCompanyAfterSale = company.Amount;
            var expectedValue = amountOfCompanyBeforeSale - priceOfChosenTruck;
            Assert.Equal(expectedValue, amountOfCompanyAfterSale);
        }
        [Fact]
        public void CheckCountOfListOfTruckers()
        { 
            var listOfTrucks = new GenerateRandomTrucker().FillListOfTrucks();
            var countOfListOfTrucksBeforeSale = listOfTrucks.Count;
            var company = new Company
            {
                Amount = 50000000
            };
            UIBuyTruck.TheCompanyChoosesATruck(company, listOfTrucks,4);
            UIBuyTruck.TheCompanyChoosesATruck(company, listOfTrucks,6);
            var countOfListOfTrucksAfterSale = listOfTrucks.Count;
            var expectedValue = countOfListOfTrucksBeforeSale - 2;
            Assert.Equal(expectedValue, countOfListOfTrucksAfterSale);
        }
    }
}