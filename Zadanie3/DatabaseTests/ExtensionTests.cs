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
        public void GetPaginatedProduct_QueryTest()
        {
            using (AdventureWorksDataContext dc = new AdventureWorksDataContext())
            {
                List<Product> products = dc.Products.ToList();
                List<Product> result = products.GetPaginatedProduct_Query(1, 25);

                Assert.AreEqual(25, result.Count);
            }
        }
        [TestMethod]
        public void GetPaginatedProduct_MethodTest()
        {
            using (AdventureWorksDataContext dc = new AdventureWorksDataContext())
            {
                List<Product> products = dc.Products.ToList();
                List<Product> result = products.GetPaginatedProduct_Method(1, 25);

                Assert.AreEqual(25, result.Count);
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

                Assert.IsTrue(str.Contains("Thin-Jam Hex Nut 11-WestAmerica Bicycle Co."));
                Assert.IsTrue(str.Contains("Thin-Jam Hex Nut 14-Advanced Bicycles"));
                Assert.IsTrue(str.Contains("Hex Nut 2-Norstan Bike Hut"));
                Assert.IsTrue(str.Contains("Decal 2-SUPERSALES INC."));
                Assert.IsTrue(str.Contains("Crown Race-Business Equipment Center"));
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

                Assert.IsTrue(str.Contains("Thin-Jam Hex Nut 11-WestAmerica Bicycle Co."));
                Assert.IsTrue(str.Contains("Thin-Jam Hex Nut 14-Advanced Bicycles"));
                Assert.IsTrue(str.Contains("Hex Nut 2-Norstan Bike Hut"));
                Assert.IsTrue(str.Contains("Decal 2-SUPERSALES INC."));
                Assert.IsTrue(str.Contains("Crown Race-Business Equipment Center"));
            }
        }
    }
}
