using ApplicationUser = Staybnb.Models.ApplicationUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Staybnb.Data;
using Staybnb.Models;

namespace Staybnb.Controllers
{
    [Authorize]
    public class MessagesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MessagesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Inbox()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Challenge();

            var messages = await _context.Messages
                .Include(m => m.Sender)
                .Include(m => m.Receiver)
                .Where(m => m.ReceiverId == user.Id || m.SenderId == user.Id)
                .OrderByDescending(m => m.Timestamp)
                .ToListAsync();

            return View(messages);
        }

        public async Task<IActionResult> Compose(string? receiverId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Challenge();

            var others = await _userManager.Users
                .Where(u => u.Id != user.Id)
                .OrderBy(u => u.Email)
                .Select(u => new { u.Id, u.Email, u.FirstName, u.LastName })
                .ToListAsync();

            ViewBag.Users = others;
            ViewBag.ReceiverId = receiverId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Compose(string? receiverId, string? receiverEmail, string content)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Challenge();

            ApplicationUser? receiver = null;

            if (!string.IsNullOrWhiteSpace(receiverId))
                receiver = await _userManager.FindByIdAsync(receiverId);

            if (receiver == null && !string.IsNullOrWhiteSpace(receiverEmail))
                receiver = await _userManager.FindByEmailAsync(receiverEmail.Trim());

            if (receiver == null || string.IsNullOrWhiteSpace(content))
            {
                ModelState.AddModelError(string.Empty, "Pick a user (or enter a valid email) and write a message.");
                var others = await _userManager.Users
                    .Where(u => u.Id != user.Id)
                    .OrderBy(u => u.Email)
                    .Select(u => new { u.Id, u.Email, u.FirstName, u.LastName })
                    .ToListAsync();
                ViewBag.Users = others;
                ViewBag.ReceiverId = receiverId;
                return View();
            }

            if (receiver.Id == user.Id)
            {
                ModelState.AddModelError(string.Empty, "You cannot message yourself.");
                var others = await _userManager.Users
                    .Where(u => u.Id != user.Id)
                    .OrderBy(u => u.Email)
                    .Select(u => new { u.Id, u.Email, u.FirstName, u.LastName })
                    .ToListAsync();
                ViewBag.Users = others;
                return View();
            }

            _context.Messages.Add(new Message
            {
                SenderId = user.Id,
                ReceiverId = receiver.Id,
                Content = content.Trim(),
                Timestamp = DateTime.UtcNow,
                IsRead = false
            });

            _context.Notifications.Add(new Notification
            {
                UserId = receiver.Id,
                Title = "New message",
                Message = $"New message from {user.Email}.",
                Type = "Message",
                CreatedAt = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();
            TempData["Success"] = "Message sent to " + receiver.Email;
            return RedirectToAction(nameof(Inbox));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkRead(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Challenge();

            var msg = await _context.Messages
                .FirstOrDefaultAsync(m => m.Id == id && m.ReceiverId == user.Id);

            if (msg != null)
            {
                msg.IsRead = true;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Inbox));
        }
    }
}