using System;
using System.Linq;

namespace Transporter6
{
    public class UITest
    {
        public static void AppointADriverToATruck(Company company)
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
            if (truck.Driver != null)
            {
                Console.WriteLine("Der LKW hat schon einen Fahrer");
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
        }

        private static void MatchTruckerAndDriver(Truck truck, Driver driver)
        {
            if (truck.Driver != null || driver.CheckTruck != false) return;
            truck.Driver = driver;
            driver.CheckTruck = true;
            Console.WriteLine($"{driver.Firstname} {driver.Lastname} wurde einem LKW zugeordnet");
            Console.ReadKey(true);
        }

        public static void AppointAJobToATruck(Company company)
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

            if (truck.Capacity <= 0)
            {
                Console.WriteLine("Der LKW hat keine Kapazität mehr");
                goto repeatForTruck;
            }

            if (truck.Driver == null)
            {
                Console.WriteLine("Der LKW hat keinen Fahrer");
                goto repeatForTruck;
            }

            repeatForGoods:
            checkValue = true;
            chooseOfCompany = 0;
            do
            {
                WriteTableOnConsole.WriteGoodsOnConsole(company.ListOfOwnJobs);
                Console.WriteLine(
                    $"Wähle einen Frachtauftrag mit 1-{company.ListOfOwnJobs.Count} ein oder kehre zürück mit z");

                var key = Console.ReadKey(true);

                if (key.KeyChar == 'z') return;

                int.TryParse(key.KeyChar.ToString(), out chooseOfCompany);

                if (chooseOfCompany > 0 && chooseOfCompany < company.ListOfOwnJobs.Count + 1) checkValue = false;

                else new WriteTableOnConsole().WriteWarningOnConsole();
            } while (checkValue);

            var job = company.ListOfOwnJobs.ElementAt(chooseOfCompany - 1);
            if (job.SuitableTruck.Type != truck.Type)
            {
                Console.WriteLine("Der Fahrzeugtyp sollte zum zur transportierenden Ware passen.");
                goto repeatForGoods;
            }

            if (job.StartPoint != truck.CurrentCity)
            {
                Console.WriteLine("Der LKW sollte an der Stadt, wo die Ware von dem Auftrag befindet, sein");
                goto repeatForGoods;
            }

            if (job.Weight >= truck.Capacity)
            {
                Console.WriteLine("Die Kapazität des LKW sollte zum zur transportierenden Ware passen.");
                goto repeatForGoods;
            }

            MatchJobAndTruck(truck, job);
        }


        private static void MatchJobAndTruck(Truck truck, Goods job)
        {
            if (truck.Driver != null || job.CheckTruck != false || (truck.Capacity < job.Weight)) return;
            truck.Good = job;
            truck.Capacity -= job.Weight;
            job.CheckTruck = true;
            Console.WriteLine($"{job.Name} wurde zum LKW eingestellt");
            Console.ReadKey(true);
        }


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
        }

        private static void MatchATruckAndACity(Truck truck, City targetCity)
        {
            if (truck.DaysOnTheWay > 0 || (truck.CurrentCity.Name == targetCity.Name)) return;
            truck.TargetCity = targetCity;
            var diffOfXEasting = targetCity.XEasting - truck.CurrentCity.XEasting;
            var diffOfYNorthing = targetCity.YNorthing - truck.CurrentCity.YNorthing;
            var diffBetweenTwoCitiesInM =
                Math.Sqrt(diffOfXEasting * diffOfXEasting + diffOfYNorthing * diffOfYNorthing);
            var diffBetweenTwoCitiesInKm = diffBetweenTwoCitiesInM / 1000;

            truck.DaysOnTheWay = (int)(diffBetweenTwoCitiesInKm / 300);
            Console.WriteLine(
                $"{truck.Driver.Firstname} {truck.Driver.Lastname} ist unterwegs mit {truck.TypeOnConsole} nach {targetCity.Name}.");
            Console.ReadKey(true);
        }
    }
}