using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProjectHse272_2.Data
{
    interface IProductRepository
    {
        IQueryable<Product> GetProducts();
    }
}
