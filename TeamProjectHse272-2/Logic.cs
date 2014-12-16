using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProjectHse272_2
{
    class Logic
    {
        public static void DbInitialization ()
        {
            using (var db = new Context())
            {
                db.Categories.Add(new Category { Name = "Smartphone" });
                db.SaveChanges();
            }
        }
    }
}
