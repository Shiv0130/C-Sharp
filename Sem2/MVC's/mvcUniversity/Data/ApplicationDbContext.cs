using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using mvcUniversity.Models;

namespace mvcUniversity.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public ApplicationDbContext()
        {            
        }

        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Course> Course { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure the one-to-many relationship between Faculty and Course
            modelBuilder.Entity<Faculty>()
                .HasMany(f => f.Courses)
                .WithOne(c => c.Faculty)
                .HasForeignKey(c => c.FacultyId)
                .OnDelete(DeleteBehavior.Restrict); // Optional: specify delete behavior

        }
    }
}