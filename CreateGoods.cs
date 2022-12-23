using System;
using System.Collections.Generic;

namespace Transporter6
{
    public class CreateAGood
    {

        public Goods GenerateRandomGood()
        {
            var listOfGoods = GetListOfGoods();

            var randomIndexOfList = new GenerateRandomNumber().GetNumberBetween(0, listOfGoods.Count);

            var currentGood = listOfGoods[randomIndexOfList];

            SetPropertiesOfGood(currentGood);

            return currentGood;
        }

        private static List<Goods> GetListOfGoods()
        {
            return new List<Goods>
            {
                new Cigarette(), new Textile(), new Chocolate(),
                new Fruit(), new IceCream(), new Meat(),
                new Crude(), new Fuel(), new Gasoline()
            };
        }

        private static void SetPropertiesOfGood(Goods currentGood)
        {
            SetIdNumberOfGood(currentGood);

            SetWeightOfGood(currentGood);

            SetCitiesOfGood(currentGood);

            SetDeliveryDayOfGood(currentGood);

            SetPaymentOfGood(currentGood);

            SetFineOfGood(currentGood);
        }

        private static void SetIdNumberOfGood(Goods currentGood)
        {
            currentGood.IdNumber = Goods.IdentificationNumberCounter++;
        }

        private static void SetFineOfGood(Goods currentGood)
        {
            currentGood.Fine = new GenerateRandomNumber().GetNumberBetween( ConfigParameter.BeginRandomNumberForFine ,
                ConfigParameter.FinishRandomNumberForFine ) * currentGood.Payment * ConfigParameter.PercentNumberForFine ;
        }

        private static void SetPaymentOfGood(Goods currentGood)
        {
            var floatNumberBetween0And1 = new GenerateRandomNumber().GetNumberBetween(0, 100) * 0.01;

            var bonusFactor = 1 + (0.2 + (double)currentGood.DeliveryDay / currentGood.MaxDay) * floatNumberBetween0And1;

            currentGood.Payment = currentGood.MinPrice * currentGood.Weight * bonusFactor;
        }

        private static void SetDeliveryDayOfGood(Goods currentGood)
        {
            var today = DateTime.Now;

            currentGood.DeliveryDay = new GenerateRandomNumber().GetNumberBetween(3, currentGood.MaxDay + 1);

            currentGood.DeliveryDateTime = today.AddDays(currentGood.DeliveryDay);
        }

        private static void SetWeightOfGood(Goods currentGood)
        {
            currentGood.Weight = new GenerateRandomNumber().GetNumberBetween(1, currentGood.MaxWeight + 1);
        }

        private static void SetCitiesOfGood(Goods currentGood)
        {
            var listOfCities = new GetAllCitiesFromFile().GetListOfCities();

            var (indexOfStartPoint, indexOfStopPoint) =
                new GenerateRandomNumber().GetMultipleNumbers(0, listOfCities.Count);

            currentGood.StartPoint = listOfCities[indexOfStartPoint];

            currentGood.StopPoint = listOfCities[indexOfStopPoint];
        }
    }
}