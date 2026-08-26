using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_Crud_App.Models;

namespace MVC_Crud_App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }
        //this is how we create tables to match our models
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        //public DbSet<Category> Categories { get; set; }

        //public DbSet<Book> Books { get; set; }


        //this is routine, when defining relationships, we start with dependent entity
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Standard!
            base.OnModelCreating(builder);

            builder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            /*builder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);*/

            //1. which entity between the two is the dependent entity (always start with dependent)
            //2. Consider the defined navigation properties
            //3. Configure the relationship based on the nav properties
            //4. Configure the foriegn key relationship
            //5. If required, set OnDelete action

        }

        //When configuring relationship bet two entities, the dependant entity must include the primary key of the independent entity as a foreign key. The dependent entity is the one that contains the foreign key property, while the independent entity is the one that does not contain the foreign key property. In this case, Employee is the dependent entity because it contains the DepartmentId foreign key property, while Department is the independent entity because it does not contain any foreign key properties.
    }
}
