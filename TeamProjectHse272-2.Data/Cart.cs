using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProjectHse272_2.Data
{
    class Cart
    {
        public List<CartItem> ProductsInCart { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal GetTotalPrice (List<CartItem> list)
        {
            decimal total = 0;
            foreach (CartItem ci in list)
            {
                total += (ci.Item.Price * ci.Quantity);
            }
            return total;
        }
    }
}
