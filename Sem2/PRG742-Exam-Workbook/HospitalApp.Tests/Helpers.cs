// GIVEN FILE: test plumbing. You do not edit this. (Reading it is fine, nothing in here is your answer.)
//
// Why reflection? Your project must still COMPILE while you haven't written Patient yet.
// So the tests look your classes up by NAME at runtime. If something is missing, the test fails
// with a plain-English message that tells you which file to open.
using System.Collections;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using HospitalApp;
using Xunit;
using Xunit.Sdk;

namespace HospitalApp.Tests;

public static class Need
{
    public static Assembly App => Assembly.Load("HospitalApp");

    public static void Fail(string message) => throw new XunitException("\n  >> " + message);

    public static Type Type(string fullName, string file)
    {
        var t = App.GetType(fullName);
        if (t == null) Fail($"I can't find the class {fullName}. Write it in {file}.");
        return t;
    }

    public static Type Patient => Type("HospitalApp.Models.Patient", "HospitalApp/Models/Patient.cs");
    public static Type Doctor => Type("HospitalApp.Models.Doctor", "HospitalApp/Models/Doctor.cs");

    public static PropertyInfo Prop(Type t, string name)
    {
        var p = t.GetProperty(name, BindingFlags.Public | BindingFlags.Instance);
        if (p == null) Fail($"{t.Name} has no public property called {name} (with {{ get; set; }}).");
        return p;
    }

    public static T Attr<T>(MemberInfo m, string because) where T : Attribute
    {
        var a = m.GetCustomAttribute<T>();
        if (a == null) Fail($"{m.DeclaringType.Name}.{m.Name} is missing [{typeof(T).Name.Replace("Attribute", "")}]: {because}");
        return a;
    }

    public static object Make(Type t, params (string name, object value)[] values)
    {
        var o = Activator.CreateInstance(t);
        foreach (var (name, value) in values) Prop(t, name).SetValue(o, value);
        return o;
    }

    public static object Get(object o, string name) => Prop(o.GetType(), name).GetValue(o);

    public static Type Controller(string name, string file)
    {
        return Type("HospitalApp.Controllers." + name, "HospitalApp/Controllers/" + file);
    }

    public static MethodInfo Action(Type controller, string name, Func<MethodInfo, bool> filter = null)
    {
        var m = controller.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                          .FirstOrDefault(x => x.Name == name && (filter == null || filter(x)));
        if (m == null) Fail($"{controller.Name} has no matching public action method called {name}.");
        return m;
    }

    public static bool IsPost(MethodInfo m) => m.GetCustomAttribute<HttpPostAttribute>() != null;
    public static bool IsGetLike(MethodInfo m) => !IsPost(m);

    /// <summary>Walks up from the test output folder to find the workbook root (the folder holding Theory/).</summary>
    public static string Root()
    {
        var dir = new DirectoryInfo(AppContext.BaseDirectory);
        while (dir != null && !Directory.Exists(Path.Combine(dir.FullName, "Theory"))) dir = dir.Parent;
        if (dir == null) Fail("Can't find the workbook folder (the one that contains Theory/).");
        return dir.FullName;
    }

    public static string ReadFile(string relativePath)
    {
        var path = Path.Combine(Root(), relativePath.Replace('/', Path.DirectorySeparatorChar));
        if (!File.Exists(path)) Fail($"I can't find {relativePath}. Did you rename or delete it?");
        return File.ReadAllText(path);
    }

    /// <summary>Razor file text with the Razor comments and HTML comments removed, so the lessons don't count as your answer.</summary>
    public static string Razor(string relativePath)
    {
        var t = ReadFile(relativePath);
        t = Regex.Replace(t, @"@\*.*?\*@", "", RegexOptions.Singleline);
        t = Regex.Replace(t, @"<!--.*?-->", "", RegexOptions.Singleline);
        return t;
    }

    /// <summary>C# file text with // and /* */ comments removed.</summary>
    public static string CSharp(string relativePath)
    {
        var t = ReadFile(relativePath);
        t = Regex.Replace(t, @"/\*.*?\*/", "", RegexOptions.Singleline);
        t = Regex.Replace(t, @"^\s*//.*$", "", RegexOptions.Multiline);
        t = Regex.Replace(t, @"(?<=[;{}\s])//[^\r\n""]*$", "", RegexOptions.Multiline);
        return t;
    }

