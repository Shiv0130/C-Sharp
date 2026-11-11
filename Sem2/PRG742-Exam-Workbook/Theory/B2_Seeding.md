# B2 (Bonus) Seeding
*Pointer 7: Data Management (seeding)*

## Lesson

**Seeding** = putting starting data into the database automatically, so a fresh database isn't empty (lookup lists, demo rows, an admin user).
In EF Core you seed inside `OnModelCreating` with **HasData**:

```csharp
modelBuilder.Entity<Category>().HasData(
    new Category { CategoryId = 1, Name = "Fiction" },
    new Category { CategoryId = 2, Name = "Science" });
```

Rules to remember:
- You **must supply the primary key** yourself (`CategoryId = 1`). EF needs it to track the row.
- Seeded rows that have a foreign key need their parent seeded as well.
- Seed data is part of the model, so after you change it you add a **new migration** (`dotnet ef migrations add ...`) and update the database.

Practical drill for this is in `ApplicationDbContext.cs` (task c).

## Question

What is database seeding in EF Core, how do you do it, and what must you remember about the primary key and migrations?

## My answer

<!-- Type your answer here, in your own words. Write it like you would in the exam. No peeking at the rubric below until you are done. -->

## Self-check rubric

- [ ] Seeding = inserting initial/starting data when the database is created or migrated
- [ ] Uses HasData in OnModelCreating
- [ ] Primary key values must be specified explicitly
- [ ] Mentions a (new) migration is needed to apply seed changes
