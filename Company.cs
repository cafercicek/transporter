
using System.Collections.Generic;

namespace Transporter6
{
    public class Company
    {
        private const double StartMoney = ConfigParameter.GameStartMoney;
        public List<Truck> ListOfOwnTrucks = new List<Truck>();
        
        public List<Driver> ListOfOwnDrivers = new List<Driver>();
        public List<Goods> ListOfOwnJobs = new List<Goods>();
        
        public string Name { set; get; }
        public double Amount { set; get; } = StartMoney;

        public int GetCountOfOwnTrucks()
        {
            return ListOfOwnTrucks.Count;
        }
        public int GetCountOfOwnDrivers()
        {
            return ListOfOwnDrivers.Count;
        }
        public int GetCountOfOwnJobs()
        {
            return ListOfOwnJobs.Count;
        }
    }
}

