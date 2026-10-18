using ResearchAdmin.Data;
using ResearchAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace ResearchAdmin.Controllers
{
    public class GrantAwardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GrantAwardsController(ApplicationDbContext context)
        {
            // TODO: store context in _context
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // TODO: Include FundingAgency + LeadResearcher, ToListAsync, return View
            var grantAwards = await _context.GrantAwards
                .Include(g => g.FundingAgency)
                .Include(g => g.LeadResearcher)
                .ToListAsync();
            return View(grantAwards);


            throw new NotImplementedException();
        }

        public async Task<IActionResult> Details(int? id)
        {
            // TODO: if id null → NotFound
            // TODO: FirstOrDefaultAsync with both Includes
            // TODO: if entity null → NotFound
            var grantAward = await _context.GrantAwards
                .Include(g => g.FundingAgency)
                .Include(g => g.LeadResearcher)
                .FirstOrDefaultAsync(g => g.Id == id);
            if(grantAward == null) return NotFound();
            return View(grantAward);

            throw new NotImplementedException();
        }

        public IActionResult Create()
        {
            // TODO: PopulateAgencyAndResearcherDropDowns(); return View();
            PopulateAgencyAndResearcherDropDowns();
            return View();

            throw new NotImplementedException();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("ProjectTitle,AwardedAmount,ApprovalDate,EthicsClearanceCode,FundingAgencyId,LeadResearcherId")]
            GrantAward award)
        {
            // TODO: if !ValidateEthicsClearanceFormat(award.EthicsClearanceCode)
            //          → ModelState.AddModelError for EthicsClearanceCode
            // TODO: if ModelState valid → Add, SaveChangesAsync, RedirectToAction Index
            // TODO: else repopulate dropdowns, return View(award)
            if (!ValidateEthicsClearanceFormat(award.EthicsClearanceCode))
            {
                ModelState.AddModelError("EthicsClearanceCode", "Invalid format for Ethics Clearance Code.");
                if (ModelState.IsValid)
                {
                    _context.Add(award);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    PopulateAgencyAndResearcherDropDowns(award.FundingAgencyId, award.LeadResearcherId);
                    return View(award);
                }
            }

            throw new NotImplementedException();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            // TODO: null check, FindAsync, null check, populate dropdowns, return View
            if(id == null) return NotFound();
            PopulateAgencyAndResearcherDropDowns(id);
            return View(await _context.GrantAwards.FindAsync(id));

            throw new NotImplementedException();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,ProjectTitle,AwardedAmount,ApprovalDate,EthicsClearanceCode,FundingAgencyId,LeadResearcherId")]
            GrantAward award)
        {
            // TODO: if id != award.Id → NotFound
            // TODO: ethics validation again
            // TODO: if valid → try Update + SaveChanges, catch DbUpdateConcurrencyException
            // TODO: else repopulate dropdowns, return View

            if (id != award.Id) return NotFound();
            if (!ValidateEthicsClearanceFormat(award.EthicsClearanceCode))
            {
                ModelState.AddModelError("EthicsClearanceCode", "Invalid format for Ethics Clearance Code.");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(award);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException) 
                {
                    if(!GrantAwardExists(award.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                    return RedirectToAction(nameof(Index));
                }
                PopulateAgencyAndResearcherDropDowns(award.FundingAgencyId, award.LeadResearcherId);
                return View(award);
            }






            throw new NotImplementedException();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            // TODO: null checks + Include both navigations
            if (id == null) return NotFound();
            var grantAward = await _context.GrantAwards
                .Include(g => g.FundingAgency)
                .Include(g => g.LeadResearcher)
                .FirstOrDefaultAsync(g => g.Id == id);

            if(grantAward == null) return NotFound(); 
            return View(grantAward);

            throw new NotImplementedException();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // TODO: FindAsync, Remove if not null, SaveChanges, RedirectToAction Index
            var grantAward = await _context.GrantAwards.FindAsync(id);
            if (grantAward!= null)
            {
                _context.GrantAwards.Remove(grantAward);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            throw new NotImplementedException();
        }

        private bool GrantAwardExists(int id)
        {
            // TODO: return _context.GrantAwards.Any(...)
            return _context.GrantAwards.Any(e => e.Id == id);
            throw new NotImplementedException();
        }

        private void PopulateAgencyAndResearcherDropDowns(
            int? selectedAgencyId = null, int? selectedResearcherId = null)
        {
            // TODO: ViewData["FundingAgencyId"] = SelectList AgencyName
            // TODO: ViewData["LeadResearcherId"] = SelectList FullName
            ViewData["FundingAgencyId"] = new SelectList(_context.FundingAgencies, "Id", "AgencyName", selectedAgencyId);
            ViewData["LeadResearcherId"] = new SelectList(_context.LeadResearchers, "Id", "FullName", selectedResearcherId);
        }

        private bool ValidateEthicsClearanceFormat(string clearanceCode)
        {
            // TODO: Regex for ETH-2026-XXXX (XXXX = 4 digits)
            // Hint: ^ETH-2026-\d{4}$
            clearanceCode = "^ETH-2026-\\d{4}$";
            Regex regex = new Regex(clearanceCode);
            throw new NotImplementedException();
        }
    }
}