using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using WebApplicationJAY.Models;

namespace WebApplicationJAY.Controllers
{
    public class AccountController : Controller
    {
        private Dal dal;

        public AccountController()
        {
            dal = new Dal();
        }

        [HttpGet]
        public ActionResult Connecter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Connecter(string identifiant, string motDePasse)
        {
            Utilisateur utilisateurTrouve = dal.ObtenirUtilisateur(identifiant, motDePasse);
            if (utilisateurTrouve != null)
            {
                FormsAuthentication.SetAuthCookie(utilisateurTrouve.Identifiant, true);
                return RedirectToAction("Index", "Home");
            }

            else
            {
                ViewData["Erreur"] = "Identifiant ou Mot de passe invalide";
            }
            return View();
        }

        public ActionResult Deconnecter()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult Creer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Creer(Utilisateur utilisateur)
        {
            dal.CreeUtilisateur(utilisateur);
            return View();
        }
    }
}