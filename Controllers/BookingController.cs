using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuaNhaMVC.Data;
using SuaNhaMVC.Models;

namespace SuaNhaMVC.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public BookingController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string? serviceId = null)
        {
            var services = await _context.Services.ToListAsync();
            ViewBag.Services = new SelectList(services, "Id", "Name", serviceId);
            
            var timeSlots = new[] { "08:00", "09:00", "10:00", "11:00", "13:00", "14:00", "15:00", "16:00", "17:00" };
            ViewBag.TimeSlots = new SelectList(timeSlots);

            var booking = new Booking();
            if (!string.IsNullOrEmpty(serviceId))
            {
                booking.ServiceId = serviceId;
            }

            return View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Booking booking)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            booking.UserId = user.Id;
            booking.Id = Guid.NewGuid().ToString();

            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Đặt lịch thành công! Chúng tôi sẽ liên hệ với bạn trong vòng 24h.";
                return RedirectToAction("MyBookings");
            }

            var services = await _context.Services.ToListAsync();
            ViewBag.Services = new SelectList(services, "Id", "Name", booking.ServiceId);
            
            var timeSlots = new[] { "08:00", "09:00", "10:00", "11:00", "13:00", "14:00", "15:00", "16:00", "17:00" };
            ViewBag.TimeSlots = new SelectList(timeSlots, booking.BookingTime);

            return View("Index", booking);
        }

        public async Task<IActionResult> MyBookings()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var bookings = await _context.Bookings
                .Include(b => b.Service)
                .Where(b => b.UserId == user.Id)
                .OrderByDescending(b => b.CreatedAt)
                .ToListAsync();

            return View(bookings);
        }
    }
}