using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mvcOfficeDeskAssign.Models;

namespace mvcOfficeDeskAssign.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<DeskAssignment> DeskAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure one-to-one relationship between Employee and DeskAssignment
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.DeskAssignment)
                .WithOne(d => d.Employee)
                .HasForeignKey<DeskAssignment>(d => d.EmpId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}