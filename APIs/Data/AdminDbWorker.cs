using Microsoft.EntityFrameworkCore;
using AquaInspector.Models;


namespace AquaInspector.Data
{
    /// <summary>
    /// A DB Context Class to handle DB Connection
    /// </summary>
    public class AdminDbWorker:DbContext 
    {
        // Constructor to support dependency injection
        public AdminDbWorker(DbContextOptions<AdminDbWorker> options) : base(options)
        {
        
        }

        // create the Tem
        public DbSet<TemperatureReading> TemperatureReadings { get; set; }

    }
}
