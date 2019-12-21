using System.Collections.Generic;
using System.Web.Mvc;
using WebApplicationJAY.Models;
using WebApplicationJay2.Models;
using WebApplicationJay2.ViewModels;

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
            List<Share> mesShares = dal.ObtenirLesShares(HttpContext.User.Identity.Name);
            Utilisateur utilisateur = dal.ObtenirUtilisateur(HttpContext.User.Identity.Name);
            ContactViewModel vm = new ContactViewModel { Utilisateur = utilisateur, MesShares = mesShares };
            return View(vm);
        }

        [Authorize]
        public ActionResult Actu()
        {
            List<Share> TousLesShares = dal.ObtenirTousLesShares();
            return View(TousLesShares);
        }

        [HttpPost]
        public ActionResult Actu(string text)
        {
            Share share = new Share { Texte = text, Idutilisateur = HttpContext.User.Identity.Name };
            dal.CreeShare(share);
            return RedirectToAction("Contact", "Home");
        }
    }
}