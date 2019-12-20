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
        private Dal dal;

        public HomeController()
        {
            dal = new Dal();
        }

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
            ViewBag.Message = "Mon espace";

            return View();
        }

        [Authorize]
        public ActionResult Actu()
        {
            List<Share> mesShares = dal.ObtenirLesShares(HttpContext.User.Identity.Name);
            return View(mesShares);
        }
        
        [HttpPost]
        public ActionResult Actu(string text)
        {
            Share share = new Share { Texte = text, Idutilisateur = HttpContext.User.Identity.Name };
            List<Share> mesShares =  dal.CreeShare(share);
            return View(mesShares);
        }
    }
}