using System;
using System.Linq;

namespace Transporter6
{
    public class UIMoveATruck
    {
        public static void MoveOfTruckToACity(Company company)
        {
            var checkValue = true;

            var chooseOfCompany = 0;
            repeatForTruck:
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
            if (truck.DaysOnTheWay > 0)
            {
                Console.WriteLine("Der gewählte LKW sollte nicht unterwegs sein");
                goto repeatForTruck;
            }

            checkValue = true;
            var listOfCities = new GetAllCitiesFromFile().GetListOfCities();
            repeatForCity:
            chooseOfCompany = 0;
            do
            {
                WriteTableOnConsole.WriteTrucksOnConsole(truck);
                WriteTableOnConsole.WriteAllCitiesOnConsole(listOfCities);
                Console.WriteLine($"Wähle eine Stadt mit 1-{listOfCities.Count} ein oder kehre zürück mit z");

                var key = Console.ReadKey(true);

                if (key.KeyChar == 'z') return;

                int.TryParse(key.KeyChar.ToString(), out chooseOfCompany);

                if (chooseOfCompany > 0 && chooseOfCompany < listOfCities.Count + 1) checkValue = false;

                else new WriteTableOnConsole().WriteWarningOnConsole();
            } while (checkValue);

            var city = listOfCities.ElementAt(chooseOfCompany - 1);
            if (truck.CurrentCity == city)
            {
                Console.WriteLine("Die gewählte Stadt sollte keine Stadt sein, wo der LKW aktuelle ist");
                goto repeatForCity;
            }

            if (truck.CurrentCity == city)
            {
                Console.WriteLine("Die gewählte Stadt sollte keine Stadt sein, wo der LKW aktuelle ist");
                goto repeatForCity;
            }

            MatchATruckAndACity(truck, city);
            Console.ReadKey(true);
        }

        public static void MatchATruckAndACity(Truck truck, City targetCity)
        {
            if (truck.DaysOnTheWay > 0 || (truck.CurrentCity.Name == targetCity.Name)) return;
            truck.TargetCity = targetCity;
            MoveTruckLogic.MoveTruckCheck(truck);
            Console.WriteLine(
                $"{truck.Driver.Firstname} {truck.Driver.Lastname} ist unterwegs mit {truck.TypeOnConsole} nach {targetCity.Name}.");
          
        }
    }
}