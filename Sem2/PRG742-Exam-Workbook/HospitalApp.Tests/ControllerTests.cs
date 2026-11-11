// GIVEN FILE: auto-checks for Q3.1 and the controller side of Q3.2. Don't edit.
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using HospitalApp.Controllers;
using Xunit;

namespace HospitalApp.Tests;

public class PatientsControllerTests
{
    private const string File = "PatientsController.cs";

    private static Type Ctl => Need.Controller("PatientsController", File);

    private static Controller Build(ApplicationDbContext ctx) => Run.NewController(Ctl, ctx, "Controllers/" + File);

    private static MethodInfo CreatePost() =>
        Need.Action(Ctl, "Create", m => Need.IsPost(m) && m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == Need.Patient);

    [Fact]
    public void Q3_1_controller_inherits_Controller_and_takes_DbContext_by_constructor_DI()
    {
        Assert.True(typeof(Controller).IsAssignableFrom(Ctl), "PatientsController must inherit Controller.");
        using var db = new TestDb();
        using var ctx = db.NewContext();
        _ = Build(ctx);   // fails with a friendly message if the DI constructor is missing
    }

    [Fact]
    public void Q3_1_constructor_stores_the_context_in_a_private_readonly_field()
    {
        var field = Ctl.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                       .FirstOrDefault(f => f.FieldType == typeof(ApplicationDbContext));
        if (field == null) Need.Fail("Keep the context in a private field: private readonly ApplicationDbContext _context;");
        Assert.True(field.IsInitOnly, "Make the field readonly.");
    }

    [Fact]
    public async Task Q3_1_Index_returns_a_view_with_all_patients()
    {
        using var db = new TestDb();
        db.Add(db.NewDoctor(101));
        db.Add(db.NewPatient(101, "Ayanda Test", 20, 101), db.NewPatient(102, "Bongani Test", 40, 101));
        using var ctx = db.NewContext();
        var c = Build(ctx);
        var result = await Run.Call(Need.Action(Ctl, "Index"), c);

        var view = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<System.Collections.IEnumerable>(view.Model);
        var names = model.Cast<object>().Select(p => (string)Need.Get(p, "FullName")).ToList();
        Assert.Contains("Ayanda Test", names);
        Assert.Contains("Bongani Test", names);
    }

    [Fact]
    public void Q3_1_Index_has_HttpGet_and_is_async()
    {
        var m = Need.Action(Ctl, "Index");
        Assert.NotNull(m.GetCustomAttribute<HttpGetAttribute>());
        Assert.Equal(typeof(Task<IActionResult>), m.ReturnType);
    }

    [Fact]
    public void Q3_1_Create_POST_has_HttpPost_and_ValidateAntiForgeryToken()
    {
        var m = CreatePost();
        Assert.NotNull(m.GetCustomAttribute<ValidateAntiForgeryTokenAttribute>());
        Assert.NotNull(m.GetParameters()[0].GetCustomAttribute<BindAttribute>());
    }

    [Fact]
    public async Task Q3_1_Create_POST_valid_saves_the_patient()
    {
        using var db = new TestDb();
        db.Add(db.NewDoctor(101));
        using var ctx = db.NewContext();
        var c = Build(ctx);
        var patient = db.NewPatient(201, "Zanele Saved", 28, 101);
        await Run.Call(CreatePost(), c, patient);

        var saved = db.All(Need.Patient).Select(p => (string)Need.Get(p, "FullName"));
        Assert.Contains("Zanele Saved", saved);
    }

    [Fact]
    public async Task Q3_1_Create_POST_valid_sets_TempData_SuccessMessage()
    {
        using var db = new TestDb();
        db.Add(db.NewDoctor(101));
        using var ctx = db.NewContext();
        var c = Build(ctx);
        await Run.Call(CreatePost(), c, db.NewPatient(202, "Sipho Msg", 50, 101));

        Assert.True(c.TempData.ContainsKey("SuccessMessage"), "TempData[\"SuccessMessage\"] was not set.");
        Assert.False(string.IsNullOrWhiteSpace(c.TempData["SuccessMessage"]?.ToString()));
        Assert.False(c.TempData.ContainsKey("ErrorMessage"), "A successful save should not set ErrorMessage.");
    }

