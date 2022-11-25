using System;
using System.Collections.Generic;
using System.Linq;

namespace Transporter6
{
    public class UIHireADriver
    {
        public static void HireADriver(Company company, List<Driver> listOfDrivers)
        {
            var checkValue = true;

            var chooseOfCompany = 0;
            do
            {
                WriteTableOnConsole.WriteAllDriverOnConsole(listOfDrivers);
                
                Console.WriteLine($"Wähle einen Fahrer mit 1-{listOfDrivers.Count} ein oder kehre zürück mit z");

                var key = Console.ReadKey(true);

                if (key.KeyChar == 'z') return;

                int.TryParse(key.KeyChar.ToString(), out chooseOfCompany);

                if (chooseOfCompany > 0 && chooseOfCompany < listOfDrivers.Count + 1) checkValue = false;

                else new WriteTableOnConsole().WriteWarningOnConsole();
                
            } while (checkValue);
            
            TheCompanyChoosesADriver(company, listOfDrivers,chooseOfCompany);
        }


        public static void TheCompanyChoosesADriver(Company company, List<Driver> listOfDrivers, int chooseOfCompany)
        {
            var driver = listOfDrivers.ElementAt(chooseOfCompany - 1);

            if (driver == null)
            {
                Console.WriteLine("Es gibt keinen Fahrer mehr");
            }
            else
            {
                company.ListOfOwnDrivers.Add(driver);

                Console.WriteLine($"Sie walhten den Fahrer {driver.Lastname} ");

                listOfDrivers.RemoveAt(chooseOfCompany - 1);
            }

        }
    }
}