using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        [Route("Course/{courseId}")]
        [Route("Course/Index/{courseId}")]
        public IActionResult Index(string courseId)
        {
            if (!string.IsNullOrWhiteSpace(courseId))
            {
                return View(context.Courses.SingleOrDefault(x => x.Id == courseId));
            }
            else
            {
                return View("CourseList", context.Courses);
            }
        }


        [Route("Course")]
        [Route("Course/Index")]
        [Route("Course/CourseList")]
        public IActionResult CourseList()
        {
            ViewBag.DynamicData = "Test Text";
            ViewBag.Date = DateTime.Now;
            return View(context.Courses);
        }

        [Route("Course/Create")]
        public IActionResult Create()
        {
            ViewBag.Date = DateTime.Now;
            return View();
        }

        [HttpPost]
        [Route("Course/Create")]
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
                return View("Index", course);
            }
            else
            {
                return View(course);
            }

        }
        #endregion
    }
}
