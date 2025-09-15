using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuaNhaMVC.Data;
using SuaNhaMVC.Models;

namespace SuaNhaMVC.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public AdminController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null || !user.IsAdmin)
            {
                return Forbid();
            }

            var stats = new
            {
                TotalBookings = await _context.Bookings.CountAsync(),
                PendingBookings = await _context.Bookings.CountAsync(b => b.Status == BookingStatus.Pending),
                CompletedBookings = await _context.Bookings.CountAsync(b => b.Status == BookingStatus.Completed),
                TotalServices = await _context.Services.CountAsync(),
                TotalUsers = await _userManager.Users.CountAsync()
            };

            ViewBag.Stats = stats;
            
            var recentBookings = await _context.Bookings
                .Include(b => b.Service)
                .Include(b => b.User)
                .OrderByDescending(b => b.CreatedAt)
                .Take(5)
                .ToListAsync();

            return View(recentBookings);
        }

        public async Task<IActionResult> Services()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null || !user.IsAdmin)
            {
                return Forbid();
            }

            var services = await _context.Services.ToListAsync();
            return View(services);
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(string name, string description, decimal price, string category, string? imageUrl)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null || !user.IsAdmin)
            {
                return Forbid();
            }

            var service = new Service
            {
                Name = name,
                Description = description,
                Price = price,
                Category = category,
                ImageUrl = imageUrl,
                CreatedAt = DateTime.UtcNow
            };

            _context.Services.Add(service);
            await _context.SaveChangesAsync();
            
            TempData["Success"] = "Thêm dịch vụ thành công!";
            return RedirectToAction("Services");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteService(string id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null || !user.IsAdmin)
            {
                return Forbid();
            }

            var service = await _context.Services.FindAsync(id);
            if (service != null)
            {
                _context.Services.Remove(service);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Xóa dịch vụ thành công!";
            }

            return RedirectToAction("Services");
        }

        public async Task<IActionResult> Bookings()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null || !user.IsAdmin)
            {
                return Forbid();
            }

            var bookings = await _context.Bookings
                .Include(b => b.Service)
                .Include(b => b.User)
                .OrderByDescending(b => b.CreatedAt)
                .ToListAsync();

            return View(bookings);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBookingStatus(string id, BookingStatus status)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null || !user.IsAdmin)
            {
                return Forbid();
            }

            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                booking.Status = status;
                await _context.SaveChangesAsync();
                TempData["Success"] = "Cập nhật trạng thái thành công!";
            }

            return RedirectToAction("Bookings");
        }

        // Website Content Management
        public async Task<IActionResult> Content()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null || !user.IsAdmin)
            {
                return Forbid();
            }

            var contents = await _context.WebsiteContents
                .OrderBy(c => c.Type)
                .ThenBy(c => c.Order)
                .ToListAsync();

            return View(contents);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContent(string key, string title, string? content, string? imageUrl, string? link, ContentType type, int order)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null || !user.IsAdmin)
            {
                return Forbid();
            }

            var websiteContent = new WebsiteContent
            {
                Key = key,
                Title = title,
                Content = content,
                ImageUrl = imageUrl,
                Link = link,
                Type = type,
                Order = order,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.WebsiteContents.Add(websiteContent);
            await _context.SaveChangesAsync();
            
            TempData["Success"] = "Thêm nội dung thành công!";
            return RedirectToAction("Content");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContent(string id, string key, string title, string? content, string? imageUrl, string? link, ContentType type, int order, bool isActive)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null || !user.IsAdmin)
            {
                return Forbid();
            }

            var websiteContent = await _context.WebsiteContents.FindAsync(id);
            if (websiteContent != null)
            {
                websiteContent.Key = key;
                websiteContent.Title = title;
                websiteContent.Content = content;
                websiteContent.ImageUrl = imageUrl;
                websiteContent.Link = link;
                websiteContent.Type = type;
                websiteContent.Order = order;
                websiteContent.IsActive = isActive;
                websiteContent.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                TempData["Success"] = "Cập nhật nội dung thành công!";
            }

            return RedirectToAction("Content");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteContent(string id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null || !user.IsAdmin)
            {
                return Forbid();
            }

            var content = await _context.WebsiteContents.FindAsync(id);
            if (content != null)
            {
                _context.WebsiteContents.Remove(content);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Xóa nội dung thành công!";
            }

            return RedirectToAction("Content");
        }

        public async Task<IActionResult> Settings()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null || !user.IsAdmin)
            {
                return Forbid();
            }

            var settings = new
            {
                SiteName = "Dịch Vụ Sửa Nhà Cửa",
                SiteDescription = "Dịch vụ sửa chữa nhà cửa chuyên nghiệp, uy tín",
                ContactPhone = "0123456789",
                ContactEmail = "contact@suanha.com",
                Address = "123 Đường ABC, Quận XYZ, TP.HCM",
                WorkingHours = "8:00 - 18:00 (Thứ 2 - Chủ nhật)",
                FacebookUrl = "https://facebook.com/suanha",
                ZaloUrl = "https://zalo.me/suanha"
            };

            ViewBag.Settings = settings;
            return View();
        }
    }
}