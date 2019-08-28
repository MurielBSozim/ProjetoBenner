using ProjetoBenner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace ProjetoBenner.Controllers
{
    public class DashboardController : Controller
    {

        
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Paciente()
        {
            return View();
        }



        public ActionResult ADM()
        {
            return View();
        }
    }
}