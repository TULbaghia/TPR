using System.Collections.Generic;
using System.Linq;

namespace Zadanie3
{
    public class Queries
    {
        public static List<Product> GetProductsByName(string namePart)
        {
            using (AdventureWorksDataContext dc = new AdventureWorksDataContext())
            {
                IEnumerable<Product> query = from p in dc.Products
                     where p.Name.Contains(namePart)
                     select p;

                return query.ToList();
            }
        }
        public static List<Product> GetProductsByVendorName(string vendorName)
        {
            using (AdventureWorksDataContext dc = new AdventureWorksDataContext())
            {
                IEnumerable<Product> query = from p in dc.ProductVendors
                                       where p.Vendor.Name.Equals(vendorName)
                                       select p.Product;

                return query.ToList();
            }
        }
        public static List<string> GetProductNamesByVendorName(string vendorName)
        {
            using (AdventureWorksDataContext dc = new AdventureWorksDataContext())
            {
                IEnumerable<string> query = from p in dc.Products
                                             join pVendor in dc.ProductVendors on p.ProductID equals pVendor.ProductID
                                             where pVendor.Vendor.Name == vendorName
                                             select p.Name;

                return query.ToList();
            }
        }
        public static string GetProductVendorByProductName(string productName)
        {
            using (AdventureWorksDataContext dc = new AdventureWorksDataContext())
            {
                IEnumerable<string> query = from p in dc.Products
                                            join pVendor in dc.ProductVendors on p.ProductID equals pVendor.ProductID
                                            where p.Name == productName
                                            select pVendor.Vendor.Name;

                return query.First();
            }
        }
        public static List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            using (AdventureWorksDataContext dc = new AdventureWorksDataContext())
            {
                IEnumerable<Product> query = from p in dc.Products
                                             where p.ProductReviews.Count == howManyReviews
                                             select p;

                return query.ToList();
            }
        }
        public static List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            using (AdventureWorksDataContext dc = new AdventureWorksDataContext())
            {
                IEnumerable<Product> query = (from r in dc.ProductReviews
                                             orderby r.ReviewDate descending
                                             select r.Product
                                             ).Take(howManyProducts);

                return query.ToList();
            }
        }
        public static List<Product> GetNProductsFromCategory(string categoryName, int n)
        {
            using (AdventureWorksDataContext dc = new AdventureWorksDataContext())
            {
                IEnumerable<Product> query = (from p in dc.Products
                                              where p.ProductSubcategory.ProductCategory.Name == categoryName
                                              orderby p.Name
                                              select p
                                              ).Take(n);

                return query.ToList();
            }
        }
        public static int GetTotalStandardCostByCategory(ProductCategory category)
        {
            using (AdventureWorksDataContext dc = new AdventureWorksDataContext())
            {
                int sum = (int) (from p in dc.Products
                                 where p.ProductSubcategory.ProductCategory.Name == category.Name
                                 select p.StandardCost
                                 ).Sum();

                return sum;
            }
        }

    }
}
