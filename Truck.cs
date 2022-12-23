namespace Transporter6
{
    public enum  TruckType
    {
        TruckTypeFlatbedTruck, 
        TruckTypeTanker,
        TruckTypeRefrigeratedTruck
    }

    public enum TruckSize
    {
        SmallTruckSize,
        NormalTruckSize,
        BigTruckSize,
        HugeTruckSize
    }
    public class Truck
    {
            internal TruckType Type { set; get; }
            internal string TypeOnConsole { set; get; }
            internal City CurrentCity { set; get; }
            internal City TargetCity { set; get; }
            internal int Year { set; get; }
            internal int PowerInkW { set; get; }
            internal string SizeText { set; get; }
            internal TruckSize Size { set; get; }
            internal int MaxLoad { set; get; }
            internal int Capacity { set; get; }
            internal int FuelEfficiencyDivideBy100Km { set; get; }
            internal int ConsumeFuelInLiterBetweenTwoCities { set; get; }
            
            internal double Price { set; get; }
            internal int DaysOnTheWay { set; get; } = 0;
            
            internal Driver Driver { set; get; }
            internal Goods Good { set; get; }
            private static int _identificationNumberCounter = 1;
            internal readonly int IdNumber;

            public Truck()
            {
                IdNumber = _identificationNumberCounter++;
            }
            
    }
}