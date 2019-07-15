using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PlatziAspCore.Models;

namespace PlatziAspCore.Controllers
{
    public class StudentController : Controller
    {

        #region Fields
        private readonly SchoolContext context;
        #endregion

        #region Constructors

        public StudentController(SchoolContext context)
        {
            this.context = context;
        }
        #endregion

        #region Actions

        [Route("Student/{studentId}")]
        [Route("Student/Index/{studentId}")]
        public IActionResult Index(string studentId)
        {
            if (!string.IsNullOrWhiteSpace(studentId))
            {
                return View(context.Students.SingleOrDefault(x => x.Id == studentId));
            }
            else
            {
                return View("StudentList", context.Students);
            }
        }


        [Route("Student")]
        [Route("Student/Index")]
        [Route("Student/studentList")]
        public IActionResult StudentList()
        {
            ViewBag.DynamicData = "Test Text";
            ViewBag.Date = DateTime.Now;
            return View(context.Students);
        }


        #endregion
    }
}