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
    public class SecretariasController : Controller
    {
        private AgendaONEntities3 db = new AgendaONEntities3();

        // GET: Secretarias
        public ActionResult Index()
        {
            var secretaria = db.Secretaria.Include(s => s.Pessoa);
            return View(secretaria.ToList());
        }

        // GET: Secretarias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secretaria secretaria = db.Secretaria.Find(id);
            if (secretaria == null)
            {
                return HttpNotFound();
            }
            return View(secretaria);
        }

        // GET: Secretarias/Create
        
        // GET: Secretarias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secretaria secretaria = db.Secretaria.Find(id);
            if (secretaria == null)
            {
                return HttpNotFound();
            }
            ViewBag.Codigo_Pessoa = new SelectList(db.Pessoa, "Codigo_Pessoa", "Nome", secretaria.Codigo_Pessoa);
            return View(secretaria);
        }

        // POST: Secretarias/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo_Secretaria,Codigo_Pessoa,Data_Admissao,Hora_Entrada,Hora_Saida")] Secretaria secretaria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(secretaria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Codigo_Pessoa = new SelectList(db.Pessoa, "Codigo_Pessoa", "Nome", secretaria.Codigo_Pessoa);
            return View(secretaria);
        }

        // GET: Secretarias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secretaria secretaria = db.Secretaria.Find(id);
            if (secretaria == null)
            {
                return HttpNotFound();
            }
            return View(secretaria);
        }

        // POST: Secretarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Secretaria secretaria = db.Secretaria.Find(id);
            db.Secretaria.Remove(secretaria);
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
