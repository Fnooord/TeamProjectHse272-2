using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProjectHse272_2.Data
{
    class Cart
    {
        public List<Product> ProductsInCart { get; set; }
        public decimal TotalPrice { get; set; }
        public int TotalQuantity {get; set; }
        public decimal GetTotalPrice (List<Product> list)
        {
            decimal total = 0;
            foreach (Product p in list)
            {
                total += (p.Price * p.InCart);
            }
            return total;
        }
    }
}
