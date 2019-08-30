using ProjetoBenner.dto;
using ProjetoBenner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBenner.Controllers
{
    public class PlantaoMedicoController : Controller
    {
        // GET: PlantaoMedico
        public AgendaONEntities3 db = new AgendaONEntities3();
        public ActionResult Index()
        {

            return View();
        }

        public JsonResult GetMedico()
        {
            var pessoas = new List<MedicoDto>();
            foreach (var medico in db.Medico)
            {
                var pessoa = db.Pessoa.Where(x => x.Codigo_Pessoa == medico.Codigo_Pessoa).FirstOrDefault();
                {
                    pessoas.Add(new MedicoDto
                    {
                        Id = medico.Codigo_Medico,
                        Nome = pessoa.Nome

                    });

                }
            }
            return Json(pessoas, JsonRequestBehavior.AllowGet);
        }
    }

}



