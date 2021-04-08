using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AircraftAPI.Models;
using AircraftAPI.Services;

namespace AircraftAPI.Controllers
{
    [Route("[controller]/{id}/duelist")]
    [ApiController]
    public class AircraftController : ControllerBase
    {
        private readonly MyContext _context;
        private readonly AircraftService _aircraftService;

        public AircraftController(MyContext context, AircraftService aircraftService)
        {
            _context = context;
            _aircraftService = aircraftService;
        }

        // POST: api/AircraftAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AircraftRepair>> PostAircraftRepair(List<Repair> repairs, int id)
        {
            
            var aircraftRepair = new AircraftRepair();
            aircraftRepair = _aircraftService.CreateAircraftRepair(repairs, id);

            _context.AircraftRepairDbSet.Add(aircraftRepair);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostAircraftRepair), new {id = aircraftRepair.Id}, aircraftRepair);
        }
    }

        
}
