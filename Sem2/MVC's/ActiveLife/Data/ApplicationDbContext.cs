using ActiveLife.Models;
using Microsoft.EntityFrameworkCore;

namespace ActiveLife.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<FitnessTrainer> FitnessTrainers => Set<FitnessTrainer>();
        public DbSet<GymMember> GymMembers => Set<GymMember>();
        public DbSet<PersonalTrainingSession> PersonalTrainingSessions => Set<PersonalTrainingSession>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PersonalTrainingSession>()
                .Property(s => s.SessionFee)
                .HasPrecision(18, 2);
        }
    }
}