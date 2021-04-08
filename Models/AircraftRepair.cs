using System.Collections.Generic;

namespace AircraftAPI.Models
{
    public class AircraftRepair {
        public int Id { get; set; }
        public List<Repair> Repairs { get; set; }
    }
}