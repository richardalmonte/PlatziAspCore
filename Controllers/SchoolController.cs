using System;
using Microsoft.AspNetCore.Mvc;
using PlatziAspCore.Models;

namespace PlatziAspCore.Controllers
{
    public class SchoolController : Controller
    {

        #region Actions

        public IActionResult Index()
        {
            var school = new School();
            school.FoundationYear = 2005;
            school.SchoolId = Guid.NewGuid().ToString();
            school.Name = "Platzi School";
            ViewBag.DynamicData= "Test Text";
            return View(school);
        }
        #endregion

    }
}