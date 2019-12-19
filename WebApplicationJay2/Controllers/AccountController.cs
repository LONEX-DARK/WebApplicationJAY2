using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
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
            dal.ObtenirUtilisateur(identifiant, motDePasse);
            return View();
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