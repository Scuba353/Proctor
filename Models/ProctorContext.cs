using Microsoft.EntityFrameworkCore;
 
namespace Proctors.Models
{
    public class ProctorContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public ProctorContext(DbContextOptions<ProctorContext> options) : base(options) { }
        public DbSet<Proctor> Proctors { get; set; }
        public DbSet<Location> Locations { get; set; }

        public DbSet<ProctorLocation> Proctors_Locations { get; set; }
    }
}