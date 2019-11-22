using Atividade04.Application;
using Atividade04.Domain;
using Atividade4.Infra;
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
            var blogs = Helper.GetFiltered<Blog>(b => b.Posts != null).ToList();
               //.OrderBy(x => x.Posts.OrderByDescending(y => y.Date)).ToList();
            return View(blogs);
        }
    }
}