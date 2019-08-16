using ProjetoBenner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
                    return RedirectToAction("Index", "Dashboard");
                }
            }
        }

        public ActionResult ForgotPassword(Acesso acesso)
        {

            return View();
        }

        public ActionResult LogOut()
        {
            int userId = (int)Session["Codigo_Acesso"];
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

    }
}