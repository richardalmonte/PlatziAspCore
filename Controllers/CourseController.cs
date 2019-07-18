using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlatziAspCore.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlatziAspCore.Controllers
{
    public class CourseController : Controller
    {

        #region Fields

        private readonly SchoolContext context;

        #endregion

        #region Constructors

        public CourseController(SchoolContext context)
        {
            this.context = context;
        }

        #endregion

        #region Actions

        [Route("Course")]
        [Route("Course/Index")]
        public async Task<IActionResult> Index()
        {
            var courses = context.Courses.Include(c => c.School);
            return View(await courses.ToListAsync());
        }

        

        // GET: Courses/Details/5
        [Route(template: "Course/{courseId}")]
        [Route(template: "Course/Index/{courseId}")]
        [Route(template: "Course/Details/{courseId}")]
        public async Task<IActionResult> Details(string courseId)
        {
            if (courseId == null)
            {
                return NotFound();
            }

            var course = await context.Courses
                                      .Include(navigationPropertyPath: c => c.School)
                                      .FirstOrDefaultAsync(predicate: m => m.Id == courseId);
            if (course == null)
            {
                return NotFound();
            }

            return View(model: course);
        }


        [Route("Course/Create")]
        public IActionResult Create()
        {
            ViewBag.Date = DateTime.Now;
            ViewData["SchoolList"] = new SelectList(context.Schools, "Id", "Name");
            return View();
        }

        [HttpPost]
        [Route("Course/Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                course.Id = Guid.NewGuid().ToString();
                var school = context.Schools.FirstOrDefault();
                course.SchoolId = school?.Id;

                context.Courses.Add(course);

                context.SaveChanges();

                ViewBag.Message = "Created View";
                return View("Details", course);
            }
            else
            {
                ViewData["SchoolList"] = new SelectList(context.Schools, "Id", "Name");
                return View(course);
            }

        }

        // GET: CoursesControllerTest/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            ViewData["SchoolList"] = new SelectList(context.Schools, "Id", "Name");

            return View(course);
        }

        // POST: CoursesControllerTest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,DayType,Address,SchoolId,Id")]
            Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(course);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id))
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

            ViewData["SchoolList"] = new SelectList(context.Schools, "Id", "Name");
            return View(course);
        }

        // GET: CoursesControllerTest/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await context.Courses
                .Include(c => c.School)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: CoursesControllerTest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var course = await context.Courses.FindAsync(id);
            context.Courses.Remove(course);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(string id)
        {
            return context.Courses.Any(e => e.Id == id);

            #endregion
        }
    }
}
