namespace Transporter6
{

    public class Truck
    {
            internal string Type { set; get; }
            internal City City { set; get; }
            internal int Year { set; get; }
            internal int PowerInkW { set; get; }
            internal string Size { set; get; }


            internal int MaxLoad { set; get; }
            internal int FuelEfficiencyDivideBy100Km { set; get; }
            internal double Price { set; get; }

            private static int _identificationNumberCounter = 1;
            internal readonly int IdNumber;

            public Truck()
            {
                IdNumber = _identificationNumberCounter++;
            }
            public void CalculateTheSizeOfTruck()
            {
                if (9 < this.PowerInkW && this.PowerInkW < 26) Size = "Klein";
            
                else if (25 < this.PowerInkW && this.PowerInkW < 51) Size = "Medium";
            
                else if (50 < this.PowerInkW && this.PowerInkW < 66) Size = "Gross";
            
                else if (65 < this.PowerInkW && this.PowerInkW < 81) Size = "Riesig";
            
                else Size = "falsch";
            }
    }
}