using ProjetoBenner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.Drawing;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ProjetoBenner.Controllers
{
    public class LoginController : Controller
    {
        
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            
            Session.Clear();
            Session.Abandon();
            Response.ClearHeaders();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Autherize(ProjetoBenner.Models.Acesso acesso)
        {
            using (AgendaONEntities3 db = new AgendaONEntities3())
            {
                var acessoDetails = db.Acesso.Where(x => x.Email == acesso.Email && x.Password == acesso.Password).FirstOrDefault();
                if (acessoDetails == null)
                {
                    acesso.LoginErrorMessage = "E-mail ou senha incorreta";
                    return View("Index", acesso);
                }
                else
                {
                    Session["Codigo_Acesso"] = acessoDetails.Codigo_Acesso;
                    Session["Email"] = acessoDetails.Email;
                    Session["Tipo"] = acessoDetails.Tipo;
                    var pessoa = db.Pessoa.Where(x => x.Codigo_Acesso == acessoDetails.Codigo_Acesso).FirstOrDefault();
                    
                   
                    if (Session["Tipo"].ToString() == "ADM")
                    {
                        return RedirectToAction("ADM", "Dashboard");
                    }
                    if (Session["Tipo"].ToString() == "Paciente")
                    {
                        Session["Codigo_Pessoa"] = pessoa.Codigo_Pessoa;
                        Session["Nome"] = pessoa.Nome;
                        return RedirectToAction("Paciente", "Dashboard");
                    }
                    if (Session["Tipo"].ToString() == "Secretaria" || Session["Tipo"].ToString() == "Medico")
                    {
                        Session["Codigo_Pessoa"] = pessoa.Codigo_Pessoa;
                        Session["Nome"] = pessoa.Nome;
                        return RedirectToAction("Funcionario", "Dashboard");
                    }
                    else
                    {
                        return View("Index", acesso);
                    }
                }
            }
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Recover()
        {
            
            return RedirectToAction("Sucesso");
               
        }

       

    }
}