using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Atividade04.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToRoute(new { controller = "Blog", action = "Index" });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Blogs - BIG DATA - Univali";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Blogs - BIG DATA - Univali";

            return View();
        }
    }
}