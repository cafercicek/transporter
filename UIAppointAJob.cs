using System;
using System.Linq;

namespace Transporter6
{
    public class UIAppointAJob
    {
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

            if (truck.DaysOnTheWay > 0)
            {
                Console.WriteLine("Der gewählte LKW sollte nicht unterwegs sein");
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

            if (job.StartPoint.Name != truck.CurrentCity.Name)
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
            Console.ReadKey(true);
        }


        public static void MatchJobAndTruck(Truck truck, Goods job)
        {
            if (truck.Good != null || job.CheckTruck != false || (truck.Capacity < job.Weight) ||
                (truck.DaysOnTheWay > 0)) return;
            truck.Good = job;
            truck.Capacity -= job.Weight;
            job.CheckTruck = true;
            Console.WriteLine($"{job.Name} wurde zum LKW eingestellt");
        }
    }
}