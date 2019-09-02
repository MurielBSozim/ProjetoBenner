using ProjetoBenner.dto;
using ProjetoBenner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBenner.Controllers
{
    public class AgendarConsultaSController : Controller
    {
        public AgendaONEntities3 db = new AgendaONEntities3();
        // GET: AgendarConsultaS
        public ActionResult Index()
        {
            List<Descricao_Especialidade> EspecialidadeList = db.Descricao_Especialidade.ToList();
            ViewBag.EspecialidadeList = new SelectList(EspecialidadeList, "Codigo_Especialidade", "Nome");
            if (!ModelState.IsValid)
            {
                ViewBag.Pessoa = new SelectList(db.Pessoa, "Codigo_Pessoa", "CPF");
                ViewBag.EspecialidadeList = new SelectList(EspecialidadeList, "Codigo_Especialidade", "Nome");
                return View();
            }
            ViewBag.Pessoa = new SelectList(db.Pessoa, "Codigo_Pessoa", "CPF");
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
                ViewBag.Pessoa = new SelectList(db.Pessoa, "Codigo_Pessoa", "CPF");
                return View("Index", agendamento);
            }


            ViewBag.Pessoa = new SelectList(db.Pessoa, "Codigo_Pessoa", "CPF");
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