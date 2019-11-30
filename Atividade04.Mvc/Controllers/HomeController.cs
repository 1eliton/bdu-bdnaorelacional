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
            //var teste = blogs.FirstOrDefault().Posts.OrderByDescending();
            //var blogs2 = Helper.GetFiltered<Blog>(b => b.Posts != null);
            //var dicionario = blogs.Select(i => new Tuple<Blog, List<Post>>(i, i.Posts)).ToList();
            //var terceiro = dicionario.Select(x => new { a = x.Item1, b = x.Item2 }).ToList()
            //    .OrderByDescending(y => y.b.OrderByDescending(t => t.Date)).ToList();

                //.SelectMany(i => new { a = i.Posts, b = i.Title }).ToList();
               //.OrderBy(x => x.Posts.OrderByDescending(y => y.Date)).ToList();
            return View(blogs);
        }
    }
}