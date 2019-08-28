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

        [HttpPost]
        public ActionResult Autherize(ProjetoBenner.Models.Acesso acesso)
        {
            using (AgendaONEntities db = new AgendaONEntities())
            {
                var acessoDetails = db.Acesso.Where(x => x.Email == acesso.Email && x.Password == acesso.Password).FirstOrDefault();
                if (acessoDetails == null)
                {
                    acesso.LoginErrorMessage = "wrong user email or password";
                    return View("Index", acesso);
                }
                else
                {
                    Session["Codigo_Acesso"] = acessoDetails.Codigo_Acesso;
                    Session["Email"] = acessoDetails.Email;
                    Session["Tipo"] = acessoDetails.Tipo;
                    if (Session["Tipo"].ToString() == "ADM")
                    {
                        return RedirectToAction("ADM", "Dashboard");
                    }
                    if (Session["Tipo"].ToString() == "Paciente")
                    {
                        return RedirectToAction("Paciente", "Dashboard");
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

        public ActionResult LogOut()
        {
            int userId = (int)Session["Codigo_Acesso"];
            Session.Abandon();
            Session.Clear();
            Session.Remove(userId.ToString());
            return RedirectToAction("Index", "Home");
        }

    }
}