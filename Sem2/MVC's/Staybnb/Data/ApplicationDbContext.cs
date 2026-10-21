using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Staybnb.Models;

namespace Staybnb.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<HostProperty> HostProperties => Set<HostProperty>();
        public DbSet<PropertyImage> PropertyImages => Set<PropertyImage>();
        public DbSet<Amenity> Amenities => Set<Amenity>();
        public DbSet<Booking> Bookings => Set<Booking>();
        public DbSet<Payment> Payments => Set<Payment>();
        public DbSet<Review> Reviews => Set<Review>();
        public DbSet<WishListItem> WishListItems => Set<WishListItem>();
        public DbSet<Message> Messages => Set<Message>();
        public DbSet<ActivityLog> ActivityLogs => Set<ActivityLog>();
        public DbSet<Notification> Notifications => Set<Notification>();
        public DbSet<HostApplication> HostApplications => Set<HostApplication>();
        public DbSet<CheckInProcess> CheckInProcesses => Set<CheckInProcess>();
        public DbSet<GuestCheckIn> GuestCheckIns => Set<GuestCheckIn>();
        public DbSet<GuestDocument> GuestDocuments => Set<GuestDocument>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<HostProperty>()
                .Property(p => p.PricePerNight).HasPrecision(18, 2);
            builder.Entity<Booking>()
                .Property(b => b.TotalPrice).HasPrecision(18, 2);
            builder.Entity<Payment>()
                .Property(p => p.Amount).HasPrecision(18, 2);

            // HostProperty → Host
            builder.Entity<HostProperty>()
                .HasOne(p => p.Host)
                .WithMany(u => u.Properties)
                .HasForeignKey(p => p.HostId)
                .OnDelete(DeleteBehavior.Restrict);

            // Booking → Guest / Property
            builder.Entity<Booking>()
                .HasOne(b => b.Guest)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.GuestId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Booking>()
                .HasOne(b => b.Property)
                .WithMany(p => p.Bookings)
                .HasForeignKey(b => b.PropertyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Booking ↔ Payment (1:1)
            builder.Entity<Payment>()
                .HasOne(p => p.Booking)
                .WithOne(b => b.Payment)
                .HasForeignKey<Payment>(p => p.BookingId)
                .OnDelete(DeleteBehavior.Cascade);

            // Message sender / receiver
            builder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany(u => u.SentMessages)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            // HostProperty ↔ Amenity (many-to-many)
            builder.Entity<HostProperty>()
                .HasMany(p => p.Amenities)
                .WithMany(a => a.Properties);

            // CheckInProcess 1:1 with property
            builder.Entity<CheckInProcess>()
                .HasOne(c => c.Property)
                .WithOne(p => p.CheckInProcess)
                .HasForeignKey<CheckInProcess>(c => c.PropertyId)
                .OnDelete(DeleteBehavior.Cascade);

            // GuestCheckIn 1:1 with booking
            builder.Entity<GuestCheckIn>()
                .HasOne(g => g.Booking)
                .WithOne(b => b.GuestCheckIn)
                .HasForeignKey<GuestCheckIn>(g => g.BookingId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}