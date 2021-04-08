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
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftAPIController : ControllerBase
    {
        private readonly MyContext _context;

        public AircraftAPIController(MyContext context)
        {
            _context = context;
        }

        // GET: api/AircraftAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AircraftRepair>>> GetAircraftRepairDbSet()
        {
            return await _context.AircraftRepairDbSet.ToListAsync();
        }

        // GET: api/AircraftAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AircraftRepair>> GetAircraftRepair(int id)
        {
            var aircraftRepair = await _context.AircraftRepairDbSet.FindAsync(id);

            if (aircraftRepair == null)
            {
                return NotFound();
            }

            return aircraftRepair;
        }

        // PUT: api/AircraftAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAircraftRepair(int id, AircraftRepair aircraftRepair)
        {
            if (id != aircraftRepair.Id)
            {
                return BadRequest();
            }

            _context.Entry(aircraftRepair).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AircraftRepairExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AircraftAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AircraftRepair>> PostAircraftRepair(AircraftRepair aircraftRepair)
        {
            _context.AircraftRepairDbSet.Add(aircraftRepair);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAircraftRepair", new { id = aircraftRepair.Id }, aircraftRepair);
        }

        // DELETE: api/AircraftAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAircraftRepair(int id)
        {
            var aircraftRepair = await _context.AircraftRepairDbSet.FindAsync(id);
            if (aircraftRepair == null)
            {
                return NotFound();
            }

            _context.AircraftRepairDbSet.Remove(aircraftRepair);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AircraftRepairExists(int id)
        {
            return _context.AircraftRepairDbSet.Any(e => e.Id == id);
        }
    }
}
