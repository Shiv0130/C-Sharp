// GIVEN FILE: a ROUGH keyword check of your typed theory answers in Theory/*.md.
// It is NOT the marker. It looks for the key ideas from each file's rubric in your "My answer" section.
// A green tick here means "you hit the key terms". Then read the rubric yourself and judge your wording.
using System.Text.RegularExpressions;
using Xunit;

namespace HospitalApp.Tests;

public class TheoryTests
{
    // ---- where each answer lives -------------------------------------------------------------
    private static readonly Dictionary<string, string> Files = new()
    {
        ["Q1_1"] = "Theory/Q1_1_REST_and_HTTP_methods.md",
        ["Q1_2"] = "Theory/Q1_2_EF_Core_Migrations.md",
        ["Q1_3"] = "Theory/Q1_3_ViewBag_vs_TempData.md",
        ["Q1_4"] = "Theory/Q1_4_Data_Annotations.md",
        ["B1"]   = "Theory/B1_ERD_and_Relationships.md",
        ["B2"]   = "Theory/B2_Seeding.md",
        ["B4"]   = "Theory/B4_Async.md",
    };

    // ---- the rubric points: label -> regex that spots the idea -------------------------------
    private static readonly Dictionary<string, (string label, string regex)[]> Rubric = new()
    {
        ["Q1_1"] = new[]
        {
            ("REST: an architectural style / way of designing web APIs around resources and URLs", @"architectur|style|resource|url|endpoint"),
            ("Statelessness: each request carries everything the server needs", @"stateless|each request|every request|no (client )?(state|session)|not (store|keep|remember)|does ?n[o']t (store|keep|remember)"),
            ("Statelessness: the server remembers nothing about the client between requests", @"(not|n't|never|no)\W+(\w+\W+){0,4}(store|keep|remember|session|state|memory)|stateless"),
            ("GET = Read", @"GET\W{1,12}(\w+\W+){0,4}(read|retriev|fetch|select|get data|view)"),
            ("POST = Create", @"POST\W{1,12}(\w+\W+){0,4}(creat|add|insert|submit)"),
            ("PUT = Update", @"PUT\W{1,12}(\w+\W+){0,4}(updat|replac|modif|edit)"),
            ("DELETE = Delete", @"DELETE\W{1,12}(\w+\W+){0,4}(delet|remov)"),
        },
        ["Q1_2"] = new[]
        {
            ("A migration = a C# file/class that describes a change to the database schema", @"migration.{0,80}(schema|structure|tables?|changes?|database)"),
            ("It keeps the database in sync with the model classes / is version control for the schema", @"sync|keep.{0,30}(match|up to date)|version|history|track|in line with|match(es)? the model"),
            ("Command 1 (create): dotnet ef migrations add <Name> (or Add-Migration)", @"migrations\s+add|Add-Migration"),
            ("Command 2 (apply): dotnet ef database update (or Update-Database)", @"database\s+update|Update-Database"),
        },
        ["Q1_3"] = new[]
        {
            ("ViewBag: passes data from controller to view for the CURRENT request only", @"ViewBag.{0,160}(current|this|same|one|single)\W+(http\W+)?request|ViewBag.{0,160}(lost|gone|cleared|disappear|does ?n[o']t survive)"),
            ("ViewBag is a dynamic wrapper around ViewData", @"dynamic|ViewData"),
            ("TempData survives a redirect / lives until the next request", @"TempData.{0,200}(redirect|next request|second request|survive|persist|two requests)"),
            ("TempData is removed once it has been read (Keep/Peek keep it)", @"read|removed|deleted|cleared|Keep|Peek"),
            ("Example scenario: success/error message after a POST then redirect", @"(message|notification|alert).{0,200}(redirect|after (a )?(post|save|submit|creat))|(redirect|after (a )?(post|save|submit|creat)).{0,200}(message|notification|alert)"),
        },
        ["Q1_4"] = new[]
        {
            ("Purpose: attributes on model properties that add validation rules / metadata", @"valid|rules?|metadata|attribute|constraint"),
            ("They are checked by MVC (ModelState.IsValid) and/or used by EF Core for the database schema", @"ModelState|IsValid|schema|column|database|EF"),
            ("Example 1: names an annotation AND says what it enforces", @"\[?(Required|StringLength|Range|MaxLength|MinLength|EmailAddress|RegularExpression|Key|Compare|Phone)\]?"),
            ("Example 2: a different annotation AND what it enforces", "#TWO_DISTINCT_ATTRIBUTES#"),
        },
        ["B1"] = new[]
        {
            ("Entities shown: Doctor and Patient", @"(?s)(?=.*Doctor)(?=.*Patient)"),
            ("Primary keys marked (PK)", @"\bPK\b|primary key"),
            ("Foreign key marked (FK) on the many side", @"\bFK\b|foreign key"),
            ("One-to-many: one Doctor has many Patients (1 to *, 1:N...)", @"one.to.many|1\s*(:|to|-|\.\.)\s*(\*|n|m|many)|1\s*:\s*\*|\b1\b.{0,10}\*"),
            ("Many-to-many needs a join table (DoctorPatient)", @"many.to.many|join(ing)? table|DoctorPatient"),
            ("The join table has a composite key made of both ids", @"composite"),
        },
        ["B2"] = new[]
        {
            ("Seeding = putting starting data in the database when it is created/migrated", @"seed|initial data|starting data|pre.?populat|default data"),
            ("Done with HasData inside OnModelCreating", @"HasData"),
            ("Primary keys must be supplied explicitly", @"(primary key|\bid\b|key).{0,80}(explicit|manual|supply|provide|specify|yourself)|(explicit|manual|supply|provide|specify).{0,60}(primary key|\bid\b|key)"),
            ("A new migration is needed after changing seed data (migrations add)", @"migration"),
        },
        ["B4"] = new[]
        {
            ("async/await lets the thread be freed while waiting for the database (non-blocking)", @"block|free|released|available|other requests|wait"),
            ("Return type is Task / Task<IActionResult>", @"Task"),
            ("The Async twins: ToListAsync / SaveChangesAsync / FindAsync", @"(ToListAsync|SaveChangesAsync|FindAsync)"),
            ("Benefit: scalability / responsiveness under many users", @"scal|responsive|many (users|requests)|throughput|performance"),
        },
    };

