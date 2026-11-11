// GIVEN FILE: auto-checks for Q2.1 and Q2.2. Don't edit. Test names tell you what is checked.
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using HospitalApp.Models;
using Xunit;

namespace HospitalApp.Tests;

public class PatientModelTests
{
    [Fact]
    public void Q2_1_Patient_class_exists_in_HospitalApp_Models()
    {
        var t = Need.Patient;
        if (t.GetProperties().Length == 0) Need.Fail("The Patient class is still an empty shell. Write its properties inside the braces.");
    }

    [Fact]
    public void Q2_1_PatientId_is_int_and_is_the_Key()
    {
        var p = Need.Prop(Need.Patient, "PatientId");
        Assert.Equal(typeof(int), p.PropertyType);
        Need.Attr<KeyAttribute>(p, "PatientId is the primary key.");
    }

    [Fact]
    public void Q2_1_FullName_is_string_and_Required()
    {
        var p = Need.Prop(Need.Patient, "FullName");
        Assert.Equal(typeof(string), p.PropertyType);
        Need.Attr<RequiredAttribute>(p, "FullName must be required.");
    }

    [Fact]
    public void Q2_1_FullName_max_length_is_100()
    {
        var p = Need.Prop(Need.Patient, "FullName");
        var a = Need.Attr<StringLengthAttribute>(p, "FullName has a maximum length of 100.");
        Assert.Equal(100, a.MaximumLength);
    }

    [Fact]
    public void Q2_1_Age_is_int_with_Range_0_to_120()
    {
        var p = Need.Prop(Need.Patient, "Age");
        Assert.Equal(typeof(int), p.PropertyType);
        var r = Need.Attr<RangeAttribute>(p, "Age must be between 0 and 120.");
        Assert.Equal(0, Convert.ToInt32(r.Minimum));
        Assert.Equal(120, Convert.ToInt32(r.Maximum));
    }

    [Fact]
    public void Q2_1_DoctorId_is_int_and_is_a_ForeignKey_to_Doctor()
    {
        var t = Need.Patient;
        var fk = Need.Prop(t, "DoctorId");
        Assert.Equal(typeof(int), fk.PropertyType);
        var onFk = fk.GetCustomAttributes(typeof(ForeignKeyAttribute), true).Cast<ForeignKeyAttribute>().FirstOrDefault();
        var nav = t.GetProperty("Doctor");
        var onNav = nav?.GetCustomAttributes(typeof(ForeignKeyAttribute), true).Cast<ForeignKeyAttribute>().FirstOrDefault();
        var ok = (onFk != null && onFk.Name == "Doctor") || (onNav != null && onNav.Name == "DoctorId");
        if (!ok) Need.Fail("DoctorId needs [ForeignKey(\"Doctor\")]. (Also check: using System.ComponentModel.DataAnnotations.Schema;)");
    }

    [Fact]
    public void Q2_1_Doctor_navigation_property_has_type_Doctor()
    {
        var nav = Need.Prop(Need.Patient, "Doctor");
        Assert.Equal(Need.Doctor, nav.PropertyType);
    }

    [Fact]
    public void Q2_1_validation_rejects_blank_name_and_age_130_but_accepts_a_good_patient()
    {
        var t = Need.Patient;
        bool Valid(object o) => Validator.TryValidateObject(o, new ValidationContext(o), new List<ValidationResult>(), true);

        Assert.True(Valid(Need.Make(t, ("FullName", "Thandi"), ("Age", 30), ("DoctorId", 1))), "A normal patient should be valid.");
        Assert.False(Valid(Need.Make(t, ("FullName", null), ("Age", 30), ("DoctorId", 1))), "Missing name should be invalid.");
        Assert.False(Valid(Need.Make(t, ("FullName", new string('x', 101)), ("Age", 30), ("DoctorId", 1))), "101 characters should be invalid.");
        Assert.False(Valid(Need.Make(t, ("FullName", "Thandi"), ("Age", 130), ("DoctorId", 1))), "Age 130 should be invalid.");
        Assert.False(Valid(Need.Make(t, ("FullName", "Thandi"), ("Age", -1), ("DoctorId", 1))), "Age -1 should be invalid.");
    }
}

public class DbContextTests
{
    private static bool HasDbSet(Type entity) =>
        typeof(ApplicationDbContext).GetProperties().Any(p => p.PropertyType == typeof(DbSet<>).MakeGenericType(entity));

    [Fact]
    public void Q2_2_has_DbSet_for_Patient()
    {
        if (!HasDbSet(Need.Patient)) Need.Fail("ApplicationDbContext needs a  public DbSet<Patient> ...  property.");
    }

    [Fact]
    public void Q2_2_has_DbSet_for_Doctor()
    {
        if (!HasDbSet(Need.Doctor)) Need.Fail("ApplicationDbContext needs a  public DbSet<Doctor> ...  property.");
    }

    [Fact]
    public void Q2_2_has_DbSet_for_DoctorPatient()
    {
        if (!HasDbSet(typeof(DoctorPatient))) Need.Fail("ApplicationDbContext needs a  public DbSet<DoctorPatient> ...  property.");
    }

    [Fact]
    public void Q2_2_DoctorPatient_has_composite_key_DoctorId_and_PatientId()
    {
        _ = Need.Patient;
        using var db = new TestDb(createSchema: false);
        using var ctx = db.NewContext();
        var et = ctx.Model.FindEntityType(typeof(DoctorPatient));
        if (et == null) Need.Fail("DoctorPatient isn't part of the model yet. Add its DbSet first.");
        var key = et.FindPrimaryKey();
        if (key == null) Need.Fail("DoctorPatient has no primary key. Use the Fluent API in OnModelCreating.");
        var names = key.Properties.Select(p => p.Name).OrderBy(n => n).ToList();
        if (!names.SequenceEqual(new[] { "DoctorId", "PatientId" }))
            Need.Fail("The key must be exactly DoctorId + PatientId together. Yours is: " + string.Join(" + ", names));
    }

    [Fact]
    public void Q2_2_calls_base_OnModelCreating_and_database_can_be_created_from_the_model()
    {
        _ = Need.Patient;
        using var db = new TestDb();   // the constructor runs EnsureCreated and fails nicely if the model is broken
        Assert.NotNull(db);
        var src = Need.CSharp("HospitalApp/ApplicationDbContext.cs");
        Need.Must(src, @"base\s*\.\s*OnModelCreating\s*\(\s*modelBuilder\s*\)", "Start OnModelCreating with  base.OnModelCreating(modelBuilder);");
    }

    [Fact]
    public void Q2_2_Fluent_API_is_used_for_the_key_in_OnModelCreating()
    {
        var src = Need.CSharp("HospitalApp/ApplicationDbContext.cs");
        Need.Must(src, @"modelBuilder\s*\.\s*Entity\s*<\s*DoctorPatient\s*>\s*\(\s*\)", "Use modelBuilder.Entity<DoctorPatient>() ...");
        Need.Must(src, @"HasKey\s*\(\s*\w+\s*=>\s*new\s*\{", "Composite keys use  .HasKey(dp => new { ..., ... })");
    }
}
