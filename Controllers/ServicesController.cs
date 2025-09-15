using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuaNhaMVC.Data;
using SuaNhaMVC.Models;

namespace SuaNhaMVC.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchTerm, string category)
        {
            var services = _context.Services.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                services = services.Where(s => s.Name.Contains(searchTerm) || s.Description.Contains(searchTerm));
            }

            if (!string.IsNullOrEmpty(category) && category != "all")
            {
                services = services.Where(s => s.Category == category);
            }

            var categories = await _context.Services
                .Select(s => s.Category)
                .Distinct()
                .ToListAsync();

            ViewBag.Categories = categories ?? new List<string>();
            ViewBag.SearchTerm = searchTerm;
            ViewBag.SelectedCategory = category;

            return View(await services.ToListAsync());
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Services
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }
    }
}