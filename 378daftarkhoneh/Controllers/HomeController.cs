using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _378daftarkhoneh.Models;
using _378daftarkhoneh.Data;
using Microsoft.EntityFrameworkCore;

namespace _378daftarkhoneh.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.Categories = await _context.Categories.ToListAsync();
        ViewBag.RecentFiles = await _context.FileUploads
            .Include(f => f.Category)
            .OrderByDescending(f => f.UploadedAt)
            .Take(6)
            .ToListAsync();
        return View();
    }

    public IActionResult Services()
    {
        return View();
    }

    public IActionResult RealEstateDocuments()
    {
        return View();
    }

    public IActionResult LegalDocuments()
    {
        return View();
    }

    public IActionResult MarriageServices()
    {
        return View();
    }

    public IActionResult CostCalculator()
    {
        return View();
    }

    public IActionResult AboutUs()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    public async Task<IActionResult> Documents(int? categoryId)
    {
        var query = _context.FileUploads.Include(f => f.Category).AsQueryable();
        
        if (categoryId.HasValue)
        {
            query = query.Where(f => f.CategoryId == categoryId.Value);
            ViewBag.CurrentCategory = await _context.Categories.FindAsync(categoryId.Value);
        }

        ViewBag.Categories = await _context.Categories.ToListAsync();
        var documents = await query.OrderByDescending(f => f.UploadedAt).ToListAsync();
        
        return View(documents);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }

    public IActionResult Form()
    {
        return View();
    }

    public IActionResult Error404()
    {
        return View();
    }

    public ActionResult Faq()
    {
        return View();
    }

    public IActionResult Features()
    {
        return View();
    }

    public IActionResult Guide()
    {
        return View();
    }

    public IActionResult News()
    {
        return View();
    }

    public IActionResult Ourteam()
    {
        return View();
    }

    public IActionResult Price()
    {
        return View();
    }

    public IActionResult Service()
    {
        return View();
    }

    public IActionResult NewsPage()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
