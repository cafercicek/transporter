using System;
using System.Collections.Generic;
using System.Linq;

namespace Transporter6
{
    public class UIBuyTruck
    {
        public static void BuyATruck(Company company, List<Truck> listOfTrucks)
        {
            var checkValue = true;

            var chooseOfCompany = 0;


            do
            {
                WriteTableOnConsole.WriteTrucksOnConsole(listOfTrucks);

                Console.WriteLine($"Kaufe einen LKW mit 1-{listOfTrucks.Count} oder kehre zürück mit z");

                var key = Console.ReadKey(true);

                if (key.KeyChar == 'z') return;

                int.TryParse(key.KeyChar.ToString(), out chooseOfCompany);

                if (chooseOfCompany > 0 && chooseOfCompany < listOfTrucks.Count + 1) checkValue = false;

                else new WriteTableOnConsole().WriteWarningOnConsole();
            } while (checkValue);


            TheCompanyChoosesATruck(company, listOfTrucks, chooseOfCompany);
        }

        public static void TheCompanyChoosesATruck(Company company, List<Truck> listOfTrucks, int chooseOfCompany)
        {
            var truck = listOfTrucks.ElementAt(chooseOfCompany - 1);

            if (truck == null)
            {
                Console.WriteLine("Es gibt keine LKW mehr");
                ;
            }
            else if (company.Amount - truck.Price < 0)
            {
                Console.WriteLine("Es ist teuer fuer Sie");

                Console.WriteLine($"Sie haben {company.Amount:0.00} EUR");
            }
            else
            {
                company.Amount -= truck.Price;

                company.ListOfOwnTrucks.Add(truck);

                Console.WriteLine($"Sie kauften den {truck.TypeOnConsole} für {truck.Price} EUR");

                listOfTrucks.RemoveAt(chooseOfCompany - 1);

                Console.WriteLine($"Sie haben noch {company.Amount:0.00} EUR");
            }

        }
    }
}