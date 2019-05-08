using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PlatziAspCore.Models;

namespace PlatziAspCore.Controllers
{
    public class SubjectController : Controller
    {

        #region Actions

        public IActionResult Index()
        {
            var subject = new Subject();
            subject.Id = Guid.NewGuid().ToString();
            subject.Name = "Programming";

            return View(subject);
        }
        public IActionResult SubjectList()
        {
            var subject = new List<Subject>(){
                new Subject{
                    Name ="Programming",
                    Id = Guid.NewGuid().ToString()
                },
                new Subject{
                    Name ="Mathematics",
                    Id = Guid.NewGuid().ToString()
                },
                new Subject{
                    Name ="Physics",
                    Id = Guid.NewGuid().ToString()
                },
                new Subject{
                    Name ="English",
                    Id = Guid.NewGuid().ToString()
                },
                new Subject{
                    Name ="History",
                    Id = Guid.NewGuid().ToString()
                }
            };
            ViewBag.DynamicData = "Test Text";
            ViewBag.Date = DateTime.Now;
            return View(subject);
        }
        #endregion

    }
}