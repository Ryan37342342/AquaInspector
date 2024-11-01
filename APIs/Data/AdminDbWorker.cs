using Microsoft.EntityFrameworkCore;
namespace AquaInspector.Data
{
    public class AdminDbWorker:DbContext 
    {
        // Constructor to support dependency injection
        public AdminDbWorker(DbContextOptions<AdminDbWorker> options) : base(options)
        {
        
        }

    }
}
