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

        public IActionResult Index()
        {
            return View(context.Students.FirstOrDefault());
        }
        public IActionResult StudentList()
        {
            ViewBag.DynamicData = "Test Text";
            ViewBag.Date = DateTime.Now;
            return View(context.Students);
        }

        //private List<Student> GenerateRStudents()
        //{
        //    string[] name1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
        //    string[] surName1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
        //    string[] name2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

        //    var students = from n1 in name1
        //                   from n2 in name2
        //                   from a1 in surName1
        //                   select new Student { Name = $"{n1} {n2} {a1}", Id = Guid.NewGuid().ToString() };

        //    return students.OrderBy((x) => x.Id).ToList();
        //}
        #endregion
    }
}