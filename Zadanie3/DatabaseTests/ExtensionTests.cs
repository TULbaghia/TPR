using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Zadanie3;

namespace DatabaseTests
{
    [TestClass]
    public class ExtensionTests
    {
        [TestMethod]
        public void GetProductWithoutCategory_QueryTest()
        {
            using (AdventureWorksDataContext dc = new AdventureWorksDataContext())
            {
                List<Product> products = dc.Products.ToList();
                List<Product> result = products.GetProductWithoutCategory_Query();

                Assert.AreEqual(209, result.Count);
            }
        }
        [TestMethod]
        public void GetProductWithoutCategory_MethodTest()
        {
            using (AdventureWorksDataContext dc = new AdventureWorksDataContext())
            {
                List<Product> products = dc.Products.ToList();
                List<Product> result = products.GetProductWithoutCategory_Method();

                Assert.AreEqual(209, result.Count);
            }
        }
        [TestMethod]
        public void GetProductWithoutCategory_MethodToQueryTest()
        {
            using (AdventureWorksDataContext dc = new AdventureWorksDataContext())
            {
                List<Product> products = dc.Products.ToList();
                List<Product> resultMethod = products.GetProductWithoutCategory_Method();
                List<Product> resultQuery = products.GetProductWithoutCategory_Query();

                Assert.AreEqual(resultMethod.Count, resultQuery.Count);
            }
        }



        [TestMethod]
        public void GetPaginatedProduct_QueryTest()
        {
            using (AdventureWorksDataContext dc = new AdventureWorksDataContext())
            {
                List<Product> products = dc.Products.ToList();
                List<Product> resultPage1 = products.GetPaginatedProduct_Query(1, 5);
                List<Product> resultPage2 = products.GetPaginatedProduct_Query(2, 5);
                List<Product> resultPage3 = products.GetPaginatedProduct_Query(3, 5);
                List<Product> resultSum = products.GetPaginatedProduct_Query(1, 15);

                Assert.AreEqual(5, resultPage1.Count);
                Assert.AreEqual(5, resultPage2.Count);
                Assert.AreEqual(5, resultPage3.Count);

                CollectionAssert.Equals(resultSum, resultPage1.Concat(resultPage2).Concat(resultPage3));
            }
        }
        [TestMethod]
        public void GetPaginatedProduct_MethodTest()
        {
            using (AdventureWorksDataContext dc = new AdventureWorksDataContext())
            {
                List<Product> products = dc.Products.ToList();
                List<Product> resultPage1 = products.GetPaginatedProduct_Method(1, 5);
                List<Product> resultPage2 = products.GetPaginatedProduct_Method(2, 5);
                List<Product> resultPage3 = products.GetPaginatedProduct_Method(3, 5);
                List<Product> resultSum = products.GetPaginatedProduct_Method(1, 15);

                Assert.AreEqual(5, resultPage1.Count);
                Assert.AreEqual(5, resultPage2.Count);
                Assert.AreEqual(5, resultPage3.Count);

                CollectionAssert.Equals(resultSum, resultPage1.Concat(resultPage2).Concat(resultPage3));

            }
        }



        [TestMethod]
        public void GetProductVendorString_QueryTest()
        {
            using (AdventureWorksDataContext dc = new AdventureWorksDataContext())
            {
                List<Product> products = dc.Products.ToList();
                List<ProductVendor> productVendors = dc.ProductVendors.ToList();
                string str = products.GetProductVendorString_Query(productVendors);

                Assert.IsTrue(str.Contains("Thin-Jam Hex Nut 11 - WestAmerica Bicycle Co."));
                Assert.IsTrue(str.Contains("Thin-Jam Hex Nut 14 - Advanced Bicycles"));
                Assert.IsTrue(str.Contains("Hex Nut 2 - Norstan Bike Hut"));
                Assert.IsTrue(str.Contains("Decal 2 - SUPERSALES INC."));
                Assert.IsTrue(str.Contains("Crown Race - Business Equipment Center"));
            }
        }
        [TestMethod]
        public void GetProductVendorString_MethodTest()
        {
            using (AdventureWorksDataContext dc = new AdventureWorksDataContext())
            {
                List<Product> products = dc.Products.ToList();
                List<ProductVendor> productVendors = dc.ProductVendors.ToList();
                string str = products.GetProductVendorString_Method(productVendors);

                Assert.IsTrue(str.Contains("Thin-Jam Hex Nut 11 - WestAmerica Bicycle Co."));
                Assert.IsTrue(str.Contains("Thin-Jam Hex Nut 14 - Advanced Bicycles"));
                Assert.IsTrue(str.Contains("Hex Nut 2 - Norstan Bike Hut"));
                Assert.IsTrue(str.Contains("Decal 2 - SUPERSALES INC."));
                Assert.IsTrue(str.Contains("Crown Race - Business Equipment Center"));
            }
        }
    }
}
