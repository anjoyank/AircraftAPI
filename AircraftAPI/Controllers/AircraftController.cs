using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AircraftAPI.Models;
using AircraftAPI.Services;
using Microsoft.AspNetCore.Cors;

namespace AircraftAPI.Controllers
{
    [Route("[controller]/{id}/duelist")]
    [ApiController]
    public class AircraftController : ControllerBase
    {
        private readonly AircraftService _aircraftService;

        public AircraftController(AircraftService aircraftService)
        {
            _aircraftService = aircraftService;
        }

        // POST: api/AircraftAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        
        [HttpOptions, HttpPost]
        public ActionResult<AircraftRepair> PostAircraftRepair(List<Repair> repairs, int id)
        {

            var aircraftRepair = new AircraftRepair();
            aircraftRepair = _aircraftService.CreateAircraftRepair(repairs, id);

            return CreatedAtAction(nameof(PostAircraftRepair), new { id = aircraftRepair.AircraftId }, aircraftRepair);
        }
    }


}
