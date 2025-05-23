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

        // create the temperature reading database
        public DbSet<TemperatureReading> temperature_readings { get; set; }

        // create the logging message database
        public DbSet<LoggingMessage> logging_messages {get; set;}
    }
}
