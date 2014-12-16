using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProjectHse272_2.Data
{
    class ProductRepository: IProductRepository
    {
        private Context _context = new Context();

        public IQueryable<Product> GetProducts()
        {
            return _context.Products;
        }

        private bool _disposed;

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
            _disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}
