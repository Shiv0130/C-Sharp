using ActiveLife.Data;
using ActiveLife.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ActiveLife.Controllers
{
    public class TrainingSessionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrainingSessionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var sessions = await _context.PersonalTrainingSessions
                .Include(s => s.Trainer)
                .Include(s => s.GymMember)
                .OrderBy(s => s.SessionDateTime)
                .ToListAsync();
            return View(sessions);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var session = await _context.PersonalTrainingSessions
                .Include(s => s.Trainer)
                .Include(s => s.GymMember)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (session == null) return NotFound();
            return View(session);
        }

        public IActionResult Create()
        {
            PopulateTrainerAndMemberDropDowns();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("SessionDateTime,DurationMinutes,SessionFee,WorkoutFocus,TrainerId,GymMemberId")]
            PersonalTrainingSession session)
        {
            if (ModelState.IsValid)
            {
                var member = await _context.GymMembers.FindAsync(session.GymMemberId);
                if (member != null)
                {
                    session.SessionFee = ApplyMembershipDiscount(
                        session.SessionFee, member.MembershipType);
                }

                _context.Add(session);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateTrainerAndMemberDropDowns(session.TrainerId, session.GymMemberId);
            return View(session);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var session = await _context.PersonalTrainingSessions.FindAsync(id);
            if (session == null) return NotFound();

            PopulateTrainerAndMemberDropDowns(session.TrainerId, session.GymMemberId);
            return View(session);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,SessionDateTime,DurationMinutes,SessionFee,WorkoutFocus,TrainerId,GymMemberId")]
            PersonalTrainingSession session)
        {
            if (id != session.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(session);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SessionExists(session.Id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            PopulateTrainerAndMemberDropDowns(session.TrainerId, session.GymMemberId);
            return View(session);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var session = await _context.PersonalTrainingSessions
                .Include(s => s.Trainer)
                .Include(s => s.GymMember)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (session == null) return NotFound();
            return View(session);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var session = await _context.PersonalTrainingSessions.FindAsync(id);
            if (session != null)
            {
                _context.PersonalTrainingSessions.Remove(session);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool SessionExists(int id)
        {
            return _context.PersonalTrainingSessions.Any(s => s.Id == id);
        }

        private void PopulateTrainerAndMemberDropDowns(
            int? selectedTrainerId = null, int? selectedMemberId = null)
        {
            ViewData["TrainerId"] = new SelectList(
                _context.FitnessTrainers, "Id", "TrainerName", selectedTrainerId);
            ViewData["GymMemberId"] = new SelectList(
                _context.GymMembers, "Id", "FullName", selectedMemberId);
        }

        // PDF custom helper — Gold 20% off, Silver 10% off
        private decimal ApplyMembershipDiscount(decimal standardFee, string membershipType)
        {
            if (membershipType == "Gold") return standardFee * 0.80m;
            if (membershipType == "Silver") return standardFee * 0.90m;
            return standardFee;
        }
    }
}