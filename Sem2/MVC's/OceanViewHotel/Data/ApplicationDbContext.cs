using OceanViewHotel.Models;
using Microsoft.EntityFrameworkCore;

namespace OceanViewHotel.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<HotelRoom> HotelRooms => Set<HotelRoom>();
        public DbSet<Guest> Guests => Set<Guest>();
        public DbSet<RoomBooking> RoomBookings => Set<RoomBooking>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HotelRoom>()
                .Property(r => r.BaseRatePerNight)
                .HasPrecision(18, 2);

            modelBuilder.Entity<RoomBooking>()
                .Property(b => b.TotalCharge)
                .HasPrecision(18, 2);
        }
    }
}