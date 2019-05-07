using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PlatziAspCore.Models;

namespace PlatziAspCore.Controllers
{
    public class StudentController : Controller
    {

        #region Actions

        public IActionResult Index()
        {
            var student = new Student();
            student.UniqueId = Guid.NewGuid().ToString();
            student.Name = "Pepe Perez";

            return View(student);
        }
        public IActionResult StudentList()
        {
            var students = GenerateRStudents();
            ViewBag.DynamicData = "Test Text";
            ViewBag.Date = DateTime.Now;
            return View(students);
        }

        private List<Student> GenerateRStudents()
        {
            string[] name1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] surName1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] name2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var students = from n1 in name1
                           from n2 in name2
                           from a1 in surName1
                           select new Student { Name = $"{n1} {n2} {a1}", UniqueId = Guid.NewGuid().ToString() };

            return students.OrderBy((x) => x.UniqueId).ToList();
        }
        #endregion
    }
}