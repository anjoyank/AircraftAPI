using System.Collections.Generic;

namespace AircraftAPI.Models
{
    public class AircraftRepair {
        public int AircraftId { get; set; }
        public List<RepairReturn> Repairs { get; set; }
    }
}