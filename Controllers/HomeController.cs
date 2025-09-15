using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuaNhaMVC.Data;
using SuaNhaMVC.Models;
using System.Diagnostics;

namespace SuaNhaMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var featuredServices = await _context.Services
                .Take(4)
                .ToListAsync();
            
            return View(featuredServices);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}