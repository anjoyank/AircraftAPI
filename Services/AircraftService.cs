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

        public static DateTime findNextMonthDue(DateTime date, int months)
        {
            return date.AddMonths(months);
        }

        public static double findDaysByHours(int logHours, int intervalHours, double currentHours, double dailyHours)
        {
            return (((logHours + intervalHours)-currentHours)/dailyHours);
        }

        public static DateTime findNextHoursDue(DateTime date, double days)
        {
            return date.AddDays(days);
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
                    IntervalMonthsNextDueDate = findNextMonthDue(logDate, (int)repair.IntervalMonths);
                }
                
                if (repair.LogHours != null && repair.IntervalHours != null)
                {
                    DaysRemainingByHoursInterval = findDaysByHours((int)repair.LogHours, (int)repair.IntervalHours, thisAircraft.CurrentHours, thisAircraft.DailyHours);
                    IntervalHoursNextDueDate = findNextHoursDue(logDate, (double)DaysRemainingByHoursInterval);
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