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
    public class MedicosController : Controller
    {
        private AgendaONEntities3 db = new AgendaONEntities3();

        // GET: Medicos
        public ActionResult Index()
        {
            var medico = db.Medico.Include(m => m.Descricao_Especialidade).Include(m => m.Estado).Include(m => m.Pessoa);
            return View(medico.ToList());
        }

        // GET: Medicos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medico.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // GET: Medicos/Create


        // GET: Medicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medico.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            ViewBag.Codigo_Especialidade = new SelectList(db.Descricao_Especialidade, "Codigo_Especialidade", "Nome", medico.Codigo_Especialidade);
            ViewBag.Codigo_Estado = new SelectList(db.Estado, "Codigo_Estado", "UF", medico.Codigo_Estado);
            ViewBag.Codigo_Pessoa = new SelectList(db.Pessoa, "Codigo_Pessoa", "Nome", medico.Codigo_Pessoa);
            return View(medico);
        }

        // POST: Medicos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo_Medico,Codigo_Pessoa,Codigo_Estado,Data_Admissao,CRM,Codigo_Especialidade")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Codigo_Especialidade = new SelectList(db.Descricao_Especialidade, "Codigo_Especialidade", "Nome", medico.Codigo_Especialidade);
            ViewBag.Codigo_Estado = new SelectList(db.Estado, "Codigo_Estado", "UF", medico.Codigo_Estado);
            ViewBag.Codigo_Pessoa = new SelectList(db.Pessoa, "Codigo_Pessoa", "Nome", medico.Codigo_Pessoa);
            return View(medico);
        }

        // GET: Medicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medico.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // POST: Medicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medico medico = db.Medico.Find(id);
            db.Medico.Remove(medico);
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
