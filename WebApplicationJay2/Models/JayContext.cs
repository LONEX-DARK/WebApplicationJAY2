using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationJay2.Models;

namespace WebApplicationJAY.Models
{
    public class JayContext : DbContext
    {
        public JayContext() : base("JayContext")
        {

        }
        public DbSet<Utilisateur> Utilisateurs { get;set; }
        public DbSet<Share> Shares { get;set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
