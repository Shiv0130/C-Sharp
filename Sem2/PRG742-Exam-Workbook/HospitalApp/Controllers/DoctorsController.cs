// =====================================================================================
//  BONUS B3  ONE-TO-MANY + Include()         Pointer 3: Relationships  +  Pointer 4: Controllers
// =====================================================================================
//
//  LESSON
//  ------
//  One-to-many: ONE doctor has MANY patients. In code that is two things:
//     * the "many" side holds the foreign key + a single navigation:   Patient.DoctorId, Patient.Doctor
//     * the "one" side holds a collection navigation:                   Doctor.Patients  (a List<Patient>)
//  (Both are already in the given Doctor.cs and in your Patient.cs.)
//
//  The catch: when you load doctors, EF does NOT automatically load their patients. The
//  collection comes back null. That is on purpose, because loading everything would be slow.
//  You say "bring the related rows too" with  Include():
//
//  WORKED EXAMPLE (Author has many Books)
//  --------------------------------------
//      public async Task<IActionResult> Index()
//      {
//          var authors = await _context.Authors
//                                      .Include(a => a.Books)     // JOIN the books in
//                                      .ToListAsync();
//          return View(authors);
//      }
//
//  Now  author.Books  is filled and the view can loop over it. (Include needs
//  using Microsoft.EntityFrameworkCore;)
//
//  COMMON TRAPS
//  ------------
//  * Forgetting Include, then the view crashes with NullReferenceException on doctor.Patients.
//  * Include goes BEFORE ToListAsync. ToListAsync runs the query, so the Include must already be in.
//  * The lambda must point at the navigation property (a => a.Books), not at the foreign key.
//
//  THE TASK
//  --------
//  Write a DoctorsController (namespace HospitalApp.Controllers):
//   [B3] DI constructor for ApplicationDbContext, same pattern as PatientsController.
//   [B3] GET Index: async, load all doctors WITH their Patients and return them to the view.
//   (The matching view is bonus B6: Views/Doctors/Index.cshtml.)
//
//  HINT
//  ----
//  Same skeleton as the Patients controller from Q3.1. The only new word is Include.
//
// >>>>> WRITE YOUR ANSWER BELOW THIS LINE (replace the empty shell) <<<<<

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalApp.Controllers;

public class DoctorsController : Controller
{
    private readonly ApplicationDbContext _context;

    public DoctorsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var doctors = await _context.Doctors
                                    .Include(d => d.Patients)
                                    .ToListAsync();
        return View(doctors);
    }
}
