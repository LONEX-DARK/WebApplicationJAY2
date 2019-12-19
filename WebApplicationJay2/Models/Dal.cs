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

        public Utilisateur ObtenirUtilisateur(string Identifiant, string motDePasse)
        {
            Utilisateur utilisateurTrouve = context.Utilisateurs.FirstOrDefault(u => u.Identifiant == Identifiant && u.MotDePasse == motDePasse);
            
            return utilisateurTrouve;
        }

        public void CreeShare(Share share)
        {
            context.Shares.Add(share);
            context.SaveChanges();
        }

        public void Dispose()
        {
            //
        }
    }
}
