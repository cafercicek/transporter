using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Transporter6
{
    public class GetAllCitiesFromFile
    {
        private List<City> listOfCities = FillListOfCities(GetAllLinesFromFile());

        public List<City> GetListOfCities()
        {
            return listOfCities;
        }

        private static string[] GetAllLinesFromFile()
        {
            var currentPath = CreateCurrentPath();

            var pathOfFile = AddPathOfFile(currentPath);

            var lines = ReadAllLines(pathOfFile);

            return lines;
        }

        private static string[] ReadAllLines(string pathOfFile)
        {
            return File.ReadAllLines(pathOfFile);
        }

        private static string AddPathOfFile(FileSystemInfo currentPath)
        {
            return currentPath.FullName + "\\cities.txt";
        }

        private static DirectoryInfo CreateCurrentPath()
        {
            return new DirectoryInfo("../../../");
        }


        private static List<City> FillListOfCities(string[] lines)
        {
            return lines.Select(line => line.Split(" ")).Select(partOfLine =>
                CreateACity(partOfLine[0], Convert.ToInt32(partOfLine[3]),
                    Convert.ToInt32(partOfLine[6]))).ToList();
        }

        private static City CreateACity(string name, int xEasting, int yNorthing)
        {
            var city = new City()
            {
                Name = name,
                XEasting = xEasting,
                YNorthing = yNorthing
            };
            return city;
        }
    }
}