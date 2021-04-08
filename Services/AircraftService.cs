using System;
using System.Collections.Generic;
using AircraftAPI.Models;
using AircraftAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AircraftAPI.Services
{
    public class AircraftService
    {
        private readonly AircraftRepository _repository;
        public AircraftService(AircraftRepository repository)
        {
            _repository = repository;
        }

        public AircraftRepair CreateAircraftRepair(List<Repair> repairs, int id)
        {
            var aircraftList = _repository.GetAircraft();
            Aircraft thisAircraft = aircraftList.Find(p => p.Id == id);
            
            var nextDueList = new List<Repair>();
            foreach (Repair repair in repairs)
            {
                DateTime logDate = DateTime.Parse(repair.LogDate);
                double? DaysRemainingByHoursInterval;
                DateTime? IntervalHoursNextDueDate = null;
                DateTime? IntervalMonthsNextDueDate = null;
                if (repair.IntervalMonths != null && repair.LogDate != null)
                {
                    IntervalMonthsNextDueDate = logDate.AddMonths((int)repair.IntervalMonths);
                }
                
                if (repair.LogHours != null && repair.IntervalHours != null)
                {
                    DaysRemainingByHoursInterval = (((repair.LogHours + repair.IntervalHours) - thisAircraft.CurrentHours) / thisAircraft.DailyHours);
                    IntervalHoursNextDueDate = logDate.AddDays((double)DaysRemainingByHoursInterval);
                }

                if (IntervalHoursNextDueDate <= IntervalMonthsNextDueDate || IntervalMonthsNextDueDate == null)
                {
                    repair.NextDue = IntervalHoursNextDueDate;
                }
                
                else
                {
                    repair.NextDue = IntervalMonthsNextDueDate;
                }

                nextDueList.Add(repair);
            }
            nextDueList.Sort((x, y) => DateTime.Compare(x.NextDue ?? DateTime.MaxValue, y.NextDue ?? DateTime.MaxValue));
            var aircraftRepair = new AircraftRepair{Id = id, Repairs = nextDueList};
            return aircraftRepair;
        }
    }
}