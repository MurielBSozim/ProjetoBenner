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
    public class PacienteController : Controller
    {
        private AgendaONEntities db = new AgendaONEntities();

        // GET: Paciente
        public ActionResult Index()
        {
            var pessoa = db.Pessoa.Include(p => p.Acesso).Include(p => p.Endereco);
            return View(pessoa.ToList());
        }

        // GET: Paciente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoa.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        
        // GET: Paciente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoa.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            ViewBag.Codigo_Acesso = new SelectList(db.Acesso, "Codigo_Acesso", "Email", pessoa.Codigo_Acesso);
            ViewBag.Codigo_Endereco = new SelectList(db.Endereco, "Codigo_Endereco", "Endereco1", pessoa.Codigo_Endereco);
            return View(pessoa);
        }

        // POST: Paciente/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo_Pessoa,Codigo_Acesso,Codigo_Endereco,Nome,CPF,RG,Data_Nascimento,Estado_Civil,Telefone,Celular,Email,Sexo,Password")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                Endereco endereco = db.Endereco.Find(pessoa.Codigo_Endereco);
                Acesso acesso = db.Acesso.Find(pessoa.Codigo_Acesso);
                pessoa.Acesso = acesso;                                 
                pessoa.Acesso.Email = pessoa.Email;
                db.Entry(acesso).State = EntityState.Modified;
                db.Entry(pessoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit", "Enderecoes", new { id = (endereco.Codigo_Endereco )});
            }
            ViewBag.Codigo_Acesso = new SelectList(db.Acesso, "Codigo_Acesso", "Email", pessoa.Codigo_Acesso);
            ViewBag.Codigo_Endereco = new SelectList(db.Endereco, "Codigo_Endereco", "Endereco1", pessoa.Codigo_Endereco);
            return View(pessoa);
        }

        // GET: Paciente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoa.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Paciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pessoa pessoa = db.Pessoa.Find(id);
            Acesso acesso = db.Acesso.Find(pessoa.Codigo_Acesso);
            Endereco endereco = db.Endereco.Find(pessoa.Codigo_Endereco);
            db.Pessoa.Remove(pessoa);
            db.Acesso.Remove(acesso);
            db.Endereco.Remove(endereco);
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
