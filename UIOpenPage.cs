using System;
using System.Collections.Generic;

namespace Transporter6
{
    public class UIOpenPage
    {
        public List<Truck> listOfTrucks = new GenerateRandomTrucker().FillListOfTrucks();
        public List<Driver> listOfDrivers = new GenerateRandomDriver().FillTheListOfDrivers();
        public List<Goods> listOfGoods = new GenerateRandomGood().GenerateRandomGoods();

        public Company Company = new Company
        {
            Name = GetANameForCompanyOnConsole()
        };

        private static string GetANameForCompanyOnConsole()
        {
            Console.Write("Wie ist der Name der Firma? ");
            string inputValue;
            while (string.IsNullOrEmpty(inputValue = Console.ReadLine()))
            {
                Console.WriteLine("Input is invalid");
            }

            return inputValue;
        }
    }
}