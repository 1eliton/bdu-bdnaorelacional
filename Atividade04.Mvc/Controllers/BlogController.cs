using Atividade04.Domain;
using Atividade4.Infra;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Atividade04.Mvc.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog da sessao
        public ActionResult Index()
        {
            HttpCookie cookie = Request.Cookies["atividade4-user"];
            if (cookie != null)
            {
                var blog = Helper.GetFiltered<Blog>(b => b.User.Login == cookie.Value).FirstOrDefault();
                return View(blog);
            }

            return View();
        }

        /// <summary>
        /// blog do Id recebido
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index2(string id)
        {
            var blog = Helper.GetFiltered<Blog>(b => b.Id == new ObjectId(id)).FirstOrDefault();
            return View("Index", blog);
        }

        public ActionResult Posts(ObjectId Id)
        {
            var blog = Helper.GetFiltered<Blog>(f => f.Id.Equals(Id));
            if (blog != null)
            {
                if (blog.FirstOrDefault().Posts != null)
                    return View(blog.FirstOrDefault().Posts.OrderByDescending(a => a.Date).ToList());
                else
                    return View();
            }
            return View();
        }
    }
}