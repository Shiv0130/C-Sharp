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

        public IActionResult Compose(string? receiverId)
        {
            ViewBag.ReceiverId = receiverId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Compose(string receiverId, string content)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Challenge();

            if (string.IsNullOrWhiteSpace(content) || string.IsNullOrWhiteSpace(receiverId))
            {
                ModelState.AddModelError(string.Empty, "Receiver and message are required.");
                ViewBag.ReceiverId = receiverId;
                return View();
            }

            _context.Messages.Add(new Message
            {
                SenderId = user.Id,
                ReceiverId = receiverId,
                Content = content,
                Timestamp = DateTime.UtcNow,
                IsRead = false
            });

            _context.Notifications.Add(new Notification
            {
                UserId = receiverId,
                Title = "New message",
                Message = "You have a new inbox message.",
                Type = "Message",
                CreatedAt = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Inbox));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkRead(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var msg = await _context.Messages.FirstOrDefaultAsync(m => m.Id == id && m.ReceiverId == user!.Id);
            if (msg != null)
            {
                msg.IsRead = true;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Inbox));
        }
    }
}
