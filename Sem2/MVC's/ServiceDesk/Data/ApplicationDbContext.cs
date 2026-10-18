using Microsoft.EntityFrameworkCore;
using ServiceDesk.Models;

namespace ServiceDesk.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // 1. Register DbSets
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<ItTechnician> ItTechnicians => Set<ItTechnician>();
        public DbSet<SupportTicket> SupportTickets => Set<SupportTicket>();

        // 2. OnModelCreating (no special cascade required for this exercise)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}