using System.Collections.Generic;
using System.Linq;

namespace Zadanie3
{
    public class MyProductDataContext
    {
        public List<MyProduct> MyProducts { get; private set; }
        public MyProductDataContext(AdventureWorksDataContext dataContext)
        {
            MyProducts = (from p in dataContext.Products
                          select new MyProduct(p)
                         ).ToList();
        }
    }
}
