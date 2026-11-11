# PRG742 Exam Workbook (HospitalApp)

Alright, here's the deal. This is your PRG742 prep, and you do **all of it inside the IDE**: theory and practical.
Every file **teaches first** (short lesson, a tiny example with Books and Authors, the traps), then gives you the exam task.
You write the answer yourself, from scratch, like the real paper. Then you run one command and the tests tell you how you did.

No answers are in here. They live on a separate branch (`prg742-solutions`). Try first, peek second.

## Open it
- **VS Code:** open the folder `PRG742-Exam-Workbook`.
- **Visual Studio:** open `PRG742-Exam-Workbook.sln`.
- Needs the **.NET 8 SDK or newer** (campus has 8, your laptop has 9). It targets `net8.0` and rolls forward, so it runs on both.
- Wrong machine? From the repo root use `to-net8.bat` (campus) or `to-net9.bat` (laptop), then restore.

## How a question works
1. Open the file named in the table below. Read the **lesson** at the top.
2. Read **The task** and the **hint**. Write your answer under the line `>>>>> WRITE YOUR ANSWER BELOW THIS LINE`.
3. Run the check (from this folder):
   - Mac/Linux/Git Bash: `./check.sh`        Windows PowerShell: `.\check.ps1`
   - One question only: `./check.sh Q2_1`
4. Read what is still red, fix it, run again. Green = done.

The project always builds, even at the start (your answer files begin as empty shells), so the checks run from minute one.
Just start with the empty shells and fill them in.

## Theory
Open the file in `Theory/`. Read the lesson. Type your answer under `## My answer`, in your own words, like you would on paper.
`check.sh` does a **rough keyword check** of your answer against the rubric (it can't read like a marker).
After it passes, tick the rubric boxes in the file honestly yourself. The rubric is a list of ideas, not a model answer.

## Run the app for real
```
cd HospitalApp
dotnet run
```
Then open `/Patients`. (At the start it will error, because you haven't written the model yet. That is the point.)
The first run creates `hospital.db` (SQLite). Delete that file any time to start the database fresh.

## Progress checklist (tick as you go)
Marks are from Mr Aphane's practice paper (100 total). B = bonus drills for the pointers the paper skips.

| Done | Question | Marks | File | Pointer |
|---|---|---|---|---|
| [ ] | Q1.1 REST + HTTP methods | 5 | `Theory/Q1_1_REST_and_HTTP_methods.md` | 8 |
| [ ] | Q1.2 Migrations | 5 | `Theory/Q1_2_EF_Core_Migrations.md` | 2 |
| [ ] | Q1.3 ViewBag vs TempData | 5 | `Theory/Q1_3_ViewBag_vs_TempData.md` | 7 |
| [ ] | Q1.4 Data annotations | 5 | `Theory/Q1_4_Data_Annotations.md` | 1 |
| [ ] | Q2.1 Patient model | 15 | `HospitalApp/Models/Patient.cs` | 1 |
| [ ] | Q2.2 DbContext + composite key | 15 | `HospitalApp/ApplicationDbContext.cs` | 2, 3 |
| [ ] | Q3.1 Controller, DI, TempData | 20 | `HospitalApp/Controllers/PatientsController.cs` | 4, 7 |
| [ ] | Q3.2 Create view + dropdown | 15 | `HospitalApp/Views/Patients/Create.cshtml` | 5, 6 |
| [ ] | Q3.3 Index view + loop | 15 | `HospitalApp/Views/Patients/Index.cshtml` | 5 |
| [ ] | B1 ERD | bonus | `Theory/B1_ERD_and_Relationships.md` | 3 |
| [ ] | B2 Seeding (HasData) | bonus | `HospitalApp/ApplicationDbContext.cs` (task c) + `Theory/B2_Seeding.md` | 7 |
| [ ] | B3 One-to-many + Include | bonus | `HospitalApp/Controllers/DoctorsController.cs` | 3, 4 |
| [ ] | B4 Async | bonus | `Theory/B4_Async.md` + your controllers | 7 |
| [ ] | B5 Edit / Delete GET + POST | bonus | `HospitalApp/Controllers/PatientsController.Bonus.cs` | 4 |
| [ ] | B6 `@if` in a view | bonus | `HospitalApp/Views/Doctors/Index.cshtml` | 5 |
| [ ] | B7 Run migrations for real | bonus | terminal (see below) | 2 |

**B7:** from the `HospitalApp` folder, finish Q2.1 + Q2.2 first, delete `hospital.db` if it exists, then run
`dotnet tool install --global dotnet-ef` (once), `dotnet ef migrations add InitialCreate` and `dotnet ef database update`.

## The 8 exam pointers, mapped to files
| # | Pointer | Where |
|---|---|---|
| 1 | Models and data annotations (PK, FK) | Q2.1 `Models/Patient.cs`, Q1.4 |
| 2 | EF Core: DbContext, DbSet, migrations, DB operations | Q2.2 `ApplicationDbContext.cs`, Q1.2, B7 |
| 3 | Relationships: ERD, navigation, one-to-many, many-to-many, Fluent API, composite keys | Q2.2, B1, B3 |
| 4 | Controllers: GET/POST, CRUD, DI, validation | Q3.1, B5 |
| 5 | Razor views: strongly typed, loops, conditionals, displaying records | Q3.2, Q3.3, B6 |
| 6 | HTML forms + model binding, dropdowns, submission, validation | Q3.2 (+ the dropdown in Q3.1) |
| 7 | Data management: async, seeding, ViewBag, TempData | Q1.3, B2, B4, TempData in Q3.1 |
| 8 | Web APIs theory: REST, HTTP methods, statelessness | Q1.1 |

## What is in the folder
- `HospitalApp/` the MVC project (your answer files + the given files like `Program.cs`, `Doctor.cs`, `DoctorPatient.cs`)
- `HospitalApp.Tests/` the auto-checks (don't edit)
- `Theory/` one file per theory question
- `Papers/` the original practice paper wording, for reference
- `check.sh` / `check.ps1` run the checks

## Good to know
- `<Nullable>` is **disabled** in the project on purpose. Don't turn it on, or a good form fails with "The Doctor field is required."
- The checks are strict but fair: they look at structure (attributes, results, TempData), not how you name your variables.
- Stuck for ages? Do the next question and come back. Last resort: the `prg742-solutions` branch.
