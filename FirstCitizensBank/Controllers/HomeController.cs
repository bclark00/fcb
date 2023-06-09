﻿using FirstCitizensBank.Models;
using FirstCitizentBank;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Raven.Client.Documents.Session;
using System.Diagnostics;
using System.Security.Principal;

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
        
        public ActionResult SubmitData()
        {
            string contactJson = new StreamReader(Request.Body).ReadToEndAsync().Result;
            
            Contact? contact = JsonConvert.DeserializeObject<Contact>(contactJson);
            if (string.IsNullOrEmpty(contact?.FirstName) || string.IsNullOrEmpty(contact.LastName) || string.IsNullOrEmpty(contact.ZipCode))
            {
                return Json("Please fill in all fields.");
            }

            try
            {
                using (IDocumentSession session = DocumentStoreHolder.Store.OpenSession())
                {
                    session.Store(contact);
                    session.SaveChanges();
                }
                return Json("Data submitted successfully.");
            }
            catch {
                return Json("Database failure.");
            }
        }
    }
}