    public static void Must(string text, string pattern, string message)
    {
        if (!Regex.IsMatch(text, pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase)) Fail(message);
    }
}

/// <summary>A throw-away SQLite database in memory. One per test, gone when the test ends.</summary>
public sealed class TestDb : IDisposable
{
    private readonly SqliteConnection _conn;

    public TestDb(bool createSchema = true)
    {
        _conn = new SqliteConnection("DataSource=:memory:");
        _conn.Open();
        if (createSchema)
        {
            using var c = NewContext();
            try { c.Database.EnsureCreated(); }
            catch (Exception e)
            {
                Need.Fail("EF could not build the database from your model. Usually a missing key or a typo.\n     " +
                          (e.InnerException ?? e).Message);
            }
        }
    }

    public ApplicationDbContext NewContext()
    {
        var opts = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(_conn).Options;
        return new ApplicationDbContext(opts);
    }

    public void Add(params object[] entities)
    {
        using var c = NewContext();
        try
        {
            foreach (var e in entities) c.Add(e);
            c.SaveChanges();
        }
        catch (Exception e)
        {
            Need.Fail("This test needs your model and DbContext first (finish Q2.1 and Q2.2). EF said: " + (e.InnerException ?? e).Message);
        }
    }

    public List<object> All(Type entity)
    {
        using var c = NewContext();
        try
        {
            var set = typeof(DbContext).GetMethod("Set", Type.EmptyTypes).MakeGenericMethod(entity).Invoke(c, null);
            return ((IEnumerable)set).Cast<object>().ToList();
        }
        catch (Exception e)
        {
            Need.Fail("Can't read " + entity.Name + " rows yet. Finish the DbSets in ApplicationDbContext (Q2.2). EF said: " + (e.InnerException ?? e).Message);
            return null;
        }
    }

    public object NewDoctor(int id, string name = "Dr Test") =>
        Need.Make(Need.Doctor, ("DoctorId", id), ("Name", name), ("Specialty", "GP"));

    public object NewPatient(int id, string name, int age, int doctorId) =>
        Need.Make(Need.Patient, ("PatientId", id), ("FullName", name), ("Age", age), ("DoctorId", doctorId));

    public void Dispose() => _conn.Dispose();
}

public class FakeTempDataProvider : ITempDataProvider
{
    public IDictionary<string, object> LoadTempData(HttpContext context) => new Dictionary<string, object>();
    public void SaveTempData(HttpContext context, IDictionary<string, object> values) { }
}

public static class Run
{
    /// <summary>Builds the controller the way ASP.NET would: handing it a DbContext through the constructor.</summary>
    public static Controller NewController(Type controllerType, ApplicationDbContext ctx, string file)
    {
        var ctor = controllerType.GetConstructors().FirstOrDefault(c =>
        {
            var ps = c.GetParameters();
            return ps.Length == 1 && ps[0].ParameterType.IsAssignableFrom(typeof(ApplicationDbContext));
        });
        if (ctor == null)
            Need.Fail($"{controllerType.Name} needs a public constructor that takes ApplicationDbContext (Dependency Injection). Write it in {file}.");
        var c = (Controller)ctor.Invoke(new object[] { ctx });
        c.ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext() };
        c.TempData = new TempDataDictionary(c.HttpContext, new FakeTempDataProvider());
        return c;
    }

    /// <summary>Calls an action, awaits it if it is async, and gives back the IActionResult.</summary>
    public static async Task<IActionResult> Call(MethodInfo action, Controller controller, params object[] args)
    {
        object result;
        try { result = action.Invoke(controller, args); }
        catch (TargetInvocationException e)
        {
            Need.Fail($"{action.Name} crashed: {(e.InnerException ?? e).GetType().Name}: {(e.InnerException ?? e).Message}");
            throw;
        }
        if (result is Task task)
        {
            try { await task; }
            catch (Exception e) { Need.Fail($"{action.Name} crashed: {e.GetType().Name}: {e.Message}"); }
            result = task.GetType().GetProperty("Result")?.GetValue(task);
        }
        if (result is not IActionResult ar) { Need.Fail($"{action.Name} must return an IActionResult (View, Redirect...)."); return null; }
        return ar;
    }
}
