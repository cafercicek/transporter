namespace Transporter6
{
    internal class Program
    {
        private static void Main()
        {
            var uiOpen = new UIOpenPage();
            UIMenu.StartTheGame(uiOpen.Company, uiOpen.listOfTrucks, uiOpen.listOfDrivers, uiOpen.listOfGoods);
        }
    }
}