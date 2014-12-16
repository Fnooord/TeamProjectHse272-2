using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProjectHse272_2
{
    class ProductRepository: IProductRepository
    {
        private Context _context = new Context();

        public IQueryable<Product> GetProducts()
        {
            return _context.Products;
        }
    }
}
