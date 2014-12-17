using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TeamProjectHse272_2.Data
{
    [Serializable]
    public class Cart
    {
        public List<CartItem> Items { get; private set; }
        
        public decimal TotalPrice
        {
            get
            {
                decimal total = 0;
                foreach (CartItem ci in Items)
                {
                    total += (ci.Product.Price * ci.Quantity);
                }
                return total;
            }
        }

        public Cart()
        {
            Items = new List<CartItem>();
        }
    }
}
