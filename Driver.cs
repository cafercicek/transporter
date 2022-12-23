namespace Transporter6
{
    public enum DriverClassification
    {
        ClassificationRacingDriver,

        ClassificationDreamyDriver,

        ClassificationHardDriver,

        ClassificationGhostDriver
    }
    public class Driver
    {
        internal string Firstname { set; get; }
        internal string Lastname { set; get; }
        internal int Salary { set; get; }
        internal string ClassificationOfDriverText { set; get; }
        internal DriverClassification ClassificationOfDriver { set; get; }

        internal bool CheckTruck { set; get; } = false;
        
        private static int _identificationNumberCounter = 1;
        
        internal readonly int IdNumber;
        public Driver()
        {
            IdNumber = _identificationNumberCounter++;
        }
    }
}