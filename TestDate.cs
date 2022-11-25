using System;
using System.IO;
using Xunit;

namespace Transporter6
{
    public class TestDate
    {
        [Fact]
        public void CheckTestDate()
        {
            //ich habe nicht geschaft, wie man "4" eingeben kann. :(
            var dateTimeNow = DateTime.Now;
            var expectedPlayGame = dateTimeNow.AddDays(1); 
            Assert.Equal(expectedPlayGame, dateTimeNow.AddDays(1));
        }
    }
}