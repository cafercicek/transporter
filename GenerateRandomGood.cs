using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Transporter6
{
    public class GenerateRandomGood
    {
        public List<Goods> GenerateRandomGoods()
        {
            var listOfGoods = new List<Goods>();
            for (var i = 0; i < 8; i++)
            {
                listOfGoods.Add(new CreateAGood().GenerateRandomGood());
            }
            
            return listOfGoods;
        }
    }
    
}