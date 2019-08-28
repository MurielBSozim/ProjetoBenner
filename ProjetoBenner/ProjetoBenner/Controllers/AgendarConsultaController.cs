using ProjetoBenner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBenner.Controllers
{
    public class AgendarConsultaController : Controller
    {
        public AgendaONEntities db = new AgendaONEntities();
        // GET: AgendarConsulta
        public ActionResult Index()
        {
            List<Especialidade> especialidade = new List<Especialidade>();
            especialidade = db.Especialidade.ToList();

            ViewBag.especialidade = new SelectList(db.Especialidade,"Codigo_Especialidade", "Especialidade1");
            
            return View();
        }


        //public ActionResult Agendar(Agenda agenda) {

           
        //    return View("Index");                    
        //}

    }
}