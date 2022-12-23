using System;
using System.Linq;

namespace Transporter6
{
    public class UIAppointADriver
    {
        public static void AppointADriverToATruck(Company company)
        {   repeatForTruck:

            var chooseOfCompany = 0;

            var checkValue = true;
            do
            {
                WriteTableOnConsole.WriteTrucksOnConsole(company.ListOfOwnTrucks);

                Console.WriteLine($"Wahle einen LKW mit 1-{company.ListOfOwnTrucks.Count} oder kehre zürück mit z");

                var key = Console.ReadKey(true);

                if (key.KeyChar == 'z') return;

                int.TryParse(key.KeyChar.ToString(), out chooseOfCompany);

                if (chooseOfCompany > 0 && chooseOfCompany < company.ListOfOwnTrucks.Count + 1) checkValue = false;

                else new WriteTableOnConsole().WriteWarningOnConsole();
            } while (checkValue);

            var truck = company.ListOfOwnTrucks.ElementAt(chooseOfCompany - 1);
            if (truck.Driver != null)
            {
                Console.WriteLine("Der LKW hat schon einen Fahrer");
                goto repeatForTruck;
            }

            if (truck.DaysOnTheWay > 0)
            {
                Console.WriteLine("Der gewählte LKW sollte nicht unterwegs sein");
                goto repeatForTruck;
            }
            
            repeatForDriver:
            checkValue = true;
            chooseOfCompany = 0;
            do
            {
                WriteTableOnConsole.WriteAllDriverOnConsole(company.ListOfOwnDrivers);

                Console.WriteLine(
                    $"Wähle einen Fahrer mit 1-{company.ListOfOwnDrivers.Count} ein oder kehre zürück mit z");

                var key = Console.ReadKey(true);

                if (key.KeyChar == 'z') return;

                int.TryParse(key.KeyChar.ToString(), out chooseOfCompany);

                if (chooseOfCompany > 0 && chooseOfCompany < company.ListOfOwnDrivers.Count + 1) checkValue = false;

                else new WriteTableOnConsole().WriteWarningOnConsole();
            } while (checkValue);

            var driver = company.ListOfOwnDrivers.ElementAt(chooseOfCompany - 1);

            if (driver.CheckTruck != false)
            {
                Console.WriteLine("Der Fahrer hat schon einen LKW");
                goto repeatForDriver;
            }

            MatchTruckerAndDriver(truck, driver);
            Console.ReadKey(true);
        }

        public static void MatchTruckerAndDriver(Truck truck, Driver driver)
        {
            if (truck.Driver != null || driver.CheckTruck != false || truck.DaysOnTheWay > 0) return;
            truck.Driver = driver;
            driver.CheckTruck = true;
            Console.WriteLine($"{driver.Firstname} {driver.Lastname} wurde einem LKW zugeordnet");
            
        }
    }
}