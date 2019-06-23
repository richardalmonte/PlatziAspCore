using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PlatziAspCore.Models;

namespace PlatziAspCore.Controllers
{
    public class SubjectController : Controller
    {
        #region Fields
        private readonly SchoolContext context;
        #endregion

        #region Constructors

        public SubjectController(SchoolContext context)
        {
            this.context = context;
        }
        #endregion

        #region Actions

        public IActionResult Index()
        {
            return View(context.Subjects.FirstOrDefault());
        }
        public IActionResult SubjectList()
        {
            ViewBag.DynamicData = "Test Text";
            ViewBag.Date = DateTime.Now;
            return View(context.Subjects);
        }
        #endregion

    }
}