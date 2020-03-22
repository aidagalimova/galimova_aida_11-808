using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        // GET: Users
        public async Task<IActionResult> Login()
        {
            return View();
        }


        public async Task<IActionResult> Registration()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("UserId,Login,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                User t = _context.Users.Where(u => (u.Login == user.Login && u.Password == user.Password)).FirstOrDefault();

                if (t != null)
                {
                    var cookieOptions = new Microsoft.AspNetCore.Http.CookieOptions()
                    {
                        IsEssential = true
                    };
                    Response.Cookies.Append("UserId", t.UserId.ToString(), cookieOptions);
                    Console.WriteLine(Request.Cookies["UserId"]);
                    return RedirectPermanent("Details/"+t.UserId);
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration([Bind("UserId,Login,Password, UserName")] User user)
        {
            if (ModelState.IsValid)
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return RedirectPermanent("Login");
            }
            return View();
        }


        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.UserId == id);
            Console.WriteLine(Request.Cookies["UserId"]);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

    }
}
