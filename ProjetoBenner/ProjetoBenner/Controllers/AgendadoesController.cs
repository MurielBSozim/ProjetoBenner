using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoBenner.Models;

namespace ProjetoBenner.Controllers
{
    public class AgendadoesController : Controller
    {
        private AgendaONEntities3 db = new AgendaONEntities3();

        // GET: Agendadoes
        public ActionResult Index()
        {
            var agendado = db.Agendado.Include(a => a.Agenda).Include(a => a.Pessoa).Include(a => a.Medico).Include(a => a.Local).Include(a => a.Pre_Consulta);
            return View(agendado.ToList());
        }

        // GET: Agendadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agendado agendado = db.Agendado.Find(id);
            if (agendado == null)
            {
                return HttpNotFound();
            }
            return View(agendado);
        }

        // GET: Agendadoes/Create
        public ActionResult Create()
        {
            ViewBag.Codigo_Agenda = new SelectList(db.Agenda, "Codigo_Agenda", "Codigo_Agenda");
            ViewBag.Codigo_Pessoa = new SelectList(db.Pessoa, "Codigo_Pessoa", "Nome");
            ViewBag.Codigo_Medico = new SelectList(db.Medico, "Codigo_Medico", "Codigo_Medico");
            ViewBag.Codigo_Local = new SelectList(db.Local, "Codigo_Local", "Nome");
            ViewBag.Codigo_Pre_Consulta = new SelectList(db.Pre_Consulta, "Codigo_Pre_Consulta", "Sintomas");
            return View();
        }

        // POST: Agendadoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo_Agendado,Codigo_Agenda,Codigo_Pessoa,Codigo_Medico,Codigo_Local,Codigo_Pre_Consulta,Data_Consulta,Hora_Consulta,Consulta_Confirmada")] Agendado agendado)
        {
            if (ModelState.IsValid)
            {
                db.Agendado.Add(agendado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Codigo_Agenda = new SelectList(db.Agenda, "Codigo_Agenda", "Codigo_Agenda", agendado.Codigo_Agenda);
            ViewBag.Codigo_Pessoa = new SelectList(db.Pessoa, "Codigo_Pessoa", "Nome", agendado.Codigo_Pessoa);
            ViewBag.Codigo_Medico = new SelectList(db.Medico, "Codigo_Medico", "Codigo_Medico", agendado.Codigo_Medico);
            ViewBag.Codigo_Local = new SelectList(db.Local, "Codigo_Local", "Nome", agendado.Codigo_Local);
            ViewBag.Codigo_Pre_Consulta = new SelectList(db.Pre_Consulta, "Codigo_Pre_Consulta", "Sintomas", agendado.Codigo_Pre_Consulta);
            return View(agendado);
        }

        // GET: Agendadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agendado agendado = db.Agendado.Find(id);
            if (agendado == null)
            {
                return HttpNotFound();
            }
            ViewBag.Codigo_Agenda = new SelectList(db.Agenda, "Codigo_Agenda", "Codigo_Agenda", agendado.Codigo_Agenda);
            ViewBag.Codigo_Pessoa = new SelectList(db.Pessoa, "Codigo_Pessoa", "Nome", agendado.Codigo_Pessoa);
            ViewBag.Codigo_Medico = new SelectList(db.Medico, "Codigo_Medico", "Codigo_Medico", agendado.Codigo_Medico);
            ViewBag.Codigo_Local = new SelectList(db.Local, "Codigo_Local", "Nome", agendado.Codigo_Local);
            ViewBag.Codigo_Pre_Consulta = new SelectList(db.Pre_Consulta, "Codigo_Pre_Consulta", "Sintomas", agendado.Codigo_Pre_Consulta);
            return View(agendado);
        }

        // POST: Agendadoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo_Agendado,Codigo_Agenda,Codigo_Pessoa,Codigo_Medico,Codigo_Local,Codigo_Pre_Consulta,Data_Consulta,Hora_Consulta,Consulta_Confirmada")] Agendado agendado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agendado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Codigo_Agenda = new SelectList(db.Agenda, "Codigo_Agenda", "Codigo_Agenda", agendado.Codigo_Agenda);
            ViewBag.Codigo_Pessoa = new SelectList(db.Pessoa, "Codigo_Pessoa", "Nome", agendado.Codigo_Pessoa);
            ViewBag.Codigo_Medico = new SelectList(db.Medico, "Codigo_Medico", "Codigo_Medico", agendado.Codigo_Medico);
            ViewBag.Codigo_Local = new SelectList(db.Local, "Codigo_Local", "Nome", agendado.Codigo_Local);
            ViewBag.Codigo_Pre_Consulta = new SelectList(db.Pre_Consulta, "Codigo_Pre_Consulta", "Sintomas", agendado.Codigo_Pre_Consulta);
            return View(agendado);
        }

        // GET: Agendadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agendado agendado = db.Agendado.Find(id);
            if (agendado == null)
            {
                return HttpNotFound();
            }
            return View(agendado);
        }

        // POST: Agendadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agendado agendado = db.Agendado.Find(id);
            db.Agendado.Remove(agendado);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
