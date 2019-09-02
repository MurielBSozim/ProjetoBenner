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
    public class Descricao_EspecialidadeController : Controller
    {
        private AgendaONEntities3 db = new AgendaONEntities3();

        // GET: Descricao_Especialidade
        public ActionResult Index()
        {
            return View(db.Descricao_Especialidade.ToList());
        }

        // GET: Descricao_Especialidade/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Descricao_Especialidade descricao_Especialidade = db.Descricao_Especialidade.Find(id);
            if (descricao_Especialidade == null)
            {
                return HttpNotFound();
            }
            return View(descricao_Especialidade);
        }

        // GET: Descricao_Especialidade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Descricao_Especialidade/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo_Especialidade,Nome")] Descricao_Especialidade descricao_Especialidade)
        {
            if (ModelState.IsValid)
            {
                db.Descricao_Especialidade.Add(descricao_Especialidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(descricao_Especialidade);
        }

        // GET: Descricao_Especialidade/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Descricao_Especialidade descricao_Especialidade = db.Descricao_Especialidade.Find(id);
            if (descricao_Especialidade == null)
            {
                return HttpNotFound();
            }
            return View(descricao_Especialidade);
        }

        // POST: Descricao_Especialidade/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo_Especialidade,Nome")] Descricao_Especialidade descricao_Especialidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(descricao_Especialidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(descricao_Especialidade);
        }

        // GET: Descricao_Especialidade/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Descricao_Especialidade descricao_Especialidade = db.Descricao_Especialidade.Find(id);
            if (descricao_Especialidade == null)
            {
                return HttpNotFound();
            }
            return View(descricao_Especialidade);
        }

        // POST: Descricao_Especialidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Descricao_Especialidade descricao_Especialidade = db.Descricao_Especialidade.Find(id);
            db.Descricao_Especialidade.Remove(descricao_Especialidade);
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
