using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationJAY.Models;
using WebApplicationJay2.Models;

namespace WebApplicationJay2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult Actu()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Actu(string text)
        {
            Share share = new Share { Texte = text, Idutilisateur = HttpContext.User.Identity.Name };
            Dal dal = new Dal();
            dal.CreeShare(share);
            return View();
        }
    }
}