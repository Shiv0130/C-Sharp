using Microsoft.EntityFrameworkCore;
using mvcCEMH.Models;

namespace mvcCEMH.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<CorporateStaff> CorporateStaffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure the self-referencing relationship for CorporateStaff
            modelBuilder.Entity<CorporateStaff>()
                .HasOne(cs => cs.Manager)
                .WithMany(cs => cs.DirectReports)
                .HasForeignKey(cs => cs.ManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull); // prevents cascading deletes, allowing for null ManagerId when a manager is deleted
        }
    }
}
