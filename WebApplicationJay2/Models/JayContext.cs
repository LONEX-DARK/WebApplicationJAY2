using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationJAY.Models
{
    public class JayContext : DbContext
    {
        public JayContext() : base("JayContext")
        {

        }
        public DbSet<Utilisateur> Utilisateurs { get;set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
