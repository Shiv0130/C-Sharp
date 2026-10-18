// Data/ApplicationDbContext.cs
using ResearchAdmin.Models;
using Microsoft.EntityFrameworkCore;

namespace ResearchAdmin.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // TODO: DbSet for FundingAgencies, LeadResearchers, GrantAwards
        public DbSet<FundingAgency> FundingAgencies { get; set; }
        public DbSet<LeadResearcher> LeadResearchers { get; set; }
        public DbSet<GrantAward> GrantAwards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // TODO: HasPrecision(18, 2) on AwardedAmount
            modelBuilder.Entity<GrantAward>()
                .Property(g => g.AwardedAmount)
                .HasPrecision(18, 2);
        }
    }
}