using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Transporter6
{
    public class GenerateRandomDriver
    {
        
        public string[] GetAllLinesFromFile()
        {
            var currentPath = CreateCurrentPath();
            
            var pathOfFile = AddPathOfFile(currentPath);
            
            var lines = ReadAllLines(pathOfFile);
            return lines;
        }

        
       
        public List<Driver> FillTheListOfDrivers()
        {
            var lines = GetAllLinesFromFile();
            
            return Enumerable.Range(0, ConfigParameter.DriverGenerateNumber).Select(_ => CreateADriver(lines)).ToList();
        }

        public static Driver CreateADriver(string[] lines)
        {
            var driver = new Driver
            {
                Firstname = GetRandomTextForDriver(lines, 0),
                Lastname = GetRandomTextForDriver(lines, 1),
                ClassificationOfDriver = GetClassificationForDriver(),
                Salary = GetRandomSalary()
            };
            driver.ClassificationOfDriverText = ConfigParameter.DriverClassificationText[driver.ClassificationOfDriver];
            return driver;
        }        
  
        public static string GetRandomTextForDriver(string[] lines, int indexOfVocable)
        {
            var listOfText = FillListOfVocables(lines, indexOfVocable);

            var chosenText = TakeARandomText(listOfText);
            return chosenText;
        }

        private static string TakeARandomText(IReadOnlyList<string> listOfText)
        {
            var rand = new Random();
            
            return listOfText[rand.Next(0, listOfText.Count)];
        }


        private static DriverClassification TakeARandomText(IReadOnlyList<DriverClassification> listOfText)
        {
            var rand = new Random();
            
            return listOfText[rand.Next(0, listOfText.Count)];
        }

        private static List<string> FillListOfVocables(string[] lines, int indexOfVocable)
        {
            var listOfText = new List<string>();
            foreach (string line in lines)
            {
                var partOfLine = line.Split(" ");
                listOfText.Add(partOfLine[indexOfVocable]);
            }

            return listOfText;
        }
        
        public static DriverClassification GetClassificationForDriver()
        {
            var classificationsOfDrivers = new List<DriverClassification>
            {
                DriverClassification.ClassificationRacingDriver,
                DriverClassification.ClassificationDreamyDriver,
                DriverClassification.ClassificationHardDriver,
                DriverClassification.ClassificationGhostDriver
            };
            return TakeARandomText(classificationsOfDrivers);
        }
        public static int GetRandomSalary()
        {
            var rand = new Random();
            return rand.Next(ConfigParameter.LessRandomSalaryOfDrivers,  ConfigParameter.HighestRandomSalaryOfDrivers);
        }

        public static string[] ReadAllLines(string pathOfFile)
        {
            return File.ReadAllLines(pathOfFile);
        }

        public static string AddPathOfFile(FileSystemInfo currentPath)
        {
            return currentPath.FullName + "\\namen.txt";
        }

        public static DirectoryInfo CreateCurrentPath()
        {
            return new DirectoryInfo("../../../");
        }

    }
}