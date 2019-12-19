using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationJAY.Models;

namespace WebApplicationJAY.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Connecter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Connecter(string identifiant, string motDePasse)
        {
            Dal dal = new Dal();
            dal.ObtenirUtilisateur(identifiant, motDePasse);
            return View();
        }


        [HttpGet]
        public IActionResult Creer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Creer(Utilisateur utilisateur)
        {
            Dal dal = new Dal();
            dal.CreeUtilisateur(utilisateur);
            return View();
        }
    }
}