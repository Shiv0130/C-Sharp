// =====================================================================================
//  Q2.2  DbContext & FLUENT API   [15 marks]     Pointer 2: EF Core   +   Pointer 3: Relationships
//  BONUS B2  SEEDING with HasData                Pointer 7: Data Management
// =====================================================================================
//
//  LESSON
//  ------
//  The DbContext is your app's connection to the database. Think of it as the manager.
//  Inside it, every DbSet<T> is one TABLE you can query:  _context.Books.ToList()
//
//  Two ways to configure your model:
//     1. Data annotations on the model classes (what you did in Q2.1).
//     2. Fluent API inside OnModelCreating (here). Use it for things annotations can't do,
//        and the big one for the exam is the COMPOSITE KEY.
//
//  A composite key = a primary key made of TWO (or more) columns together.
//  It's the classic key for a many-to-many JOIN TABLE. Annotations can't do it, so Fluent API it is.
//
//  WORKED EXAMPLE (Book and Category, a book can be in many categories and vice versa)
//  ------------------------------------------------------------------------------------
//      public class LibraryContext : DbContext
//      {
//          public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }
//
//          public DbSet<Book> Books { get; set; }                // table: Books
//          public DbSet<Category> Categories { get; set; }       // table: Categories
//          public DbSet<BookCategory> BookCategories { get; set; }   // the join table
//
//          protected override void OnModelCreating(ModelBuilder modelBuilder)
//          {
//              base.OnModelCreating(modelBuilder);
//
//              modelBuilder.Entity<BookCategory>()
//                  .HasKey(bc => new { bc.BookId, bc.CategoryId });   // composite key
//          }
//      }
//
//  The  new { a, b }  is an anonymous object. It just means "these two properties, together".
//
//  SEEDING (bonus B2): HasData
//  ---------------------------
//  Want rows in the table from day one? Seed them in OnModelCreating:
//      modelBuilder.Entity<Category>().HasData(
//          new Category { CategoryId = 1, Name = "Fiction" },
//          new Category { CategoryId = 2, Name = "Science" });
//  Rules: you MUST give the primary key yourself (CategoryId = 1). And a seeded row that has a
//  foreign key (like a Patient with a DoctorId) needs its parent seeded too.
//
//  COMMON TRAPS
//  ------------
//  * The DbSet property name is plural by habit (Patients) but the type is singular (Patient).
//  * Forgetting  base.OnModelCreating(modelBuilder);  as the first line.
//  * Writing HasKey(dp => dp.DoctorId, dp.PatientId)  -> wrong. It must be  new { dp.DoctorId, dp.PatientId }.
//  * Without a composite key EF throws "entity type requires a primary key" for the join table.
//  * Seeding without PK values. EF refuses.
//
//  THE TASK
//  --------
//  The constructor is already given (same as the paper). Now write the rest of the class body:
//   (a) [Q2.2]  DbSet properties for Patient, Doctor and DoctorPatient.
//   (b) [Q2.2]  In OnModelCreating, configure the composite key of DoctorPatient
//               (DoctorId + PatientId) with the Fluent API.
//   (c) [B2 bonus]  Seed at least 3 doctors (ids 1, 2, 3) and 2 patients (ids 1, 2) with HasData.
//                   Use real doctor ids on the patients. Do (c) last.
//
//  HINT
//  ----
//  Add  using HospitalApp.Models;  at the top, the entities live there.
//  Names: Patients, Doctors, DoctorPatients (the tests look at the TYPE, so naming is up to you).
//  For (b) start with  modelBuilder.Entity<DoctorPatient>()  and chain  .HasKey(...)
//
// >>>>> WRITE YOUR ANSWER BELOW THIS LINE (replace the empty shell, keep the constructor) <<<<<

using Microsoft.EntityFrameworkCore;
using HospitalApp.Models;

namespace HospitalApp;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    // (a) DbSets
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<DoctorPatient> DoctorPatients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // (b) composite key for the join table
        modelBuilder.Entity<DoctorPatient>()
            .HasKey(dp => new { dp.DoctorId, dp.PatientId });

        // (c) BONUS B2: seed data
        modelBuilder.Entity<Doctor>().HasData(
            new Doctor { DoctorId = 1, Name = "Dr. Naidoo", Specialty = "Cardiology" },
            new Doctor { DoctorId = 2, Name = "Dr. Mokoena", Specialty = "Paediatrics" },
            new Doctor { DoctorId = 3, Name = "Dr. Smith", Specialty = "General Practice" });

        modelBuilder.Entity<Patient>().HasData(
            new Patient { PatientId = 1, FullName = "Thandi Dlamini", Age = 34, DoctorId = 1 },
            new Patient { PatientId = 2, FullName = "Pieter van Wyk", Age = 7, DoctorId = 2 });
    }
}
