using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCProject2.Data;
using MVCProject2.Infrastructure;
using MVCProject2.Models;


namespace MVCProject2.Controllers
{
    [CustomAuthFilter]
    public class PostsController : Controller
    {
        private readonly ApplicationContext _context;


        public PostsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.Posts
                .Include(p => p.User)
                .Include(p => p.Comment)
                    .ThenInclude(c => c.User);
            return View(await applicationContext.ToListAsync());
        }
        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostName,Text")] Post post, IFormFile upload)
        {
            post.CurrentTime = DateTime.Now;
            post.UserId = Request.Cookies["UserId"];
            post.FileName = "";
            if (upload != null)
            {
                string path = "/Files/" + upload.FileName;
                post.FileName = upload.FileName;
                using (var fileStream = new FileStream("Files/" + upload.FileName, FileMode.Create))
                {
                    await upload.CopyToAsync(fileStream);
                }
                Console.WriteLine("##########" + post.FileName);
            }
            if (ModelState.IsValid)
            {
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", post.UserId);
            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", post.UserId);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostId,PostName,Text,FileName")] Post post, IFormFile upload)
        {
            if (id != post.PostId)
            {
                return NotFound();
            }
            post.EditingTime = DateTime.Now;
            post.FileName = "";
            post.UserId = Request.Cookies["UserId"];
            post.CurrentTime = _context.Posts.AsNoTracking().Where(p => p.PostId == id).FirstOrDefault().CurrentTime;
            if (upload != null)
            {
                string path = "/Files/" + upload.FileName;
                post.FileName = upload.FileName;
                using (var fileStream = new FileStream("Files/" + upload.FileName, FileMode.Create))
                {
                    await upload.CopyToAsync(fileStream);
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.PostId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", post.UserId);
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = _context.Posts.Include(p=>p.Comment).Where(p=> p.PostId==id).FirstOrDefault();
            foreach(var comment in post.Comment)
            {
                _context.Comments.Remove(comment);
            }
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.PostId == id);
        }
    }
}