    // ---- reading the My answer section -------------------------------------------------------
    private static string Answer(string tag)
    {
        var text = Need.ReadFile(Files[tag]);
        var m = Regex.Match(text, @"(?ms)^##\s*My answer\s*$(.*?)(?=^##\s|\z)");
        if (!m.Success) Need.Fail($"I can't find the '## My answer' heading in {Files[tag]}.");
        var body = Regex.Replace(m.Groups[1].Value, @"<!--.*?-->", "", RegexOptions.Singleline);
        return body.Trim();
    }

    private static void Check(string tag, int index)
    {
        var ans = Answer(tag);
        if (ans.Length == 0) Need.Fail($"Your answer is empty. Open {Files[tag]} and type under '## My answer'.");
        var (label, regex) = Rubric[tag][index];
        bool ok;
        if (regex == "#TWO_DISTINCT_ATTRIBUTES#")
        {
            ok = Regex.Matches(ans, @"(Required|StringLength|Range|MaxLength|MinLength|EmailAddress|RegularExpression|Key|Compare|Phone)", RegexOptions.IgnoreCase)
                      .Select(x => x.Value.ToLowerInvariant()).Distinct().Count() >= 2;
        }
        else ok = Regex.IsMatch(ans, regex, RegexOptions.IgnoreCase | RegexOptions.Singleline);
        if (!ok) Need.Fail($"Not spotted yet: {label}");
    }

    private static IEnumerable<object[]> Points(string tag) =>
        Rubric[tag].Select((r, i) => new object[] { i });

    // ---- the tests (one group per question) --------------------------------------------------
    [Fact] public void Q1_1_answer_is_written() => Written("Q1_1");
    [Fact] public void Q1_2_answer_is_written() => Written("Q1_2");
    [Fact] public void Q1_3_answer_is_written() => Written("Q1_3");
    [Fact] public void Q1_4_answer_is_written() => Written("Q1_4");
    [Fact] public void B1_answer_is_written() => Written("B1");
    [Fact] public void B2_answer_is_written() => Written("B2");
    [Fact] public void B4_answer_is_written() => Written("B4");

    private static void Written(string tag)
    {
        var words = Regex.Matches(Answer(tag), @"\w+").Count;
        if (words < 25) Need.Fail($"Answer is too short ({words} words). Write a full answer in {Files[tag]}.");
    }

    public static IEnumerable<object[]> P_Q1_1() => Points("Q1_1");
    public static IEnumerable<object[]> P_Q1_2() => Points("Q1_2");
    public static IEnumerable<object[]> P_Q1_3() => Points("Q1_3");
    public static IEnumerable<object[]> P_Q1_4() => Points("Q1_4");
    public static IEnumerable<object[]> P_B1() => Points("B1");
    public static IEnumerable<object[]> P_B2() => Points("B2");
    public static IEnumerable<object[]> P_B4() => Points("B4");

    [Theory, MemberData(nameof(P_Q1_1))] public void Q1_1_rubric_point(int point) => Check("Q1_1", point);
    [Theory, MemberData(nameof(P_Q1_2))] public void Q1_2_rubric_point(int point) => Check("Q1_2", point);
    [Theory, MemberData(nameof(P_Q1_3))] public void Q1_3_rubric_point(int point) => Check("Q1_3", point);
    [Theory, MemberData(nameof(P_Q1_4))] public void Q1_4_rubric_point(int point) => Check("Q1_4", point);
    [Theory, MemberData(nameof(P_B1))]   public void B1_rubric_point(int point) => Check("B1", point);
    [Theory, MemberData(nameof(P_B2))]   public void B2_rubric_point(int point) => Check("B2", point);
    [Theory, MemberData(nameof(P_B4))]   public void B4_rubric_point(int point) => Check("B4", point);
}
