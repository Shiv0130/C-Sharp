// =====================================================================================
//  Q3.1  MVC CONTROLLER & TempData   [20 marks]    Pointer 4: Controllers   +   Pointer 7: TempData
//  (also Q3.2 controller side: GET Create + ViewBag dropdown)   Pointer 6: Forms & Model Binding
// =====================================================================================
//
//  LESSON
//  ------
//  A controller is the traffic cop. A request comes in (/Patients/Index), the controller picks
//  the matching ACTION METHOD, grabs the data, and hands it to a View.
//
//  GET vs POST:
//     [HttpGet]   "show me something".   Index lists patients. Create (GET) shows an empty form.
//     [HttpPost]  "here's data, save it". Create (POST) receives the submitted form.
//
//  DEPENDENCY INJECTION (DI), the 20-second version:
//  You never write  new ApplicationDbContext()  in a controller. You ASK for it in the constructor
//  and ASP.NET hands it to you (Program.cs registered it). Store it in a private readonly field.
//
//  WORKED EXAMPLE (BooksController, Book/Author world)
//  ---------------------------------------------------
//      public class BooksController : Controller
//      {
//          private readonly LibraryContext _context;
//
//          public BooksController(LibraryContext context)     // <- DI: asked for, handed over
//          {
//              _context = context;
//          }
//
//          [HttpGet]
//          public async Task<IActionResult> Index()
//          {
//              var books = await _context.Books.ToListAsync();   // go get them all
//              return View(books);                                // give the list to the view
//          }
//
//          [HttpPost]
//          [ValidateAntiForgeryToken]                             // blocks fake cross-site posts
//          public async Task<IActionResult> Create(Book book)
//          {
//              if (ModelState.IsValid)                            // did the annotations pass?
//              {
//                  _context.Add(book);
//                  await _context.SaveChangesAsync();             // the actual INSERT
//                  TempData["SuccessMessage"] = "Book created!";  // survives the redirect
//                  return RedirectToAction(nameof(Index));        // Post-Redirect-Get
//              }
//              TempData["ErrorMessage"] = "Fix the errors and try again.";
//              return View(book);                                 // same form, errors shown
//          }
//      }
//
//  Why redirect after a successful POST? Otherwise pressing F5 re-submits the form and creates a
//  duplicate. And why TempData for the message? A redirect is a NEW request, so ViewBag is gone.
//  TempData lives until the next request reads it.
//
//  THE DROPDOWN (Q3.2 needs this from the controller)
//  --------------------------------------------------
//  The Create form has a "pick a doctor" <select>. The controller must fill it BEFORE the view
//  shows, for example:  ViewBag.Authors = new SelectList(_context.Authors, "AuthorId", "Name");
//  SelectList(items, valueField, textField): the value is what gets posted, the text is what shows.
//  Needs  using Microsoft.AspNetCore.Mvc.Rendering;
//
//  COMMON TRAPS
//  ------------
//  * Forgetting async/await: if you write async you must await the call, or you get a Task not data.
//  * Calling SaveChanges and forgetting the Async one in an async method (B4 checks this).
//  * When the model is INVALID, you re-show the form. The dropdown is EMPTY unless you fill the
//    ViewBag again before  return View(model).  Classic bug. Fill it in both places.
//  * Don't change <Nullable>disable</Nullable> in the .csproj. With nullable ON, MVC treats the
//    non-nullable navigation property  Doctor  as [Required] and a perfectly good form fails with
//    "The Doctor field is required." That is exactly why the model is bound with [Bind(...)] below.
//  * Bind("PatientId,FullName,Age,DoctorId") lists the ONLY fields allowed in from the form
//    (it protects against over-posting). Names are case sensitive.
//
//  THE TASK
//  --------
//  Write the PatientsController (namespace HospitalApp.Controllers, inherits Controller):
//   (a) [Q3.1, 4 marks]  A constructor that uses Dependency Injection to receive
//                        ApplicationDbContext (keep it in a private readonly field).
//   (b) [Q3.1, 4 marks]  GET Index: async, load ALL patients and return them to the view.
//   (c) [Q3.1, 12 marks] POST Create(Patient patient). Use [HttpPost], [ValidateAntiForgeryToken]
//                        and [Bind("PatientId,FullName,Age,DoctorId")].
//        - If ModelState is valid: save the patient, set TempData["SuccessMessage"] =
//          "Patient created successfully!" and redirect to Index.
//        - If not valid: set TempData["ErrorMessage"] and return View(patient).
//   (d) [Q3.2 controller side] GET Create: fill ViewBag.DoctorId with a SelectList of doctors
//        (value DoctorId, text Name) and return View(). The invalid-POST path must refill it too.
//   More actions (Edit/Delete) are bonus B5 in the file PatientsController.Bonus.cs.
//   The file is "partial": same class, split over two files. Don't worry, it just works.
//
//  HINT
//  ----
//  Usings you will want: Microsoft.AspNetCore.Mvc, Microsoft.AspNetCore.Mvc.Rendering,
//  Microsoft.EntityFrameworkCore, HospitalApp.Models.
//  Keep the word `partial` in the class line below, it joins the bonus file.
//  Run ./check.sh, the Q3_1 and Q3_2 lines tell you exactly what's still missing.
//
// >>>>> WRITE YOUR ANSWER BELOW THIS LINE (replace the empty shell) <<<<<

using Microsoft.AspNetCore.Mvc;

namespace HospitalApp.Controllers;

public partial class PatientsController : Controller
{
}
