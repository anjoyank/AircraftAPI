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

        public static DateTime FindNextMonthDue(DateTime date, int months)
        {
            return date.AddMonths(months);
        }

        public static double FindDaysByHours(int logHours, int intervalHours, double currentHours, double dailyHours)
        {
            return (((logHours + intervalHours)-currentHours)/dailyHours);
        }

        public static DateTime FindNextHoursDue(DateTime date, double days)
        {
            return date.AddDays(days);
        }



        public AircraftRepair CreateAircraftRepair(List<Repair> repairs, int id)
        {
            var aircraftList = _repository.GetAircraft();
            Aircraft thisAircraft = aircraftList.Find(p => p.AircraftId == id);
            
            var nextDueList = new List<RepairReturn>();
            foreach (Repair repair in repairs)
            {
                RepairReturn result = new RepairReturn
                {
                    ItemNumber = repair.ItemNumber,
                    Description = repair.Description,
                    LogDate = repair.LogDate,
                    LogHours = repair.LogHours,
                    IntervalMonths = repair.IntervalMonths,
                    IntervalHours = repair.IntervalHours
                };
                DateTime logDate = repair.LogDate;
                double? DaysRemainingByHoursInterval;
                DateTime? IntervalHoursNextDueDate = null;
                DateTime? IntervalMonthsNextDueDate = null;
                if (repair.IntervalMonths != null && repair.LogDate != null)
                {
                    IntervalMonthsNextDueDate = FindNextMonthDue(logDate, (int)repair.IntervalMonths);
                }
                
                if (repair.LogHours != null && repair.IntervalHours != null)
                {
                    DaysRemainingByHoursInterval = FindDaysByHours((int)repair.LogHours, (int)repair.IntervalHours, thisAircraft.CurrentHours, thisAircraft.DailyHours);
                    IntervalHoursNextDueDate = FindNextHoursDue(logDate, (double)DaysRemainingByHoursInterval);
                }

                if (IntervalHoursNextDueDate <= IntervalMonthsNextDueDate || IntervalMonthsNextDueDate == null)
                {
                    result.NextDue = IntervalHoursNextDueDate;
                }
                
                else
                {
                    result.NextDue = IntervalMonthsNextDueDate;
                }

                nextDueList.Add(result);
            }
            nextDueList.Sort((x, y) => DateTime.Compare(x.NextDue ?? DateTime.MaxValue, y.NextDue ?? DateTime.MaxValue));
            var aircraftRepair = new AircraftRepair{AircraftId = id, Repairs = nextDueList};
            return aircraftRepair;
        }
    }
}