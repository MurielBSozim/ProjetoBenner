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
        public AgendaONEntities3 db = new AgendaONEntities3();

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
            ViewBag.MensagemErro = db.Pessoa.Any(a => a.Email == pessoa.Email);
            ViewBag.MensagemErroCPF = db.Pessoa.Any(a => a.CPF == pessoa.CPF);
            if (pessoa.CPF != null)
            {
                if (!ValidaCPF.Validar(pessoa.CPF))
                {
                    pessoa.CPFErrorMessage = "Numero de cpf inválido";
                    ViewBag.EstadoCivil = new SelectList(estadocivil, "Sigla", "Nome");
                    return View("Cadastro", pessoa);
                }
            }
            
                if (!ModelState.IsValid || ViewBag.MensagemErro || ViewBag.MensagemErroCPF)
                {
                    ViewBag.EstadoCivil = new SelectList(estadocivil, "Sigla", "Nome");
                    return View("Cadastro", pessoa);
                }
                pessoa.Acesso.Email = pessoa.Email;
                pessoa.Acesso.Tipo = "Paciente";
                db.Pessoa.Add(pessoa);
                db.SaveChanges();

                return View("Sucesso");

            
        }


        public ActionResult Sucesso()
        {
            return View();
        }
    }
}