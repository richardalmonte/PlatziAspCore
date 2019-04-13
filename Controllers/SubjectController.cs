using System;
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

            ViewBag.DynamicData = "Test Text";
            ViewBag.Date = DateTime.Now;
            return View(subject);
        }
        #endregion

    }
}