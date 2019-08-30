using ProjetoBenner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBenner.Controllers
{
    public class CadastroLocalController : Controller
    {
        public AgendaONEntities3 db = new AgendaONEntities3();
        // GET: CadastroLocal
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CadastrarLocal(Local local)
        {
            if (!ModelState.IsValid)
            {
               return View("Index", local);
            }

            db.Local.Add(local);
            db.SaveChanges();
            return View("Sucesso");
        }

        public ActionResult Sucesso()
        {
            return View();
        }
    }
    
}