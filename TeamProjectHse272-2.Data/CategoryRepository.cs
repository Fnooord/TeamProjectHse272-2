using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProjectHse272_2.Data
{
    class CategoryRepository: ICategoryRepository
    {
        private Context _context = new Context();

        public IQueryable<Category> GetCategories()
        {
            return _context.Categories;
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
