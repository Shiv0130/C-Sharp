using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mvcCRUD.Models;

namespace mvcCRUD.Data
{
    // Inherits from IdentityDbContext, so this context also manages ASP.NET Core
    // Identity's own tables (AspNetUsers, AspNetRoles, etc.) alongside your app's data.
    public class ApplicationDbContext : IdentityDbContext
    {
        // Options (connection string, provider, etc.) are injected via DI - configured
        // in Program.cs with builder.Services.AddDbContext<ApplicationDbContext>(...).
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Each DbSet<T> maps to a table EF will create/manage for that entity.
        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Must call base first so Identity's own model configuration still runs.
            base.OnModelCreating(modelBuilder);
            // Configure the one-to-many relationship between Department and Employee
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)         // each Employee has one Department
                .WithMany(d => d.Employees)         // each Department has many Employees
                .HasForeignKey(e => e.DepartmentId) // DepartmentId is the FK column
                .OnDelete(DeleteBehavior.Restrict); // prevent deleting a Department that still has Employees



            ////1. Which entity between the two is the dependent entity?
            ////2. Consider the defined navigation proprties.
            ////3. Configure the relationship based on the navigation props
            ////4. Configure the foreign key relationshio
            ////5. If Required, set OnDelete action
        }
    }
}
