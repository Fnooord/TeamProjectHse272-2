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
            var categories =
                new[]
                {
                    new Category { Name = "Smartphone" },
                    new Category { Name = "TV"},
                    new Category { Name = "PC"}
                };
            foreach (var category in categories)
            {
                if (!context.Categories.Any(c => c.Name == category.Name))
                {
                    context.Categories.Add(category);
                    context.SaveChanges();
                }
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
