using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AircraftAPI.Models;

namespace AircraftAPI.Controllers
{
    [Route("[controller]/{id}/duelist")]
    [ApiController]
    public class AircraftController : ControllerBase
    {
        private readonly MyContext _context;

        public AircraftController(MyContext context)
        {
            _context = context;
        }

        // POST: api/AircraftAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AircraftRepair>> PostAircraftRepair(List<Repair> repairs, int id)
        {
            var aircraftList = new List<Aircraft>
            {
                new Aircraft{Id=1, DailyHours=0.7, CurrentHours=550},
                new Aircraft{Id=2, DailyHours=1.1, CurrentHours=200}
            };
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
            var aircraftRepair = new AircraftRepair{Id = id, Repairs = nextDueList};

            _context.AircraftRepairDbSet.Add(aircraftRepair);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostAircraftRepair), new {id = aircraftRepair.Id}, aircraftRepair);
        }
    }

        
}
