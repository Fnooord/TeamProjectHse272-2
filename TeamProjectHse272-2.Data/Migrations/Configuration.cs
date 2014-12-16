namespace TeamProjectHse272_2.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TeamProjectHse272_2.Data.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TeamProjectHse272_2.Data.Context context)
        {
            if (!context.Categories.Any(c => c.Name == "Smartphone"))
            {
                context.Categories.Add(
                    new Category { Name = "Smartphone" });
                context.SaveChanges();
            }

            if (!context.Products.Any(p => p.Producer=="Sony" && p.Model=="Xperia"))
            {
                context.Products.Add(new Product
                {
                    Category = context.Categories.First(c => c.Name == "Smartphone"),
                    Producer = "Sony",
                    Model = "Xperia",
                    Price = 100,
                    Quantity = 4,
                });
                context.SaveChanges();
            }
        }
    }
}