    [Fact]
    public async Task Q3_1_Create_POST_valid_redirects_to_Index()
    {
        using var db = new TestDb();
        db.Add(db.NewDoctor(101));
        using var ctx = db.NewContext();
        var c = Build(ctx);
        var result = await Run.Call(CreatePost(), c, db.NewPatient(203, "Lerato Redirect", 33, 101));

        var redirect = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirect.ActionName);
    }

    [Fact]
    public async Task Q3_1_Create_POST_invalid_returns_the_same_view_with_the_same_model()
    {
        using var db = new TestDb();
        db.Add(db.NewDoctor(101));
        using var ctx = db.NewContext();
        var c = Build(ctx);
        c.ModelState.AddModelError("FullName", "The FullName field is required.");
        var patient = db.NewPatient(204, null, 33, 101);
        var result = await Run.Call(CreatePost(), c, patient);

        var view = Assert.IsType<ViewResult>(result);
        Assert.Same(patient, view.Model);
    }

    [Fact]
    public async Task Q3_1_Create_POST_invalid_sets_TempData_ErrorMessage_and_does_not_save()
    {
        using var db = new TestDb();
        db.Add(db.NewDoctor(101));
        using var ctx = db.NewContext();
        var c = Build(ctx);
        c.ModelState.AddModelError("Age", "Range");
        await Run.Call(CreatePost(), c, db.NewPatient(205, "Nobody Saved", 999, 101));

        Assert.True(c.TempData.ContainsKey("ErrorMessage"), "TempData[\"ErrorMessage\"] was not set for the invalid model.");
        Assert.False(c.TempData.ContainsKey("SuccessMessage"));
        Assert.DoesNotContain("Nobody Saved", db.All(Need.Patient).Select(p => (string)Need.Get(p, "FullName")));
    }

    // ---- Q3.2 controller side: the ViewBag dropdown ----

    [Fact]
    public async Task Q3_2_GET_Create_returns_a_view_and_fills_ViewBag_DoctorId_with_the_doctors()
    {
        using var db = new TestDb();
        db.Add(db.NewDoctor(101, "Dr Alpha"), db.NewDoctor(102, "Dr Beta"));
        using var ctx = db.NewContext();
        var c = Build(ctx);
        var get = Need.Action(Ctl, "Create", Need.IsGetLike);
        var result = await Run.Call(get, c);

        Assert.IsType<ViewResult>(result);
        var items = c.ViewData["DoctorId"] as IEnumerable<SelectListItem>;
        if (items == null) Need.Fail("ViewBag.DoctorId must be a SelectList of doctors (value DoctorId, text Name).");
        var texts = items.Select(i => i.Text).ToList();
        Assert.Contains("Dr Alpha", texts);
        Assert.Contains("Dr Beta", texts);
        Assert.Contains("101", items.Select(i => i.Value));
    }

    [Fact]
    public async Task Q3_2_invalid_POST_refills_the_dropdown_before_showing_the_form_again()
    {
        using var db = new TestDb();
        db.Add(db.NewDoctor(101, "Dr Alpha"));
        using var ctx = db.NewContext();
        var c = Build(ctx);
        c.ModelState.AddModelError("FullName", "required");
        await Run.Call(CreatePost(), c, db.NewPatient(206, null, 10, 101));

        var items = c.ViewData["DoctorId"] as IEnumerable<SelectListItem>;
        if (items == null || !items.Any()) Need.Fail("When the model is invalid you re-show the form, so fill ViewBag.DoctorId again before return View(patient).");
    }
}
