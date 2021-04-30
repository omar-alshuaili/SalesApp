namespace csY2S2_cs_project.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<csY2S2_cs_project.classes.ProductsData>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "csY2S2_cs_project.classes.ProductsData";
        }

        protected override void Seed(csY2S2_cs_project.classes.ProductsData context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
