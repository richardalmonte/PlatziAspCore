using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PlatziAspCore.Models;

namespace PlatziAspCore.Controllers
{
    public class SchoolController : Controller
    {
        #region Fields
        private readonly SchoolContext context;
        #endregion
        
        #region Constructors

        public SchoolController(SchoolContext context)
        {
            this.context = context;
        }
        #endregion

        #region Actions

        public IActionResult Index()
        {
            // var school = new School();
            // school.FoundationYear = 2005;
            // school.Id = Guid.NewGuid().ToString();
            // school.Name = "Platzi School";
            // school.City = "Bogotá";
            // school.Country = "Colombia";
            // school.SchoolType = SchoolType.High;
            // school.Address = "Av. Siempre Viva";

            ViewBag.DynamicData = "Test Text";
            var school = context.Schools.FirstOrDefault();
            return View(school);
        }
        #endregion
    }
}