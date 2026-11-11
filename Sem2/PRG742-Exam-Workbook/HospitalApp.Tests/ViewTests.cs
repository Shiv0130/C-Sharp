// GIVEN FILE: auto-checks for Q3.2 and Q3.3. The views are read as TEXT (Razor comments are ignored).
using Xunit;

namespace HospitalApp.Tests;

public class CreateViewTests
{
    private const string F = "HospitalApp/Views/Patients/Create.cshtml";
    private static string V => Need.Razor(F);

    [Fact] public void Q3_2_declares_the_model_as_Patient() =>
        Need.Must(V, @"(?m)^\s*@model\s+(HospitalApp\.Models\.)?Patient\s*$", "Line 1 of the view should be  @model HospitalApp.Models.Patient");

    [Fact] public void Q3_2_sets_the_page_title() =>
        Need.Must(V, @"ViewData\[\s*""Title""\s*\]\s*=|ViewBag\.Title\s*=", "Set the title:  @{ ViewData[\"Title\"] = \"...\"; }");

    [Fact] public void Q3_2_shows_TempData_SuccessMessage_only_if_it_exists() =>
        Need.Must(V, @"@if\s*\(\s*TempData\[\s*""SuccessMessage""\s*\]\s*!=\s*null\s*\).*TempData\[\s*""SuccessMessage""\s*\]\s*[<}]", "Use @if (TempData[\"SuccessMessage\"] != null) { <div>@TempData[\"SuccessMessage\"]</div> }");

    [Fact] public void Q3_2_shows_TempData_ErrorMessage_only_if_it_exists() =>
        Need.Must(V, @"@if\s*\(\s*TempData\[\s*""ErrorMessage""\s*\]\s*!=\s*null\s*\).*TempData\[\s*""ErrorMessage""\s*\]\s*[<}]", "Use @if (TempData[\"ErrorMessage\"] != null) { <div>@TempData[\"ErrorMessage\"]</div> }");

    [Fact] public void Q3_2_form_posts_to_the_Create_action_using_tag_helper() =>
        Need.Must(V, @"<form(?=[^>]*asp-action\s*=\s*""Create"")(?=[^>]*method\s*=\s*""post"")[^>]*>", "<form asp-action=\"Create\" method=\"post\"> is the form tag.");

    [Fact] public void Q3_2_form_is_closed() => Need.Must(V, @"</form\s*>", "Close the form with </form>.");

    [Fact] public void Q3_2_has_a_validation_summary() =>
        Need.Must(V, @"asp-validation-summary\s*=", "Add  <div asp-validation-summary=\"ModelOnly\"></div>");

    [Fact] public void Q3_2_FullName_has_label_input_and_validation_span() =>
        Group("FullName");

    [Fact] public void Q3_2_Age_has_label_input_and_validation_span() =>
        Group("Age");

    private void Group(string prop)
    {
        Need.Must(V, $@"<label[^>]*asp-for\s*=\s*""{prop}""", $"<label asp-for=\"{prop}\"> is missing.");
        Need.Must(V, $@"<input[^>]*asp-for\s*=\s*""{prop}""", $"<input asp-for=\"{prop}\" /> is missing.");
        Need.Must(V, $@"<span[^>]*asp-validation-for\s*=\s*""{prop}""", $"<span asp-validation-for=\"{prop}\"> is missing.");
    }

    [Fact] public void Q3_2_doctor_dropdown_is_a_select_bound_to_DoctorId_and_filled_from_ViewBag() =>
        Need.Must(V, @"<select(?=[^>]*asp-for\s*=\s*""DoctorId"")(?=[^>]*asp-items\s*=\s*""[^""]*ViewBag)[^>]*>", "<select asp-for=\"DoctorId\" asp-items=\"ViewBag.DoctorId\"></select>");

    [Fact] public void Q3_2_has_a_submit_button() =>
        Need.Must(V, @"<button(?![^>]*type\s*=\s*""(button|reset)"")[^>]*>|<input[^>]*type\s*=\s*""submit""", "Add a submit button: <button type=\"submit\">Create</button>");
}

public class IndexViewTests
{
    private const string F = "HospitalApp/Views/Patients/Index.cshtml";
    private static string V => Need.Razor(F);

    [Fact] public void Q3_3_model_is_IEnumerable_of_Patient() =>
        Need.Must(V, @"@model\s+IEnumerable\s*<\s*(HospitalApp\.Models\.)?Patient\s*>", "Line 1:  @model IEnumerable<HospitalApp.Models.Patient>");

    [Fact] public void Q3_3_has_the_Patient_List_heading() =>
        Need.Must(V, @"<h[1-6][^>]*>\s*Patient List\s*</h[1-6]>", "Add a heading:  <h2>Patient List</h2>");

    [Fact] public void Q3_3_has_an_HTML_table_with_header_cells_for_Full_Name_Age_Doctor_ID()
    {
        Need.Must(V, @"<table[^>]*>", "Add a <table>.");
        Need.Must(V, @"<thead", "Add a <thead> with the heading row.");
        Need.Must(V, @"<th[^>]*>\s*Full\s*Name\s*</th>", "Header cell: Full Name");
        Need.Must(V, @"<th[^>]*>\s*Age\s*</th>", "Header cell: Age");
        Need.Must(V, @"<th[^>]*>\s*Doctor\s*ID\s*</th>", "Header cell: Doctor ID");
    }

    [Fact] public void Q3_3_loops_over_Model_with_foreach() =>
        Need.Must(V, @"@foreach\s*\(\s*var\s+\w+\s+in\s+Model\s*\)", "Loop:  @foreach (var item in Model) { ... }");

    [Fact] public void Q3_3_the_table_row_is_inside_the_loop() =>
        Need.Must(V, @"@foreach\s*\(\s*var\s+\w+\s+in\s+Model\s*\)\s*\{.*?<tr[^>]*>.*?</tr>.*?\}", "Put <tr> ... </tr> inside the foreach braces.");

    [Fact] public void Q3_3_shows_FullName_Age_and_DoctorId_in_cells()
    {
        foreach (var p in new[] { "FullName", "Age", "DoctorId" })
            Need.Must(V, $@"@foreach\s*\(\s*var\s+(?<v>\w+)\s+in\s+Model\s*\).*?<td[^>]*>\s*(@\k<v>\.{p}\b|@Html\.DisplayFor\([^)]*\k<v>\.{p}\))\s*</td>", $"A <td> that shows {p}:  <td>@item.{p}</td>");
    }

    [Fact] public void Q3_3_table_is_closed() => Need.Must(V, @"</table\s*>", "Close the table with </table>.");
}
