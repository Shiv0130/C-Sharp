# Reference copy: Mr T. Aphane's PRO742 practice test (HospitalApp)

> My own typed copy of the paper's questions, kept here as a REFERENCE only.
> The exam format is write-from-scratch, so the workbook files do NOT use the paper's fill-in-the-blank layout.
> 100 marks, 3 hours, namespace `HospitalApp`. Written by hand in the real paper.

| # | Topic | Marks | Where you do it in the workbook |
|---|---|---|---|
| 1.1 | RESTful principles and HTTP methods | 5 | `Theory/Q1_1_REST_and_HTTP_methods.md` |
| 1.2 | EF Core migrations + 2 commands | 5 | `Theory/Q1_2_EF_Core_Migrations.md` |
| 1.3 | ViewBag vs TempData + scenario | 5 | `Theory/Q1_3_ViewBag_vs_TempData.md` |
| 1.4 | Data annotations + 2 examples | 5 | `Theory/Q1_4_Data_Annotations.md` |
| 2.1 | Patient model class with annotations | 15 | `HospitalApp/Models/Patient.cs` |
| 2.2 | DbContext, DbSets, Fluent API composite key | 15 | `HospitalApp/ApplicationDbContext.cs` |
| 3.1 | PatientsController: DI, Index GET, Create POST, TempData | 20 | `HospitalApp/Controllers/PatientsController.cs` |
| 3.2 | Create.cshtml with Tag Helpers, TempData, ViewBag dropdown | 15 | `HospitalApp/Views/Patients/Create.cshtml` |
| 3.3 | Index.cshtml table with `@foreach` | 15 | `HospitalApp/Views/Patients/Index.cshtml` |

## The paper's own wording (condensed)

**1.1** Explain the concept of RESTful architecture in Web APIs. State the meaning of "Statelessness" and match the HTTP methods (GET, POST, PUT, DELETE) to their CRUD operations.

**1.2** Briefly explain what a Migration is and list the two main command-line commands used to create and apply a migration.

**1.3** Explain the difference between ViewBag and TempData. Give a short example scenario of when you would use TempData instead of ViewBag.

**1.4** What is the purpose of Data Annotations? Give two examples of validation attributes and explain what each enforces.

**2.1** Write the C# model class for a Patient: PatientId (int, primary key), FullName (string, required, max length 100), Age (int, between 0 and 120), DoctorId (int, foreign key), Doctor (navigation property). Hint: use `[Key]`, `[Required]`, `[StringLength(100)]`, `[Range(0, 120)]`.

**2.2** Complete `ApplicationDbContext`: add DbSets for Patient and for the joining table `DoctorPatient` (DoctorId and PatientId). Hint: composite keys use an anonymous object in the Fluent API, `entity.HasKey(dp => new { dp.DoctorId, dp.PatientId });`.

**3.1** Complete `PatientsController`: the constructor (Dependency Injection) and the bodies of the GET Index and POST Create actions. In POST, set `TempData["SuccessMessage"]` when the save works and `TempData["ErrorMessage"]` when it fails. Hint: check `if (ModelState.IsValid)` before saving; use `TempData["SuccessMessage"] = "Patient created successfully!";`.

**3.2** Write the Razor view for the Patient Create page. Tag Helpers for model binding and validation; show `TempData["SuccessMessage"]` or `TempData["ErrorMessage"]` at the top. Parts: (a) model namespace, (b) page title, (c) success message, (d) error message, (e) form pointing to Create, (f) validation summary, (g,h) FullName label + input + validation span, (i,j) Age label + input + validation span, (k) DoctorId dropdown using ViewBag, (l) submit button, (m) close the form.

**3.3** Write the Razor view for the Patient Index page. It receives a list of patients and loops through them in an HTML table. Hint: `@model IEnumerable<HospitalApp.Models.Patient>` and `@foreach (var item in Model)`. Parts: (a) model, (b) table, (c) loop, (d) show FullName, Age, DoctorId in cells, (e) close the table.

The paper shows no marking memo. Where the workbook gives a likely mark split it is an estimate.
