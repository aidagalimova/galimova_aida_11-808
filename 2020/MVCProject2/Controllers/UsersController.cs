using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCProject2.Data;
using MVCProject2.Infrastructure;
using MVCProject2.Models;


namespace MVCProject2.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationContext _context;

        public UsersController(ApplicationContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Registration()
        {
            return View();
        }


        // GET: Users/Details/5
        [CustomAuthFilter]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Email == id);
            Console.WriteLine(Request.Cookies["UserId"]);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

    }
}
