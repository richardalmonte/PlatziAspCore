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
            subject.UniqueId = Guid.NewGuid().ToString();
            subject.Name = "Programming";

            return View(subject);
        }
        public IActionResult SubjectList()
        {
            var subject = new List<Subject>(){
                new Subject{
                    Name ="Programming",
                    UniqueId = Guid.NewGuid().ToString()
                },
                new Subject{
                    Name ="Mathematics",
                    UniqueId = Guid.NewGuid().ToString()
                },
                new Subject{
                    Name ="Physics",
                    UniqueId = Guid.NewGuid().ToString()
                },
                new Subject{
                    Name ="English",
                    UniqueId = Guid.NewGuid().ToString()
                },
                new Subject{
                    Name ="History",
                    UniqueId = Guid.NewGuid().ToString()
                }
            };
            ViewBag.DynamicData = "Test Text";
            ViewBag.Date = DateTime.Now;
            return View(subject);
        }
        #endregion

    }
}