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
    public class EnderecoesController : Controller
    {
        private AgendaONEntities3 db = new AgendaONEntities3();

        // GET: Enderecoes
        public ActionResult Index()
        {
            var endereco = db.Endereco.Include(e => e.Cidade);
            return View(endereco.ToList());
        }

        // GET: Enderecoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.Endereco.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Codigo_Cidade = new SelectList(db.Cidade, "Codigo_Cidade", "Cidade1", endereco.Codigo_Cidade);
            return View(endereco);
        }

        // POST: Enderecoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo_Endereco,Codigo_Cidade,Endereco1,Numero,Complemento,Bairro")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                Pessoa pessoa = db.Pessoa.Find(endereco.Codigo_Endereco);
                Cidade cidade = db.Cidade.Find(endereco.Codigo_Cidade);
                db.Entry(endereco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit", "Cidades", new { id = (endereco.Codigo_Cidade )});
            }
            ViewBag.Codigo_Cidade = new SelectList(db.Cidade, "Codigo_Cidade", "Cidade1", endereco.Codigo_Cidade);
            return View(endereco);
        }

        // GET: Enderecoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.Endereco.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // POST: Enderecoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Endereco endereco = db.Endereco.Find(id);
            //Cidade cidade = db.Cidade.Find(endereco.Codigo_Cidade);
            //db.Cidade.Remove(cidade);
            db.Endereco.Remove(endereco);
            db.SaveChanges();
            return RedirectToAction("Index", "Paciente");
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
