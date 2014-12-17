using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TeamProjectHse272_2.Data
{
    public class Context : DbContext, IContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public Context()
            : base("MyConnection")
        {
            Database.SetInitializer<Context>(new CreateDatabaseIfNotExists<Context>());
        }
    }
}
