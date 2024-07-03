using AntiForgeryToken.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Antiforgery;
using System.Diagnostics;

namespace AntiForgeryToken.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAntiforgery _antiforgery;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IAntiforgery antiforgery)
        {
            _logger = logger;
            _antiforgery = antiforgery;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult Index()
        {
            // Generate a new antiforgery token and pass it to the view
            var token = _antiforgery.GetAndStoreTokens(HttpContext).RequestToken;
            ViewBag.AntiForgeryToken = token;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string input)
        {
            // The antiforgery token is validated here
            // You can now process the input
            return RedirectToAction("Index");
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
