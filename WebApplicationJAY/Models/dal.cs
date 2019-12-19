using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationJAY.Models
{
    public class Dal
    {
        public void CreeUtilisateur(Utilisateur utilisateur)
        {
            JayContext context = new JayContext();
            context.Utilisateurs.Add(utilisateur);
            context.SaveChanges();

        }

        public Utilisateur ObtenirUtilisateur(string Identifiant, string motDePasse)
        {
            JayContext context = new JayContext();
            Utilisateur utilisateurTrouve = context.Utilisateurs.FirstOrDefault(u => u.Identifiant == Identifiant && u.MotDePasse == motDePasse);
            return utilisateurTrouve;
        }

    }
}
