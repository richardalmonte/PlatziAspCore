using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlatziAspCore.Models;

namespace PlatziAspCore.Controllers
{
    public class SubjectController : Controller
    {
        private readonly SchoolContext context;

        public SubjectController(SchoolContext context)
        {
            this.context = context;
        }

        // GET: Subject
        [Route("Subject")]
        [Route("Subject/Index")]
        public async Task<IActionResult> Index()
        {
            var schoolContext = context.Subjects.Include(s => s.Course);
            return View(await schoolContext.ToListAsync());
        }

        // GET: Subject/Details/5
        [Route("Subject/{subjectId}")]
        [Route("Subject/Index/{subjectId}")]
        public async Task<IActionResult> Details(string subjectId)
        {
            if (subjectId == null)
            {
                return NotFound();
            }

            var subject = await context.Subjects
                .Include(s => s.Course)
                .FirstOrDefaultAsync(m => m.Id == subjectId);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // GET: Subject/Create
        public IActionResult Create()
        {
            ViewData["CourseList"] = new SelectList(context.Courses, "Id", "Name");
            return View();
        }

        // POST: Subject/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,CourseId,Id")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                context.Add(subject);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseList"] = new SelectList(context.Courses, "Id", "Name", subject.CourseId);
            return View(subject);
        }

        // GET: Subject/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await context.Subjects.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            ViewData["CourseList"] = new SelectList(context.Courses, "Id", "Name", subject.CourseId);
            return View(subject);
        }

        // POST: Subject/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,CourseId,Id")] Subject subject)
        {
            if (id != subject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(subject);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectExists(subject.Id))
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
            ViewData["CourseList"] = new SelectList(context.Courses, "Id", "Name", subject.CourseId);
            return View(subject);
        }

        // GET: Subject/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await context.Subjects
                .Include(s => s.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // POST: Subject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var subject = await context.Subjects.FindAsync(id);
            context.Subjects.Remove(subject);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectExists(string id)
        {
            return context.Subjects.Any(e => e.Id == id);
        }
    }
}
