using ProjetoBenner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBenner.Controllers
{
    public class CadastroSecretariaController : Controller
    {

        public AgendaONEntities db = new AgendaONEntities();

        private List<object> estadocivil = new List<object>
        {
            new {Sigla = "", Nome = ""},
            new {Sigla = "Solteiro" ,Nome = "Solteiro"},
            new {Sigla = "Casado", Nome = "Casado"},
            new {Sigla = "Separado", Nome = "Separado"},
            new {Sigla = "Divorciado", Nome = "Divorciado"},
            new {Sigla = "Viuvo", Nome = "Viuvo"}
        };
        // GET: CadastroSecretaria
        public ActionResult Index()
        {
            ViewBag.EstadoCivil = new SelectList(estadocivil, "Sigla", "Nome");
            return View();
        }

        public ActionResult CadastrarSecretaria(Pessoa pessoa)
        {
            if (!ModelState.IsValid)
            {
                
                ViewBag.EstadoCivil = new SelectList(estadocivil, "Sigla", "Nome");
                return View("Index", pessoa);
            }
           
            pessoa.Acesso.Email = pessoa.Email;
            pessoa.Acesso.Tipo = "Secretaria";
            db.Pessoa.Add(pessoa);
            db.SaveChanges();
           
            ViewBag.EstadoCivil = new SelectList(estadocivil, "Sigla", "Nome");
            return View("Secretaria");
        }

        public ActionResult Secretaria(Secretaria secretaria)
        {
            if (!ModelState.IsValid)
            {
                              
                return View("Secretaria", secretaria);
            }
            Pessoa pessoa = db.Pessoa.Find(secretaria.Codigo_Secretaria);
            secretaria.Codigo_Pessoa = pessoa.Codigo_Pessoa;
            db.Secretaria.Add(secretaria);
            db.SaveChanges();
           
            return View("Sucesso", "CadastroMedico");
        }
    }
}