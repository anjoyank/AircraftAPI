using Microsoft.EntityFrameworkCore;

namespace AircraftAPI.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        public DbSet<AircraftRepair> AircraftRepairDbSet { get; set; }
        public DbSet<Repair> RepairDbSet { get; set; }
        public DbSet<Aircraft> AircraftDbSet { get; set; }
    }
}