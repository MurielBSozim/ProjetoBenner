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
    public class LocalsController : Controller
    {
        private AgendaONEntities3 db = new AgendaONEntities3();

        // GET: Locals
        public ActionResult Index()
        {
            var local = db.Local.Include(l => l.Endereco);
            return View(local.ToList());
        }

        // GET: Locals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Local local = db.Local.Find(id);
            if (local == null)
            {
                return HttpNotFound();
            }
            return View(local);
        }

        // GET: Locals/Create
        public ActionResult Create()
        {
            ViewBag.Codigo_Endereco = new SelectList(db.Endereco, "Codigo_Endereco", "Endereco1");
            return View();
        }

        
        // GET: Locals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Local local = db.Local.Find(id);
            if (local == null)
            {
                return HttpNotFound();
            }
            ViewBag.Codigo_Endereco = new SelectList(db.Endereco, "Codigo_Endereco", "Endereco1", local.Codigo_Endereco);
            return View(local);
        }

        // POST: Locals/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo_Local,Codigo_Endereco,Nome,Telefone")] Local local)
        {
            if (ModelState.IsValid)
            {
                db.Entry(local).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Codigo_Endereco = new SelectList(db.Endereco, "Codigo_Endereco", "Endereco1", local.Codigo_Endereco);
            return View(local);
        }

        // GET: Locals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Local local = db.Local.Find(id);
            if (local == null)
            {
                return HttpNotFound();
            }
            return View(local);
        }

        // POST: Locals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            Local local = db.Local.Find(id);
            ViewBag.MensagemErro = db.Horario_Medico.Any(a => a.Codigo_Local == id);
            if (ViewBag.MensagemErro)
            {
                
                return RedirectToAction("Delete", "Locals", new { Id = id});
            }
            db.Local.Remove(local);
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
