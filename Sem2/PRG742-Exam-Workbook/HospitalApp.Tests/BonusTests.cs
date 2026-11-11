// GIVEN FILE: auto-checks for the bonus drills B2 to B7. Don't edit.
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using Xunit;

namespace HospitalApp.Tests;

public class BonusSeedingTests
{
    [Fact]
    public void B2_HasData_seeds_at_least_3_doctors()
    {
        _ = Need.Patient;
        using var db = new TestDb();
        Assert.True(db.All(Need.Doctor).Count >= 3, "Seed at least 3 doctors with HasData (ids 1, 2, 3).");
    }

    [Fact]
    public void B2_HasData_seeds_at_least_2_patients_that_point_at_real_doctors()
    {
        _ = Need.Patient;
        using var db = new TestDb();   // EnsureCreated would fail on a bad foreign key
        var patients = db.All(Need.Patient);
        Assert.True(patients.Count >= 2, "Seed at least 2 patients with HasData (ids 1, 2).");
        var doctorIds = db.All(Need.Doctor).Select(d => (int)Need.Get(d, "DoctorId")).ToHashSet();
        Assert.All(patients, p => Assert.Contains((int)Need.Get(p, "DoctorId"), doctorIds));
    }
}

public class BonusRelationshipTests
{
    private const string F = "DoctorsController.cs";
    private static Type Ctl => Need.Controller("DoctorsController", F);

    [Fact]
    public void B3_DoctorsController_takes_DbContext_by_constructor_DI()
    {
        using var db = new TestDb();
        using var ctx = db.NewContext();
        _ = Run.NewController(Ctl, ctx, "Controllers/" + F);
    }

    [Fact]
    public async Task B3_Doctors_Index_loads_each_doctor_with_their_Patients_using_Include()
    {
        using var db = new TestDb();
        db.Add(db.NewDoctor(101, "Dr Include"));
        db.Add(db.NewPatient(301, "Has Doctor", 40, 101));
        using var ctx = db.NewContext();      // brand-new context: nothing is tracked, so only Include can fill Patients
        var c = Run.NewController(Ctl, ctx, "Controllers/" + F);
        var result = await Run.Call(Need.Action(Ctl, "Index"), c);

        var view = Assert.IsType<ViewResult>(result);
        var docs = Assert.IsAssignableFrom<System.Collections.IEnumerable>(view.Model).Cast<object>().ToList();
        var mine = docs.First(d => (int)Need.Get(d, "DoctorId") == 101);
        var patients = Need.Get(mine, "Patients") as System.Collections.IEnumerable;
        if (patients == null) Need.Fail("doctor.Patients is null. Add .Include(d => d.Patients) before ToListAsync().");
        Assert.Single(patients.Cast<object>());
    }
}

public class BonusAsyncTests
{
    [Fact]
    public void B4_Patients_Index_and_Create_POST_return_Task_of_IActionResult()
    {
        var ctl = Need.Controller("PatientsController", "PatientsController.cs");
        Assert.Equal(typeof(Task<IActionResult>), Need.Action(ctl, "Index").ReturnType);
        Assert.Equal(typeof(Task<IActionResult>), Need.Action(ctl, "Create", Need.IsPost).ReturnType);
    }

    [Fact]
    public void B4_Doctors_Index_is_async()
    {
        var ctl = Need.Controller("DoctorsController", "DoctorsController.cs");
        Assert.Equal(typeof(Task<IActionResult>), Need.Action(ctl, "Index").ReturnType);
    }

    [Fact]
    public void B4_controllers_use_ToListAsync_and_SaveChangesAsync_with_await()
    {
        var src = Need.CSharp("HospitalApp/Controllers/PatientsController.cs") + Need.CSharp("HospitalApp/Controllers/DoctorsController.cs");
        Need.Must(src, @"await\s+[^;]*\.ToListAsync\s*\(", "Use  await ... .ToListAsync()  to load lists.");
        Need.Must(src, @"await\s+[^;]*\.SaveChangesAsync\s*\(", "Use  await _context.SaveChangesAsync();  to save.");
        Assert.DoesNotMatch(@"[^A-Za-z]SaveChanges\s*\(", src);
        Assert.DoesNotMatch(@"\.ToList\s*\(\s*\)", src);
    }
}

public class BonusEditDeleteTests
{
    private const string F = "PatientsController.cs";
    private static Type Ctl => Need.Controller("PatientsController", F);

    private static (TestDb db, ApplicationDbContext ctx, Controller c) Arrange(params object[] extra)
    {
        var db = new TestDb();
        db.Add(db.NewDoctor(101));
        db.Add(db.NewPatient(401, "Edit Me", 30, 101));
        var ctx = db.NewContext();
        return (db, ctx, Run.NewController(Ctl, ctx, "Controllers/" + F));
    }

