namespace E_Commerence.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<E_Commerence.DataAccessLayer.EntityFramwork.DataBaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "E-Commerence.EntityFramework.DataBaseContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(E_Commerence.DataAccessLayer.EntityFramwork.DataBaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
