using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zadanie3
{
    public static class Extension
    {
        public static List<Product> GetProductWithoutCategory_Query(this List<Product> items)
        {
            IEnumerable<Product> query = from p in items
                                         where p.ProductSubcategory == null
                                         select p;

            return query.ToList();
        }
        public static List<Product> GetProductWithoutCategory_Method(this List<Product> items)
        {
            IEnumerable<Product> query = items.Where(x => x.ProductSubcategory == null);

            return query.ToList();
        }



        public static List<Product> GetPaginatedProduct_Query(this List<Product> items, int pageNo, int size)
        {
            IEnumerable<Product> query = (from p in items
                                          select p)
                                         .Skip((pageNo - 1) * size)
                                         .Take(size);
            return query.ToList();
        }

        public static List<Product> GetPaginatedProduct_Method(this List<Product> items, int pageNo, int size)
        {
            IEnumerable<Product> query = items
                                         .Skip((pageNo - 1) * size)
                                         .Take(size);
            return query.ToList();
        }



        public static string GetProductVendorString_Query(this List<Product> products, List<ProductVendor> productVendors)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var query = from product in products
                        join pVendor in productVendors on product.ProductID equals pVendor.ProductID
                        select new { productName = product.Name, vendorName = pVendor.Vendor.Name };

            foreach (var item in query)
            {
                stringBuilder.Append(item.productName).Append('-').AppendLine(item.vendorName);
            }

            return stringBuilder.ToString();
        }

        public static string GetProductVendorString_Method(this List<Product> products, List<ProductVendor> productVendors)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var query = products.Join(productVendors,
                                    product => product.ProductID,
                                    pVendor => pVendor.ProductID,
                                    (product, pVendor) => new { productName = product.Name, vendorName = pVendor.Vendor.Name });

            foreach (var item in query)
            {
                stringBuilder.Append(item.productName).Append('-').AppendLine(item.vendorName);
            }

            return stringBuilder.ToString();
        }
    }
}
