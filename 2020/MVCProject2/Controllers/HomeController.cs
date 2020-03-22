using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCProject2.Data;
using MVCProject2.Infrastructure;
using MVCProject2.Models;

namespace MVCProject2.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext database;

        public HomeController(ApplicationContext context)
        {
            database = context;
        }
        public IActionResult Index()
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
