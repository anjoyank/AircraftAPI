using System;

namespace AircraftAPI.Models
{
    public class Repair
    {
        public int ItemNumber { get; set; }
        public string Description { get; set; }
        public DateTime LogDate { get; set; }
        public int? LogHours { get; set; }
        public int? IntervalMonths { get; set; }
        public int? IntervalHours { get; set; }

    }
}