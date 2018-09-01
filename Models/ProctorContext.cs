using Microsoft.EntityFrameworkCore;
 
namespace Proctors.Models
{
    public class ProctorsContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public ProctorsContext(DbContextOptions<ProctorsContext> options) : base(options) { }
        public DbSet<Proctor> Proctor { get; set; }
        public DbSet<Location> Location { get; set; }

        public DbSet<ProctorLocation> Proctors_Location { get; set; }
    }
}