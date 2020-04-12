using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCProject2.Data;
using MVCProject2.Infrastructure;
using MVCProject2.Models;

namespace MVCProject2.Controllers
{
 
    [CustomAuthFilter]
    public class CommentsController : Controller
    {
        private readonly ApplicationContext _context;

        public CommentsController(ApplicationContext context)
        {
            _context = context;
        }
        // GET: Comments/Create
        public IActionResult Create()
        {
            var postId = Request.Query["PostId"];
            var cookieOptions = new Microsoft.AspNetCore.Http.CookieOptions()
            {
                IsEssential = true
            };
            Response.Cookies.Append("PostId",postId.ToString(), cookieOptions);
            ViewData["PostId"] = new SelectList(_context.Posts, "PostId", "PostId");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentId,CommentText")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.UserId = Request.Cookies["UserId"];
                comment.PostId = Convert.ToInt32(Request.Cookies["PostId"]);
                comment.CurrentTime = DateTime.Now;
                _context.Add(comment);
                await _context.SaveChangesAsync();
                return LocalRedirect("/Posts/Index");
            }
            ViewData["PostId"] = new SelectList(_context.Posts, "PostId", "PostId", comment.PostId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", comment.UserId);
            return View(comment);
        }

        // GET: Comments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            ViewData["PostId"] = new SelectList(_context.Posts, "PostId", "PostId", comment.PostId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", comment.UserId);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CommentId,CommentText")] Comment comment)
        {
            if (id != comment.CommentId)
            {
                return NotFound();
            }
            comment.UserId = _context.Comments.AsNoTracking().Where(c => c.CommentId == id).FirstOrDefault().UserId;
            comment.PostId = _context.Comments.AsNoTracking().Where(c => c.CommentId == id).FirstOrDefault().PostId;
            comment.CurrentTime = _context.Comments.AsNoTracking().Where(c => c.CommentId == id).FirstOrDefault().CurrentTime;


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentExists(comment.CommentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return LocalRedirect("/Posts");
            }
            ViewData["PostId"] = new SelectList(_context.Posts, "PostId", "PostId", comment.PostId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", comment.UserId);
            return View(comment);
        }

        // GET: Comments/Delete/5
        [isAdminFilter]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .Include(c => c.Post)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.CommentId == id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return LocalRedirect("/Posts");
        }



        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.CommentId == id);
        }
    }
}
