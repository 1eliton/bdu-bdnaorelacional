using Atividade04.Domain;
using Atividade4.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Atividade04.Mvc.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }


        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var post = new Post { };
                Task.Run(async () => await Helper.InsertOneAsync(post));
                return RedirectToRoute(new { Controller = "Blog", Action = "Index"});
            }
            catch
            {
                return View();
            }
        }

        public PartialViewResult NovaSessao()
        {
            return PartialView("Section");
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
