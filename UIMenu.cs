using System;
using System.Collections.Generic;
using System.Linq;

namespace Transporter6
{
    public class UIMenu
    {
        public static DateTime playTime;
        public static void StartTheGame(Company company, List<Truck> listOfTrucks, List<Driver> listOfDrivers,
            List<Goods> listOfGoods)
        {
            OpenTheMenu(company, listOfTrucks, listOfDrivers, listOfGoods);
        }

        public static void OpenTheMenu(Company company, List<Truck> listOfTrucks,
            List<Driver> listOfDrivers, List<Goods> listOfGoods)
        {
            var gameDayCounter = 0;

            var dateTimeNow = DateTime.Now;
            
            while (true)
            {
                ConsoleKeyInfo key;

                Console.Clear();
                playTime = dateTimeNow.AddDays(gameDayCounter);
                WriteActualCompanyInfos(company, playTime);

                do
                {
                    key = Console.ReadKey(true);
                } while (key.KeyChar != '1'
                         && key.KeyChar != '2'
                         && key.KeyChar != '3'
                         && key.KeyChar != '4'
                        );

                Console.WriteLine("Gedruct: " + key.KeyChar);
                Console.ReadKey(true);
                
                switch (key.KeyChar)
                {
                    case '1':
                        UIBuyTruck.BuyATruck(company, listOfTrucks);
                        break;
                    case '2':
                        UIHireADriver.HireADriver(company, listOfDrivers);
                        break;
                    case '3':
                        UITakeAJob.AcceptsAJob(company, listOfGoods);
                        break;
                    case '4':
                        gameDayCounter++;
                        Console.WriteLine("Nachte Runde");
                        break;
                }
                Console.ReadKey(true);
            }
        }

        private static void WriteActualCompanyInfos(Company company, DateTime timeOfPlay)
        {
            var deliveryDayDisplay = timeOfPlay.ToString("dd.MM.yyyy");

            Console.WriteLine($"{company.Name} | {company.Amount:0.00}  EUR | " +
                              $"{deliveryDayDisplay} | {company.GetCountOfOwnTrucks()} | " +
                              $"{company.GetCountOfOwnDrivers()} | {company.GetCountOfOwnJobs()}");

            Console.WriteLine("1. LKW kaufen");

            Console.WriteLine("2. Fahrer einstellen");

            Console.WriteLine("3. Aufträge annehmen");

            Console.WriteLine("4. Runde beenden");
        }
    }
}

