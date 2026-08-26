using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mvcMovieWatchList.Models;

namespace mvcMovieWatchList.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<WatchListEntry> WatchListEntries { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Before establishing relationships i was supposed to configure the composite pk for WatchListEntry.
            //How do i do this? This is how you do it. You can use the HasKey method to configure a composite primary key for the WatchListEntry entity. In this case, you want to use both UserId and MovieId as the composite primary key. Here's how you can do it:

            //Look at it now? Is my code correct? Yes, your code is correct. You have defined the composite primary key for the WatchListEntry entity using the HasKey method, and you have also established the relationships between WatchListEntry, User, and Movie entities with the appropriate foreign keys and delete behaviors.
            //So i did have to have 3 entities in the dbcontext? Yes, you need to have three DbSet properties in your ApplicationDbContext for the three entities: WatchListEntry, User, and Movie. This allows Entity Framework Core to manage these entities and their relationships in the database.

            builder.Entity<WatchListEntry>()
                .HasKey(w => new { w.UserId, w.MovieId });

            builder.Entity<WatchListEntry>()
                .HasOne(w => w.User)
                .WithMany(u => u.WatchListEntries)
                .HasForeignKey(w=> w.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<WatchListEntry>()
                .HasOne(w => w.Movie)
                .WithMany(m => m.WatchListEntries)
                .HasForeignKey(w => w.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            




        }
    }
}
