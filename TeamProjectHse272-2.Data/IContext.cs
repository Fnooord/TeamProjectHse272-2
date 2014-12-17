using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProjectHse272_2.Data
{
    public interface IContext
    {
        DbSet<Product> Products { get; }
        DbSet<Category> Categories { get; }
        int SaveChanges();
    }
}
