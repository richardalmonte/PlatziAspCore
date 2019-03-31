using Microsoft.AspNetCore.Mvc;

namespace PlatziAspCore.Controllers
{
    public class SchoolController : Controller
    {

        #region Actions

        public IActionResult Index()
        {
            return View();
        }
        #endregion

    }
}