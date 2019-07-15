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

        [Route("Subject")]
        [Route("Subject/Index")]
        [Route("Subject/Index/{subjectId}")]
        public IActionResult Index(string subjectId)
        {
            if (!string.IsNullOrWhiteSpace(subjectId))
            {
                return View(context.Subjects.SingleOrDefault(x => x.Id == subjectId));
            }
            else
            {
                return View("SubjectList", context.Subjects);
            }
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