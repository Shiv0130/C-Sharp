using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using mvcVehicle.Models;
namespace mvcVehicle.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<GpsTracker> GpsTracker { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.GpsTracker)
                .WithOne(g => g.Vehicle)
                .HasForeignKey<GpsTracker>(g => g.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}