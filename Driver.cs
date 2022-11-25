namespace Transporter6
{
    public class Driver
    {
        internal string Firstname { set; get; }
        internal string Lastname { set; get; }
        internal int Salary { set; get; }
        internal string ClassificationOfDriver { set; get; }
        
        private static int _identificationNumberCounter = 1;
        
        internal readonly int IdNumber;
        public Driver()
        {
            IdNumber = _identificationNumberCounter++;
        }
    }
}