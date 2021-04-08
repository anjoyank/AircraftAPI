using System.Collections.Generic;
using AircraftAPI.Models;
using System.Threading.Tasks;

namespace AircraftAPI.Repository
{
    public class AircraftRepository
    {
        public List<Aircraft> GetAircraft()
        {
            var aircraftList = new List<Aircraft>
            {
                new Aircraft{Id=1, DailyHours=0.7, CurrentHours=550},
                new Aircraft{Id=2, DailyHours=1.1, CurrentHours=200}
            };
            return aircraftList;
        }
    }
}