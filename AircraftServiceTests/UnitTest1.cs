using System;
using AircraftAPI.Services;
using Xunit;

namespace AircraftAPITests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var date = DateTime.Parse("2018-04-07T00:00:00");
            var actual = AircraftService.findNextMonthDue(date, 1);
            var result = date.AddMonths(1);
            Assert.Equal(actual, result);
        }
    }
}
