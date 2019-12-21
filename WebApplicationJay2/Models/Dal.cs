using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Security;
using WebApplicationJay2.Models;

namespace WebApplicationJAY.Models
{
    public class Dal : IDisposable
    {
        private JayContext context;

        public Dal()
        {
            context = new JayContext();
        }
        public void CreeUtilisateur(Utilisateur utilisateur)
        {
            context.Utilisateurs.Add(utilisateur);
            context.SaveChanges();
        }

        public bool IdentifiantExisteDeja(string identifiant)
        {
            bool existe = context.Utilisateurs.Any(u => u.Identifiant == identifiant);
            return existe;
        }

        public bool PrenomExisteDeja(string prenom)
        {
            bool existe = context.Utilisateurs.Any(u => u.Prenom == prenom);
            return existe;
        }

        public Utilisateur ObtenirUtilisateur(string Identifiant)
        {
            Utilisateur utilisateurTrouve = context.Utilisateurs.FirstOrDefault(u => u.Id.ToString() == Identifiant);

            return utilisateurTrouve;
        }

        public Utilisateur ObtenirUtilisateur(string Identifiant, string motDePasse)
        {
            Utilisateur utilisateurTrouve = context.Utilisateurs.FirstOrDefault(u => u.Identifiant == Identifiant && u.MotDePasse == motDePasse);
            
            return utilisateurTrouve;
        }

        public void CreeShare(Share share)
        {
            Utilisateur utilisateur = context.Utilisateurs.FirstOrDefault(u => u.Id.ToString() == share.Idutilisateur);

            share.PrenomUtilisateur = utilisateur.Prenom;

            context.Shares.Add(share);
            context.SaveChanges();
        }

        public List<Share> ObtenirLesShares(string utilisateurId)
        {
            List<Share> resultat = context.Shares.Where(s => s.Idutilisateur == utilisateurId).ToList();
            return resultat;
        } 
        public List<Share> ObtenirTousLesShares()
        {
            List<Share> resultat = context.Shares.ToList();
            return resultat;
        }

        public void Dispose()
        {
            //
        }
    }
}
