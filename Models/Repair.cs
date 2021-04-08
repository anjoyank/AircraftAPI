using System;

namespace AircraftAPI.Models
{
    public class Repair
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string LogDate { get; set; }
        public int? LogHours { get; set; }
        public int? IntervalMonths { get; set; }
        public int? IntervalHours { get; set; }
        public DateTime? NextDue { get; set; }

    }
}