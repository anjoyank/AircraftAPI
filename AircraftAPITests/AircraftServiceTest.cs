using System;
using Xunit;
using AircraftAPI.Services;

namespace AircraftAPITests
{
    public class AircraftServiceTest
    {
        [Fact]
        public void AddingOneMonthReturnsMaySeventh()
        { 
            var date = DateTime.Parse("2018-04-07T00:00:00");
            var compare = DateTime.Parse("2018-05-07T00:00:00");
            var actual = AircraftService.FindNextMonthDue(date, 1);
            Assert.Equal(actual, compare);
        }

        [Fact]
        public void AllOnesReturnsOneDay()
        {
            var compare = 1.0;
            var actual = AircraftService.FindDaysByHours(1,1,1,1);
            Assert.Equal(actual, compare);
        }

        [Fact]
        public void AddingOneDayReturnsAprilEighth()
        {
            var date = DateTime.Parse("2018-04-07T00:00:00");
            var compare = DateTime.Parse("2018-04-08T00:00:00");
            var actual = AircraftService.FindNextHoursDue(date, 1);
            Assert.Equal(actual, compare);
        }
    }
}
