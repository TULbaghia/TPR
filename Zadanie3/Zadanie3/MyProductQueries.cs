using System.Collections.Generic;
using System.Linq;

namespace Zadanie3
{
    public class MyProductQueries
    {
        public static List<MyProduct> GetProductsByName(string namePart)
        {
            using (AdventureWorksDataContext dc = new AdventureWorksDataContext())
            {
                MyProductDataContext dataContext = new MyProductDataContext(dc);

                IEnumerable<MyProduct> query = from p in dataContext.MyProducts
                                               where p.Name.Contains(namePart)
                                               select p;

                return query.ToList();
            }
        }
        public static List<MyProduct> GetProductsWithNRecentReviews(int howManyReviews)
        {
            using (AdventureWorksDataContext dc = new AdventureWorksDataContext())
            {
                MyProductDataContext dataContext = new MyProductDataContext(dc);

                IEnumerable<MyProduct> query = from p in dataContext.MyProducts
                                               where p.ProductReviews.Count == howManyReviews
                                               select p;

                return query.ToList();
            }
        }
        public static List<MyProduct> GetNProductsFromCategory(string categoryName, int n)
        {
            using (AdventureWorksDataContext dc = new AdventureWorksDataContext())
            {
                MyProductDataContext dataContext = new MyProductDataContext(dc);

                IEnumerable<MyProduct> query = from p in dataContext.MyProducts
                                               where p.ProductSubcategory != null &&
                                               p.ProductSubcategory.ProductCategory != null &&
                                               p.ProductSubcategory.ProductCategory.Name == categoryName
                                               orderby p.Name
                                               select p;

                return query.Take(n).ToList();
            }
        }
    }
}
