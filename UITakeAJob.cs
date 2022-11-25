using System;
using System.Collections.Generic;
using System.Linq;

namespace Transporter6
{
    public class UITakeAJob
    {
        public static void AcceptsAJob(Company company, List<Goods> listOfGoods)
        {
            var checkValue = true;

            var chooseOfCompany = 0;
            
            do
            {
                WriteTableOnConsole.WriteGoodsOnConsole(listOfGoods);
                Console.WriteLine($"Wähle einen Frachtauftrag mit 1-{listOfGoods.Count} ein oder kehre zürück mit z");

                var key = Console.ReadKey(true);

                if (key.KeyChar == 'z') return;

                int.TryParse(key.KeyChar.ToString(), out chooseOfCompany);

                if (chooseOfCompany > 0 && chooseOfCompany < listOfGoods.Count + 1) checkValue = false;

                else new WriteTableOnConsole().WriteWarningOnConsole();
                
            } while (checkValue);

            TheCompanyChoosesAJob(company, listOfGoods, chooseOfCompany);
        }

        public static void TheCompanyChoosesAJob(Company company, List<Goods> listOfGoods, int chooseOfCompany)
        {
            var job = listOfGoods.ElementAt(chooseOfCompany - 1);

            if (job == null)
            {
                Console.WriteLine("Es gibt keinen Fahrer mehr");
            }
            else
            {
                company.ListOfOwnJobs.Add(job);

                Console.WriteLine($"Sie walhten den Frachtauftrag {job.Name} ");

                listOfGoods.RemoveAt(chooseOfCompany - 1);
            }

        }
    }
}