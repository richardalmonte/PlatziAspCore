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
    public class EvaluationController : Controller
    {
        private readonly SchoolContext context;

        public EvaluationController(SchoolContext context)
        {
            this.context = context;
        }

        // GET: Evaluation
        public async Task<IActionResult> Index()
        {
            var schoolContext = context.Evaluations
                                       .Include(e => e.Student)
                                       .Include(e => e.Subject);
            return View(await schoolContext.ToListAsync());
        }

        // GET: Evaluation/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluation = await context.Evaluations
                                          .Include(e => e.Student)
                                          .Include(e => e.Subject)
                                          .FirstOrDefaultAsync(m => m.Id == id);
            if (evaluation == null)
            {
                return NotFound();
            }

            return View(evaluation);
        }

        // GET: Evaluation/Create
        public IActionResult Create()
        {
            ViewData["StudentList"] = new SelectList(context.Students, "Id", "Name");
            ViewData["SubjectList"] = new SelectList(context.Subjects, "Id", "Name");
            return View();
        }

        // POST: Evaluation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,SubjectId,StudentId,Grade,Id")] Evaluation evaluation)
        {
            if (ModelState.IsValid)
            {
                context.Add(evaluation);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentList"] = new SelectList(context.Students, "Id", "Name", evaluation.StudentId);
            ViewData["SubjectList"] = new SelectList(context.Subjects, "Id", "Name", evaluation.SubjectId);

            return View(evaluation);
        }

        // GET: Evaluation/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluation = await context.Evaluations.FindAsync(id);
            if (evaluation == null)
            {
                return NotFound();
            }
            ViewData["StudentList"] = new SelectList(context.Students, "Id", "Name", evaluation.StudentId);
            ViewData["SubjectList"] = new SelectList(context.Subjects, "Id", "Name", evaluation.SubjectId);
            return View(evaluation);
        }

        // POST: Evaluation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,SubjectId,StudentId,Grade,Id")] Evaluation evaluation)
        {
            if (id != evaluation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(evaluation);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvaluationExists(evaluation.Id))
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
            ViewData["StudentList"] = new SelectList(context.Students, "Id", "Name", evaluation.StudentId);
            ViewData["SubjectList"] = new SelectList(context.Subjects, "Id", "Name", evaluation.SubjectId);
            return View(evaluation);
        }

        // GET: Evaluation/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluation = await context.Evaluations
                                          .Include(e => e.Student)
                                          .Include(e => e.Subject)
                                          .FirstOrDefaultAsync(m => m.Id == id);
            if (evaluation == null)
            {
                return NotFound();
            }

            return View(evaluation);
        }

        // POST: Evaluation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var evaluation = await context.Evaluations.FindAsync(id);
            context.Evaluations.Remove(evaluation);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvaluationExists(string id)
        {
            return context.Evaluations.Any(e => e.Id == id);
        }
    }
}
