using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Learning.Controllers
{
    public class HelloController : Controller
    {
        // GET: Hello
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HelloWorld()
        {
            return Content("Hello cc");
        }
        public ActionResult LearningMVC()
        {
            ViewBag.ThongDiep = "Hoc CC";
            return View();
        }
    }
}