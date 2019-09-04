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
    public class Pre_ConsultaController : Controller
    {
        private AgendaONEntities3 db = new AgendaONEntities3();

        // GET: Pre_Consulta
        public ActionResult Index()
        {
            return View(db.Pre_Consulta.ToList());
        }

        // GET: Pre_Consulta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pre_Consulta pre_Consulta = db.Pre_Consulta.Find(id);
            if (pre_Consulta == null)
            {
                return HttpNotFound();
            }
            return View(pre_Consulta);
        }

        // GET: Pre_Consulta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pre_Consulta/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo_Pre_Consulta,Sintomas,Remedios_Tomando,Diagnostico_Anterior,Observacao")] Pre_Consulta pre_Consulta)
        {
            if (ModelState.IsValid)
            {
                db.Pre_Consulta.Add(pre_Consulta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pre_Consulta);
        }

        // GET: Pre_Consulta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pre_Consulta pre_Consulta = db.Pre_Consulta.Find(id);
            if (pre_Consulta == null)
            {
                return HttpNotFound();
            }
            return View(pre_Consulta);
        }

        // POST: Pre_Consulta/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo_Pre_Consulta,Sintomas,Remedios_Tomando,Diagnostico_Anterior,Observacao")] Pre_Consulta pre_Consulta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pre_Consulta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pre_Consulta);
        }

        // GET: Pre_Consulta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pre_Consulta pre_Consulta = db.Pre_Consulta.Find(id);
            if (pre_Consulta == null)
            {
                return HttpNotFound();
            }
            return View(pre_Consulta);
        }

        // POST: Pre_Consulta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pre_Consulta pre_Consulta = db.Pre_Consulta.Find(id);
            db.Pre_Consulta.Remove(pre_Consulta);
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
