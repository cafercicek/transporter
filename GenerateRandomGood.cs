using System.Collections.Generic;


namespace Transporter6
{
    public class GenerateRandomGood
    {
        public List<Goods> GenerateRandomGoods()
        {
            var listOfGoods = new List<Goods>();
            for (var i = 0; i < ConfigParameter.GoodsGenerateNumber; i++)
            {
                listOfGoods.Add(new CreateAGood().GenerateRandomGood());
            }
            
            return listOfGoods;
        }
    }
    
}