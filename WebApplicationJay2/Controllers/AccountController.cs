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
                FormsAuthentication.SetAuthCookie(utilisateurTrouve.Id.ToString(), true);
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
            if (dal.IdentifiantExisteDeja(utilisateur.Identifiant) == true)
            {
                //Creer un viewData contenant l'erreur
                ViewData["Erreur"] = "Identifiant existe deja";
                return View(utilisateur);
            }

            if (dal.PrenomExisteDeja(utilisateur.Prenom) == true)
            {
                //Creer un viewData contenant l'erreur
                ViewData["Erreur"] = "prenom existe deja";
                return View(utilisateur);
            }

            dal.CreeUtilisateur(utilisateur);
            return View();
        }
    }
}