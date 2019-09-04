using ProjetoBenner.dto;
using ProjetoBenner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjetoBenner.Controllers
{
    public class AgendarConsultaController : Controller
    {
        public AgendaONEntities3 db = new AgendaONEntities3();

        private List<object> horario = new List<object>
        {
            new {Sigla = "", Nome = ""},
            new {Sigla = "08:00" ,Nome = "08:00"},
            new {Sigla = "08:30" ,Nome = "08:30"},
            new {Sigla = "09:00" ,Nome = "09:00"},
            new {Sigla = "09:30" ,Nome = "09:30"},
            new {Sigla = "10:00" ,Nome = "10:00"},
            new {Sigla = "10:30" ,Nome = "10:30"},
            new {Sigla = "11:00" ,Nome = "11:00"},
            new {Sigla = "11:30" ,Nome = "11:30"},
            
            new {Sigla = "13:00" ,Nome = "13:00"},
            new {Sigla = "13:30" ,Nome = "13:30"},
            new {Sigla = "14:00" ,Nome = "14:00"},
            new {Sigla = "14:30" ,Nome = "14:30"},
            new {Sigla = "15:00" ,Nome = "15:00"},
            new {Sigla = "15:30" ,Nome = "15:30"},
            new {Sigla = "16:00" ,Nome = "16:00"},
            new {Sigla = "16:30" ,Nome = "16:30"},
            new {Sigla = "17:00" ,Nome = "17:00"},
            new {Sigla = "17:30" ,Nome = "17:30"},
            new {Sigla = "18:00" ,Nome = "18:00"}
        };

        // GET: AgendarConsulta
        public ActionResult Index()
        {
            List<Descricao_Especialidade> EspecialidadeList = db.Descricao_Especialidade.ToList();
            ViewBag.EspecialidadeList = new SelectList(EspecialidadeList, "Codigo_Especialidade", "Nome");
            ViewBag.Horario = new SelectList(horario, "Sigla", "Nome");
            if (!ModelState.IsValid)
            {
                ViewBag.Pessoa = new SelectList(db.Pessoa, "Codigo_Pessoa", "Nome");
                ViewBag.EspecialidadeList = new SelectList(EspecialidadeList, "Codigo_Especialidade", "Nome");
                ViewBag.Horario = new SelectList(horario, "Sigla", "Nome");
                return View();
            }
            ViewBag.Pessoa = new SelectList(db.Pessoa, "Codigo_Pessoa", "Nome");
            return View();
        }

        public JsonResult GetMedicoList(int codigoEspecialidade)
        {
            db.Configuration.ProxyCreationEnabled = false;

            var pessoas = new List<MedicoDto>();
            foreach (var medico in db.Medico.Where(x => x.Codigo_Especialidade == codigoEspecialidade))
            {
                var pessoa = db.Pessoa.Where(x => x.Codigo_Pessoa == medico.Codigo_Pessoa).FirstOrDefault();
                pessoas.Add(new MedicoDto
                {
                    Id = medico.Codigo_Medico,
                    Nome = pessoa.Nome
                });
            }
            return Json(pessoas, JsonRequestBehavior.AllowGet);
        }

        public ActionResult agendar(ProjetoBenner.Models.Agendado agendamento)
        {
            List<Descricao_Especialidade> EspecialidadeList = db.Descricao_Especialidade.ToList();
            ViewBag.MensagemErro = db.Agendado.Any(a => a.Data_Consulta == agendamento.Data_Consulta && a.Hora_Consulta == agendamento.Hora_Consulta && a.Codigo_Medico == agendamento.Codigo_Medico);
            if (!ModelState.IsValid || ViewBag.MensagemErro)
            {
                ViewBag.EspecialidadeList = new SelectList(EspecialidadeList, "Codigo_Especialidade", "Nome");
                ViewBag.Pessoa = new SelectList(db.Pessoa, "Codigo_Pessoa", "Nome");
                ViewBag.Horario = new SelectList(horario, "Sigla", "Nome");
                return View("Index", agendamento);
            }

           
            //ViewBag.Pessoa = new SelectList(db.Pessoa, "Codigo_Pessoa", "Nome");
            agendamento.Codigo_Pessoa = (int)Session["Codigo_Pessoa"];
            agendamento.Consulta_Confirmada = false;
            db.Agendado.Add(agendamento);
            db.SaveChanges();
            return View("Sucesso");

        }

        public ActionResult Sucesso()
        {
            return View();
        }

        

    }

}