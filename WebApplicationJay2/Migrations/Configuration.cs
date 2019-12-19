namespace WebApplicationJay2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplicationJAY.Models.JayContext>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "WebApplicationJAY.Models.JayContext";
        }
    }
}
