using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using _378daftarkhoneh.Data;

namespace _378daftarkhoneh.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.TotalFiles = await _context.FileUploads.CountAsync();
            ViewBag.TotalCategories = await _context.Categories.CountAsync();
            ViewBag.TotalUsers = await _context.Users.CountAsync();
            
            var recentFiles = await _context.FileUploads
                .Include(f => f.Category)
                .OrderByDescending(f => f.UploadedAt)
                .Take(5)
                .ToListAsync();
            
            ViewBag.RecentFiles = recentFiles;
            
            return View();
        }
    }
}
