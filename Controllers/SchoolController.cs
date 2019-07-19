using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlatziAspCore.Models;

namespace PlatziAspCore.Controllers
{
    public class SchoolController : Controller
    {
        private readonly SchoolContext context;

        public SchoolController(SchoolContext context)
        {
            this.context = context;
        }

        // GET: School

        public async Task<IActionResult> Index()
        {
            return View(await context.Schools.ToListAsync());
        }

        // GET: School/Details/5
        [Route("School/{schoolId}")]
        [Route("School/Details/{schoolId}")]
        public async Task<IActionResult> Details(string schoolId)
        {
            if (schoolId == null)
            {
                return NotFound();
            }

            var school = await context.Schools
                .FirstOrDefaultAsync(m => m.Id == schoolId);
            if (school == null)
            {
                return NotFound();
            }

            return View(school);
        }

        // GET: Schools/Create
        [Route("School/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Schools/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("School/Create")]
        public async Task<IActionResult> Create(School school)
        {
            if (ModelState.IsValid)
            {
                context.Add(school);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(school);
        }

        // GET: Schools/Edit/5
        [Route("School/Edit/{schoolId}")]
        public async Task<IActionResult> Edit(string schoolId)
        {
            if (schoolId == null)
            {
                return NotFound();
            }

            var school = await context.Schools.FindAsync(schoolId);
            if (school == null)
            {
                return NotFound();
            }
            return View(school);
        }

        // POST: Schools/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FoundationYear,Address,Country,City,SchoolType,Id,Name")] School school)
        {
            if (id != school.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(school);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchoolExists(school.Id))
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
            return View(school);
        }

        // GET: Schools/Delete/5
        [Route("School/Delete/{schoolId}")]
        public async Task<IActionResult> Delete(string schoolId)
        {
            if (schoolId == null)
            {
                return NotFound();
            }

            var school = await context.Schools.FirstOrDefaultAsync(m => m.Id == schoolId);
            if (school == null)
            {
                return NotFound();
            }

            return View(school);
        }

        // POST: Schools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var school = await context.Schools.FindAsync(id);
            context.Schools.Remove(school);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchoolExists(string id)
        {
            return context.Schools.Any(e => e.Id == id);
        }
    }
}
