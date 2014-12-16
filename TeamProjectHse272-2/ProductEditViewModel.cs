using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProjectHse272_2.Data;

namespace TeamProjectHse272_2
{
    public class ProductEditViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public string Title { get; set; }
    }
}
