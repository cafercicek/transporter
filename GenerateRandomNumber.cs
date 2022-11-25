using System;

namespace Transporter6
{
    public class GenerateRandomNumber
    {
        private readonly Random _rand = new Random();

        public int GetNumberBetween(int minimum, int maximum)
        {
            return _rand.Next(minimum, maximum);
        }
        public int GetNumberBetween(int maximum)
        {
            return _rand.Next(maximum);
        }
        public Tuple<int, int> GetMultipleNumbers(int minimum, int maximum)
        {
            var firstNumber = _rand.Next(minimum, maximum);
            
            var secondNumber =  _rand.Next(minimum, maximum);
            
            return Tuple.Create(firstNumber,secondNumber);
        }
    }
}