using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _378daftarkhoneh.Models;

namespace _378daftarkhoneh.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
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




    public IActionResult AboutUs()
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


    public IActionResult Price() {

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
