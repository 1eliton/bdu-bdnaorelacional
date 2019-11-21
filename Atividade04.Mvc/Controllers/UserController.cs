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
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var isUserLogged = Helper.GetFiltered<Blog>(p => p.User.Password == user.Password && p.User.Login == user.Login).Any();
            if (isUserLogged)
            {
                setCookie(user.Login);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Json("Usuario ou senha incorretos");
            }
        }

        [HttpGet]
        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var blog = new Blog
                {
                    Description = collection.GetValue("BlogDescription").AttemptedValue.ToString(),
                    Title = collection.GetValue("BlogTitle").AttemptedValue.ToString(),
                    User = new User
                    {
                        Name = collection.GetValue("Name").AttemptedValue.ToString(),
                        Login = collection.GetValue("Login").AttemptedValue.ToString(),
                        Password = collection.GetValue("Password").AttemptedValue.ToString(),
                        Role = Domain.Enum.UserRole.Owner
                    }
                };

                Task.Run(async () => await Helper.InsertOneAsync(blog));

                setCookie(collection.GetValue("Login").AttemptedValue.ToString());

                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                return Json($"Erro ao cadastrar usuario/blog: {e.Message}");
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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

        private void setCookie(string login)
        {
            // seta o cookie da pessoa
            HttpCookie cookie = new HttpCookie("atividade4-user");
            cookie.Value = login;
            cookie.Expires = DateTime.Now.AddYears(50);
            
            Response.Cookies.Add(cookie);
        }
    }
}
