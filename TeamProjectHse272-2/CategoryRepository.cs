using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProjectHse272_2
{
    class CategoryRepository: ICategoryRepository
    {
        private Context _context = new Context();

        public IQueryable<Category> GetCategories()
        {
            return _context.Categories;
        }
    }
}
