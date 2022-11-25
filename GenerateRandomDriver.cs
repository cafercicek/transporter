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
            
            return Enumerable.Range(0, 5).Select(_ => CreateADriver(lines)).ToList();
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
            return driver;
        }        
  
        public static string GetRandomTextForDriver(string[] lines, int indexOfVocable)
        {
            var listOfText = FillListOfVocables(lines, indexOfVocable);

            var chosenText = TakeARandomText(listOfText);
            return chosenText;
        }

        public static string TakeARandomText(IReadOnlyList<string> listOfText)
        {
            var rand = new Random();
            
            return listOfText[rand.Next(0, listOfText.Count)];
        }

        public static List<string> FillListOfVocables(string[] lines, int indexOfVocable)
        {
            var listOfText = new List<string>();
            foreach (string line in lines)
            {
                var partOfLine = line.Split(" ");
                listOfText.Add(partOfLine[indexOfVocable]);
            }

            return listOfText;
        }


        public static string GetClassificationForDriver()
        {
            var classificationsOfDrivers = new List<string>
            {
                "Rennfahrer",
                "Verträumt",
                "Liebt seinen Job",
                "Unauffällig"
            };
            return TakeARandomText(classificationsOfDrivers);
        }

        public static int GetRandomSalary()
        {
            var rand = new Random();
            return rand.Next(2000, 5000);
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