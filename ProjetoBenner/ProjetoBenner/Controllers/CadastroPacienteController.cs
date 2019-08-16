using ProjetoBenner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBenner.Controllers
{
    public class CadastroPacienteController : Controller
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

        // GET: CadastrarP
        public ActionResult Cadastro()
        {

            ViewBag.EstadoCivil = new SelectList(estadocivil, "Sigla", "Nome");
            return View();
        }

        public ActionResult CadastrarPaciente(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                pessoa.Acesso.Email = pessoa.Email;
                pessoa.Acesso.Tipo = "Paciente";
                db.Pessoa.Add(pessoa);
                db.SaveChanges();
                return View("Sucesso");
            }
            else
            {
                ViewBag.EstadoCivil = new SelectList(estadocivil, "Sigla", "Nome");
                return View("Cadastro", pessoa);
            }
            

            
        }

        public ActionResult Sucesso()
        {
            return View();
        }
    }
}