using ProjetoBenner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace ProjetoBenner.Controllers
{
    public class DashboardController : Controller
    {

        private AgendaONEntities3 db = new AgendaONEntities3();
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Paciente()
        {
            var codigo = Session["Codigo_Pessoa"];
            var pessoa = db.Pessoa.Where(x => x.Codigo_Pessoa == (int)codigo);
            ViewBag.id = new SelectList(pessoa, "Codigo_Acesso", "Codigo_Acesso");
            return View();
        }

        public ActionResult Funcionario()
        {
            return View();
        }

        public ActionResult ADM()
        {
            return View();
        }
    }
}