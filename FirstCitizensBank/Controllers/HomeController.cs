using FirstCitizensBank.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FirstCitizensBank.Controllers
{
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public ActionResult SubmitData(string firstName, string lastName, string zipCode)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(zipCode))
            {
                return Content("Please fill in all fields.");
            }

            // TODO: Store/Persist the submitted data to database

            return Content("Data submitted successfully.");
        }
    }
}