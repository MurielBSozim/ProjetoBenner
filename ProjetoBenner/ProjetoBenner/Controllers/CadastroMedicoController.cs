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

        private List<object> especiliade = new List<object>
        {
            new {Sigla = "", Nome = ""},
            new {Sigla = "ACUPUNTURA", Nome = "ACUPUNTURA"},
            new {Sigla = "ANESTESIOLOGIA", Nome = "ANESTESIOLOGIA"},
            new {Sigla = "ALERGIA E IMUNOLOGIA", Nome = "ALERGIA E IMUNOLOGIA"},
            new {Sigla = "ANGIOLOGIA", Nome = "ANGIOLOGIA"},
            new {Sigla = "CANCEROLOGIA/CANCEROLOGIA CLÍNICA", Nome = "CANCEROLOGIA/CANCEROLOGIA CLÍNICA"},
            new {Sigla = "CANCEROLOGIA/CANCEROLOGIA CIRURGICA", Nome = "CANCEROLOGIA/CANCEROLOGIA CIRURGICA"},
            new {Sigla = "CANCEROLOGIA/CANCEROLOGIA PEDIÁTRICA", Nome = "CANCEROLOGIA/CANCEROLOGIA PEDIÁTRICA"},
            new {Sigla = "CARDIOLOGIA", Nome = "CARDIOLOGIA"},
            new {Sigla = "CARDIOLOGIA INFANTIL", Nome = "CARDIOLOGIA INFANTIL"},
            new {Sigla = "CIRURGIA CARDIO-VASCULAR", Nome = "CIRURGIA CARDIO-VASCULAR"},
            new {Sigla = "CIRURGIA DE CABEÇA E PESCOÇO", Nome = "CIRURGIA DE CABEÇA E PESCOÇO"},
            new {Sigla = "CIRURGIA DO APARELHO DIGESTIVO", Nome = "CIRURGIA DO APARELHO DIGESTIVO"},
            new {Sigla = "CIRURGIA GERAL", Nome = "CIRURGIA GERAL"},
            new {Sigla = "CIRURGIA PEDIATRICA", Nome = "CIRURGIA PEDIATRICA"},
            new {Sigla = "CIRURGIA PLASTICA E REPARADORA", Nome = "CIRURGIA PLASTICA E REPARADORA"},
            new {Sigla = "CIRURGIA TORACICA", Nome = "CIRURGIA TORACIC"},
            new {Sigla = "CIRURGIA VASCULAR", Nome = "CIRURGIA VASCULAR"},
            new {Sigla = "CLÍNICA MÉDICA", Nome = "CLÍNICA MÉDICA"}, 
            new {Sigla = "COLOPROCTOLOGIA", Nome = "COLOPROCTOLOGIA"},
            new {Sigla = "DERMATOLOGIA", Nome = "DERMATOLOGIA"},
            new {Sigla = "INFECTOLOGIA", Nome = "INFECTOLOGIA"},
            new {Sigla = "ENDOCRINOLOGIA PEDIATRICA", Nome = "ENDOCRINOLOGIA PEDIATRICA"},
            new {Sigla = "ENDOSCOPIA", Nome = "ENDOSCOPIA"},
            new {Sigla = "FISIOTERAPIA/REABILITACAO MOTORA", Nome = "FISIOTERAPIA/REABILITACAO MOTORA"},
            new {Sigla = "FONOAUDIOLOGIA", Nome = "FONOAUDIOLOGIA"},
            new {Sigla = "GASTROENTEROLOGIA", Nome = "GASTROENTEROLOGIA"},
            new {Sigla = "GASTROENTEROLOGIA INFANTIL", Nome = "GASTROENTEROLOGIA INFANTIL"},
            new {Sigla = "GENETICA", Nome = "GENETICA"},
            new {Sigla = "GERIATRIA E GERONTOLOGIA", Nome = "GERIATRIA E GERONTOLOGIA"},
            new {Sigla = "GINECOLOGIA", Nome = "GINECOLOGIA"},                                                 
            new {Sigla = "HEMATOLOGIA", Nome = "HEMATOLOGIA"},                                       
            new {Sigla = "HEMOTERAPIA", Nome = "HEMOTERAPIA"},                                       
            new {Sigla = "HEPATOLOGIA", Nome = "HEPATOLOGIA"},                                       
            new {Sigla = "HOMEOPATIA", Nome = "HOMEOPATIA"},
            new {Sigla = "INFECTOLOGIA", Nome = "INFECTOLOGIA"},
            new {Sigla = "MASTOLOGIA", Nome = "MASTOLOGIA"},
            new {Sigla = "MEDICINA DE FAMÍLIA E COMUNIDADE", Nome = "MEDICINA DE FAMÍLIA E COMUNIDADE"},
            new {Sigla = "MEDICINA DO TRABALHO", Nome = "MEDICINA DO TRABALHO"},
            new {Sigla = "MEDICINA DO TRAFEGO", Nome = "MEDICINA DO TRAFEGO"},
            new {Sigla = "MEDICINA ESPORTIVA", Nome = "MEDICINA ESPORTIVA"},
            new {Sigla = "MEDICINA FISICA E REABILITACAO", Nome = "MEDICINA FISICA E REABILITACAO"},
            new {Sigla = "MEDICINA INTENSIVA", Nome = "MEDICINA INTENSIVA"},
            new {Sigla = "MEDICINA LEGAL", Nome = "MEDICINA LEGAL"},
            new {Sigla = "MEDICINA GERAL", Nome = "MEDICINA GERAL"},
            new {Sigla = "MEDICINA NUCLEAR", Nome = "MEDICINA NUCLEAR"},
            new {Sigla = "MEDICINA PREVENTIVA E SOCIAL", Nome = "MEDICINA PREVENTIVA E SOCIAL"},
            new {Sigla = "NEFROLOGIA", Nome = "NEFROLOGIA"},
            new {Sigla = "NEFROLOGIA INFANTIL", Nome = "NEFROLOGIA INFANTIL"},
            new {Sigla = "NEUROCIRURGIA", Nome = "NEUROCIRURGIA"},
            new {Sigla = "NEONATOLOGIA", Nome = "NEONATOLOGIA"},
            new {Sigla = "NEUROLOGIA", Nome = "NEUROLOGIA"},
            new {Sigla = "NUTROLOGIA", Nome = "NUTROLOGIA"},
            new {Sigla = "OFTALMOLOGIA", Nome = "OFTALMOLOGIA"},
            new {Sigla = "ORTOPEDIA E TRAUMATOLOGIA", Nome = "ORTOPEDIA E TRAUMATOLOGIA"},
            new {Sigla = "OTORRINOLARINGOLOGIA", Nome = "OTORRINOLARINGOLOGIA"},
            new {Sigla = "PATOLOGIA", Nome = "PATOLOGIA"},
            new {Sigla = "PATOLOGIA CLINICA (ANALISES CLINICAS)", Nome = "PATOLOGIA CLINICA (ANALISES CLINICAS)"},
            new {Sigla = "PEDIATRIA", Nome = "PEDIATRIA"},
            new {Sigla = "PNEUMOLOGIA", Nome = "PNEUMOLOGIA"},
            new {Sigla = "PNEUMOLOGIA INFANTIL", Nome = "PNEUMOLOGIA INFANTIL"},
            new {Sigla = "PSIQUIATRIA", Nome = "PSIQUIATRIA"},
            new {Sigla = "RADIOLOGIA E DIAGNÓSTICO POR IMAGEM", Nome = "RADIOLOGIA E DIAGNÓSTICO POR IMAGEM"},
            new {Sigla = "QUIMIOTERAPIA", Nome = "QUIMIOTERAPIA"},
            new {Sigla = "RADIOLOGIA INTERVENCIONISTA", Nome = "RADIOLOGIA INTERVENCIONISTA"},
            new {Sigla = "RADIOTERAPIA", Nome = "RADIOLOGIA"},
            new {Sigla = "REUMATOLOGIA", Nome = "REUMATOLOGIA"},
            new {Sigla = "TERAPIA DA DOR", Nome = "TERAPIA DA DOR"},
            new {Sigla = "TERAPIA OCUPACIONAL", Nome = "TERAPIA OCUPACIONAL"},
            new {Sigla = "TOMOGRAFIA COMPUTADORIZADA", Nome = "TOMOGRAFIA COMPUTADORIZADA"},
            new {Sigla = "UROLOGIA", Nome = "UROLOGIA"}
        };


        // GET: CadastroMedico
        public ActionResult Index()
        {
            ViewBag.Estado = new SelectList(estado, "Sigla", "Nome");
            ViewBag.EstadoCivil = new SelectList(estadocivil, "Sigla", "Nome");
            ViewBag.Especialidade = new SelectList(especiliade, "Sigla", "Nome");
            return View();
        }

        public ActionResult CadastrarMedico(Pessoa pessoa)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Estado = new SelectList(estado, "Sigla", "Nome");
                ViewBag.EstadoCivil = new SelectList(estadocivil, "Sigla", "Nome");
                ViewBag.Especialidade = new SelectList(especiliade, "Sigla", "Nome");
                return View("Index", pessoa);
            }
            pessoa.Acesso.Email = pessoa.Email;
            pessoa.Acesso.Tipo = "Medico";
            db.Pessoa.Add(pessoa);
            db.SaveChanges();
            ViewBag.Estado = new SelectList(estado, "Sigla", "Nome");
            ViewBag.EstadoCivil = new SelectList(estadocivil, "Sigla", "Nome");
            ViewBag.Especialidade = new SelectList(especiliade, "Sigla", "Nome");
            return View("Medico");

        }

        public ActionResult Medico(Medico medico)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Estado = new SelectList(estado, "Sigla", "Nome");
                ViewBag.EstadoCivil = new SelectList(estadocivil, "Sigla", "Nome");
                ViewBag.Especialidade = new SelectList(especiliade, "Sigla", "Nome");
                return View("Medico", medico);
            }

            db.Medico.Add(medico);
            db.SaveChanges();
            ViewBag.Estado = new SelectList(estado, "Sigla", "Nome");
            ViewBag.EstadoCivil = new SelectList(estadocivil, "Sigla", "Nome");
            ViewBag.Especialidade = new SelectList(especiliade, "Sigla", "Nome");
            return View("Especialidade");
        }

        public ActionResult Especialidade(Especialidade esp)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Estado = new SelectList(estado, "Sigla", "Nome");
                ViewBag.EstadoCivil = new SelectList(estadocivil, "Sigla", "Nome");
                ViewBag.Especialidade = new SelectList(especiliade, "Sigla", "Nome");
                return View("Especialidade", esp);
            }
            db.Especialidade.Add(esp);
            db.SaveChanges();
            
            return View("Sucesso");
        }
        public ActionResult Sucesso()
        {
            return View();
        }
    }
}