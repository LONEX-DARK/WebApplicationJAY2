using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationJAY.Models
{
    public class JayContext : DbContext
    {
        public DbSet<Utilisateur> Utilisateurs { get;set; }
    }
}
