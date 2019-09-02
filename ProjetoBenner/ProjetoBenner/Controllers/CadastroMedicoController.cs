using ProjetoBenner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBenner.Controllers
{
    public class CadastroMedicoController : Controller
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

        private List<object> estado = new List<object>
        {
            new {Sigla = "", Nome = ""},
            new {Sigla = "AC", Nome = "Acre"},
            new {Sigla = "AL", Nome = "Alogas"},
            new {Sigla = "AM", Nome = "Amapá"},
            new {Sigla = "AM", Nome = "Amazonas"},
            new {Sigla = "BH", Nome = "Bahia"},
            new {Sigla = "CE", Nome = "Ceará"},
            new {Sigla = "DF", Nome = "Distrito Federal"},
            new {Sigla = "ES", Nome = "Espírito Santo"},
            new {Sigla = "GO", Nome = "Goiás"},
            new {Sigla = "MA", Nome = "Maranhão"},
            new {Sigla = "MT", Nome = "Mato Grosso" },
            new {Sigla = "MS", Nome = "Mato Grosso do Sul" },
            new {Sigla = "MG", Nome = "Minas Gerais" },
            new {Sigla = "PA", Nome = "Pará" },
            new {Sigla = "PB", Nome = "Paraíba" },
            new {Sigla = "PR", Nome = "Paraná" },
            new {Sigla = "PE", Nome = "Pernambuco" },
            new {Sigla = "PI", Nome = "Piauí" },
            new {Sigla = "RJ", Nome = "Rio de Janeiro" },
            new {Sigla = "RN", Nome = "Rio Grande do Norte" },
            new {Sigla = "RS", Nome = "Rio Grande do Sul" },
            new {Sigla = "RO", Nome = "Rondônia" },
            new {Sigla = "RR", Nome = "Roraima" },
            new {Sigla = "SC", Nome = "Santa Catarina" },
            new {Sigla = "SP", Nome = "São Paulo" },
            new {Sigla = "SE", Nome = "Sergipe" },
            new {Sigla = "TO", Nome = "Tocantins" }
         };

        

        // GET: CadastroMedico
        public ActionResult Index()
        {
            ViewBag.Especialidade = new SelectList(db.Descricao_Especialidade, "Codigo_Especialidade", "Nome");
            ViewBag.Pessoa = new SelectList(db.Pessoa, "Codigo_Pessoa", "Nome");
            ViewBag.Estado = new SelectList(estado, "Sigla", "Nome");
            ViewBag.EstadoCivil = new SelectList(estadocivil, "Sigla", "Nome");
           
            return View();
        }

        public ActionResult CadastrarMedico(Pessoa pessoa)
        {
            if (pessoa.CPF != null)
            {
                if (!ValidaCPF.Validar(pessoa.CPF))
                {
                    pessoa.CPFErrorMessage = "Numero de cpf inválido";
                    ViewBag.Especialidade = new SelectList(db.Descricao_Especialidade, "Codigo_Especialidade", "Nome");
                    ViewBag.Pessoa = new SelectList(db.Pessoa, "Codigo_Pessoa", "Nome");
                    ViewBag.Estado = new SelectList(estado, "Sigla", "Nome");
                    ViewBag.EstadoCivil = new SelectList(estadocivil, "Sigla", "Nome");
                    return View("Cadastro", pessoa);
                }
            }
            if (!ModelState.IsValid)
            {
                ViewBag.Especialidade = new SelectList(db.Descricao_Especialidade, "Codigo_Especialidade", "Nome");
                ViewBag.Pessoa = new SelectList(db.Pessoa, "Codigo_Pessoa", "Nome");
                ViewBag.Estado = new SelectList(estado, "Sigla", "Nome");
                ViewBag.EstadoCivil = new SelectList(estadocivil, "Sigla", "Nome");
             
                return View("Index", pessoa);
            }
            pessoa.Acesso.Email = pessoa.Email;
            pessoa.Acesso.Tipo = "Medico";
            db.Pessoa.Add(pessoa);
            db.SaveChanges();
            ViewBag.Especialidade = new SelectList(db.Descricao_Especialidade, "Codigo_Especialidade", "Nome");
            ViewBag.Pessoa = new SelectList(db.Pessoa, "Codigo_Pessoa", "Nome");
            ViewBag.Estado = new SelectList(estado, "Sigla", "Nome");
            ViewBag.EstadoCivil = new SelectList(estadocivil, "Sigla", "Nome");
          
            return View("Medico");

        }

        public ActionResult Medico(Medico medico)
        {
            if(!ModelState.IsValid)

            {
                ViewBag.Estado = new SelectList(estado, "Sigla", "Nome");
                ViewBag.EstadoCivil = new SelectList(estadocivil, "Sigla", "Nome");
                ViewBag.Pessoa = new SelectList(db.Pessoa, "Codigo_Pessoa", "Nome");
                ViewBag.Especialidade = new SelectList(db.Descricao_Especialidade, "Codigo_Especialidade", "Nome");

                return View("Medico", medico);
            }
            ViewBag.Pessoa = new SelectList(db.Pessoa, "Codigo_Pessoa", "Nome");
            ViewBag.Especialidade = new SelectList(db.Descricao_Especialidade, "Codigo_Especialidade", "Nome");
            db.Medico.Add(medico);
            db.SaveChanges();
          
          
            return View("Sucesso");
        }

        public ActionResult Sucesso()
        {
            return View();
        }
    }
}