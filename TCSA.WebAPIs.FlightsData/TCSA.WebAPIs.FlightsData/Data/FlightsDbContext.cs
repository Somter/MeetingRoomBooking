using Microsoft.EntityFrameworkCore;
using TCSA.WebAPIs.FlightsData_.Models;

namespace TCSA.WebAPIs.FlightsData_.Data
{
    public class FlightsDbContext: DbContext
    {
        public FlightsDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Flight> Flights { get; set; }
    }
}
