using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProjectHse272_2
{
    class Product
    {
        public int Id { get; set; }
        public virtual Category category { get; set; }
        public string Producer { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
    }
}
