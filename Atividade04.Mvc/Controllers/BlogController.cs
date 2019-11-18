using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Atividade04.Mvc.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BlogList()
        {
            // Buscar todos os blogs ordenando pelo blog que fez a postagem mais recente até o mais antigo

            //try
            //{
            //    using (var aplicacao = Container.Obter<BicoAplicacao>())
            //    {
            //        string codigo = StringRequest("codigo");
            //        List<BicoGrid> bicos = aplicacao.RetornaBicos(filtro).OrderBy(d => d.Codigo);
            //        ViewBag.codigo = codigo;

            //        return PartialView(bicos);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    return Json(ResultadoOperacao.CriarFalha(ex.Message));
            //}


            return PartialView();
        }
    }
}