using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CRUDCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRUDCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly CRUDAPPContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            IEnumerable<SelectListItem> items = _context.Patients.Select(c => new SelectListItem
            {
                Value = c.Names,
                Text = c.Names
            });
            ViewBag.PatientsList = items;


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


        public RedirectResult LogOff()
        {
            HttpContext.Session.Clear();


            return Redirect("/Login/");   
            
        }
    }
}
    