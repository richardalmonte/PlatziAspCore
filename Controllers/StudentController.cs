using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlatziAspCore.Models;

namespace PlatziAspCore.Controllers
{
    public class StudentController : Controller
    {
        private readonly SchoolContext context;

        public StudentController(SchoolContext context)
        {
            this.context = context;
        }


        [Route("Student")]
        [Route("Student/Index")]
        // GET: Students
        public async Task<IActionResult> Index()
        {
            var schoolContext = context.Students.Include(s => s.Course);
            return View(await schoolContext.ToListAsync());
        }

        // GET: Students/Details/5
        [Route("Student/{studentId}")]
        [Route("Student/Index/{studentId}")]
        public async Task<IActionResult> Details(string studentId)
        {
            if (studentId == null)
            {
                return NotFound();
            }

            var student = await context.Students
                                       .Include(s => s.Course)
                                       .FirstOrDefaultAsync(m => m.Id == studentId);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["CourseList"] = new SelectList(context.Courses, "Id", "Name");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,CourseId,Id")] Student student)
        {
            if (ModelState.IsValid)
            {
                context.Add(student);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseList"] = new SelectList(context.Courses, "Id", "Name", student.CourseId);
            return View(student);
        }

        // GET: Students/Edit/5

        [Route("Student/Edit/{studentId}")]
        public async Task<IActionResult> Edit(string studentId)
        {
            if (studentId == null)
            {
                return NotFound();
            }

            var student = await context.Students.FindAsync(studentId);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["CourseList"] = new SelectList(context.Courses, "Id", "Name", student.CourseId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,CourseId,Id")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(student);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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
            ViewData["CourseList"] = new SelectList(context.Courses, "Id", "Name", student.CourseId);
            return View(student);
        }

        // GET: Students/Delete/5

        [Route("Student/Delete/{studentId}")]
        public async Task<IActionResult> Delete(string studentId)
        {
            if (studentId == null)
            {
                return NotFound();
            }

            var student = await context.Students
                .Include(s => s.Course)
                .FirstOrDefaultAsync(m => m.Id == studentId);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var student = await context.Students.FindAsync(id);
            context.Students.Remove(student);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(string id)
        {
            return context.Students.Any(e => e.Id == id);
        }
    }
}