    [Fact]
    public async Task B5_Edit_GET_returns_the_patient_in_a_view()
    {
        var (db, ctx, c) = Arrange();
        using (db) using (ctx)
        {
            var get = Need.Action(Ctl, "Edit", Need.IsGetLike);
            var result = await Run.Call(get, c, 401);
            var view = Assert.IsType<ViewResult>(result);
            Assert.Equal("Edit Me", Need.Get(view.Model, "FullName"));
        }
    }

    [Fact]
    public async Task B5_Edit_GET_unknown_id_returns_NotFound()
    {
        var (db, ctx, c) = Arrange();
        using (db) using (ctx)
        {
            var result = await Run.Call(Need.Action(Ctl, "Edit", Need.IsGetLike), c, 99999);
            Assert.IsType<NotFoundResult>(result);
        }
    }

    [Fact]
    public async Task B5_Edit_POST_valid_updates_the_row_and_redirects_to_Index()
    {
        var (db, ctx, c) = Arrange();
        using (db) using (ctx)
        {
            var post = Need.Action(Ctl, "Edit", Need.IsPost);
            var changed = db.NewPatient(401, "Edited Name", 31, 101);
            var result = await Run.Call(post, c, 401, changed);

            Assert.Equal("Index", Assert.IsType<RedirectToActionResult>(result).ActionName);
            var row = db.All(Need.Patient).First(p => (int)Need.Get(p, "PatientId") == 401);
            Assert.Equal("Edited Name", Need.Get(row, "FullName"));
        }
    }

    [Fact]
    public async Task B5_Delete_GET_returns_the_patient_to_confirm_or_NotFound()
    {
        var (db, ctx, c) = Arrange();
        using (db) using (ctx)
        {
            var get = Need.Action(Ctl, "Delete", Need.IsGetLike);
            Assert.IsType<ViewResult>(await Run.Call(get, c, 401));
            Assert.IsType<NotFoundResult>(await Run.Call(get, c, 99999));
        }
    }

    [Fact]
    public async Task B5_Delete_POST_removes_the_row_and_redirects_to_Index()
    {
        var (db, ctx, c) = Arrange();
        using (db) using (ctx)
        {
            var post = Ctl.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                          .FirstOrDefault(m => Need.IsPost(m) && (m.Name == "DeleteConfirmed" || m.Name == "Delete"));
            if (post == null) Need.Fail("Add a [HttpPost] delete action named DeleteConfirmed with [ActionName(\"Delete\")].");
            var result = await Run.Call(post, c, 401);

            Assert.Equal("Index", Assert.IsType<RedirectToActionResult>(result).ActionName);
            Assert.DoesNotContain(401, db.All(Need.Patient).Select(p => (int)Need.Get(p, "PatientId")));
        }
    }
}

public class BonusDoctorsViewTests
{
    private static string V => Need.Razor("HospitalApp/Views/Doctors/Index.cshtml");

    [Fact] public void B6_model_is_IEnumerable_of_Doctor() =>
        Need.Must(V, @"@model\s+IEnumerable\s*<\s*(HospitalApp\.Models\.)?Doctor\s*>", "Line 1:  @model IEnumerable<HospitalApp.Models.Doctor>");

    [Fact] public void B6_loops_over_the_doctors_and_shows_each_Name() =>
        Need.Must(V, @"@foreach\s*\(\s*var\s+(?<v>\w+)\s+in\s+Model\s*\).*@\k<v>\.Name", "Loop with @foreach over Model and print @doctor.Name");

    [Fact] public void B6_uses_an_if_on_the_Patients_collection() =>
        Need.Must(V, @"@if\s*\([^)]*\.Patients", "Use @if (doctor.Patients.Any()) { ... }");

    [Fact] public void B6_has_an_else_branch() =>
        Need.Must(V, @"\}\s*else\s*\{", "Add an else { <p>No patients yet.</p> } branch.");

    [Fact] public void B6_nested_foreach_shows_each_patient_FullName() =>
        Need.Must(V, @"@foreach\s*\(\s*var\s+(?<p>\w+)\s+in\s+\w+\.Patients\s*\).*@\k<p>\.FullName", "Inside the @if, loop over doctor.Patients and print @patient.FullName");
}

public class BonusMigrationTests
{
    [Fact]
    public void B7_a_migration_has_been_created_with_dotnet_ef_migrations_add()
    {
        var found = Need.App.GetTypes().Any(t => typeof(Migration).IsAssignableFrom(t) && !t.IsAbstract);
        if (!found) Need.Fail("No migration yet. In the HospitalApp folder run:  dotnet ef migrations add InitialCreate   (then rebuild)");
    }

    [Fact]
    public void B7_the_model_snapshot_exists_in_the_Migrations_folder()
    {
        var found = Need.App.GetTypes().Any(t => typeof(Microsoft.EntityFrameworkCore.Infrastructure.ModelSnapshot).IsAssignableFrom(t) && !t.IsAbstract);
        if (!found) Need.Fail("No ModelSnapshot yet. It is created together with your first migration.");
    }
}
