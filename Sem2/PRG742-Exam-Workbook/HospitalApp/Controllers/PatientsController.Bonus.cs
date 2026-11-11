// =====================================================================================
//  BONUS B5  EDIT & DELETE (GET + POST)      Pointer 4: Controllers / CRUD
//  BONUS B4  ASYNC                           Pointer 7: Data Management
// =====================================================================================
//
//  LESSON
//  ------
//  CRUD = Create, Read, Update, Delete. You already did C and R. Edit and Delete each need TWO
//  actions: a GET that shows the record, and a POST that does the change.
//
//  Async in one breath: a database call is slow compared to the CPU. With  async/await  the thread
//  is released while the database works, so the server can handle other requests meanwhile.
//     async Task<IActionResult> Index()      <- method is async and returns a Task
//     await _context.Books.ToListAsync();    <- "wait for this WITHOUT blocking the thread"
//  Rule of thumb: every EF call has an Async twin (ToListAsync, FindAsync, SaveChangesAsync,
//  FirstOrDefaultAsync). In an async action use the Async one, and await it.
//
//  WORKED EXAMPLE (Books)
//  ----------------------
//      [HttpGet]
//      public async Task<IActionResult> Edit(int id)
//      {
//          var book = await _context.Books.FindAsync(id);   // find by primary key
//          if (book == null) return NotFound();             // 404 if it doesn't exist
//          return View(book);                               // show the filled form
//      }
//
//      [HttpPost]
//      [ValidateAntiForgeryToken]
//      public async Task<IActionResult> Edit(int id, Book book)
//      {
//          if (id != book.BookId) return NotFound();
//          if (ModelState.IsValid)
//          {
//              _context.Update(book);                        // mark the whole row as changed
//              await _context.SaveChangesAsync();            // UPDATE
//              return RedirectToAction(nameof(Index));
//          }
//          return View(book);
//      }
//
//      // Delete: GET asks "are you sure?", POST really deletes.
//      [HttpPost, ActionName("Delete")]     // the URL is still /Books/Delete, the C# name differs
//      [ValidateAntiForgeryToken]
//      public async Task<IActionResult> DeleteConfirmed(int id)
//      {
//          var book = await _context.Books.FindAsync(id);
//          if (book != null) _context.Books.Remove(book);
//          await _context.SaveChangesAsync();
//          return RedirectToAction(nameof(Index));
//      }
//
//  Why is the C# name different (DeleteConfirmed)? C# can't have two methods with the same name AND
//  the same parameters (int id). [ActionName("Delete")] fixes the URL side.
//
//  COMMON TRAPS
//  ------------
//  * Edit POST: the form must post the PatientId too (hidden input), or id != patient.PatientId.
//  * Forgetting NotFound() for a missing id: you'd crash with a NullReferenceException.
//  * Using Remove() without SaveChangesAsync(). Nothing happens until you save.
//
//  THE TASK  (add these to the PatientsController class, same class as Q3.1)
//  -------------------------------------------------------------------------
//   [B5] GET  Edit(int id)               -> the patient's form, or NotFound() when the id is unknown.
//   [B5] POST Edit(int id, Patient patient) -> if valid, update + save + redirect to Index
//                                             (and set TempData["SuccessMessage"]); else return the view.
//   [B5] GET  Delete(int id)             -> the patient to confirm, or NotFound().
//   [B5] POST Delete (name it DeleteConfirmed, use [ActionName("Delete")]) -> remove, save, redirect to Index.
//   [B4] Keep ALL your patient actions async (Task<IActionResult>) and use ToListAsync / FindAsync /
//        SaveChangesAsync. The tests check this in the source file.
//   (No Edit/Delete views needed for the tests. Add them later for fun if you want to click through.)
//
//  HINT
//  ----
//  FindAsync(id) searches by primary key. Update(entity) and Remove(entity) are on the context.
//  _context is the private field you declared in PatientsController.cs.
//
// >>>>> WRITE YOUR ANSWER BELOW THIS LINE (replace the empty shell) <<<<<

using Microsoft.AspNetCore.Mvc;

namespace HospitalApp.Controllers;

public partial class PatientsController
{
}
