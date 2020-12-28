using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Zadanie3;

namespace DatabaseTests
{
    [TestClass]
    public class QueriesTests
    {
        [TestMethod]
        public void GetProductsByNameTest()
        {
            List<Product> query = Queries.GetProductsByName("Decal");
            Assert.AreEqual(2, query.Count);
        }

        [TestMethod]
        public void GetProductsByVendorNameTest()
        {
            List<Product> query = Queries.GetProductsByVendorName("Advanced Bicycles");
            Assert.AreEqual(16, query.Count);
        }

        [TestMethod]
        public void GetProductNamesByVendorNameTest()
        {
            List<string> query = Queries.GetProductNamesByVendorName("Advanced Bicycles");
            Assert.AreEqual(16, query.Count);
        }

        [TestMethod]
        public void GetProductVendorByProductName()
        {
            string query = Queries.GetProductVendorByProductName("Adjustable Race");
            Assert.AreEqual("Litware, Inc.", query);
        }

        [TestMethod]
        public void GetProductsWithNRecentReviews()
        {
            List<Product> query = Queries.GetProductsWithNRecentReviews(2);
            Assert.AreEqual(1, query.Count);
        }

        [TestMethod]
        public void GetNRecentlyReviewedProducts()
        {
            List<Product> query = Queries.GetNRecentlyReviewedProducts(3);
            Assert.AreEqual(3, query.Count);

            Assert.AreEqual(937, query[0].ProductID);
            Assert.AreEqual(798, query[1].ProductID);
            Assert.AreEqual(937, query[2].ProductID);
        }

        [TestMethod]
        public void GetNProductsFromCategory()
        {
            List<Product> query = Queries.GetNProductsFromCategory("Bikes", 10);
            Assert.AreEqual(10, query.Count);
            foreach (Product p in query)
            {
                Assert.IsTrue(p.Name.Contains("Mountain"));
            }
        }

        [TestMethod]
        public void GetTotalStandardCostByCategory()
        {
            ProductCategory pc = new ProductCategory();
            pc.Name = "Bikes";
            int sum = Queries.GetTotalStandardCostByCategory(pc);
            Assert.AreEqual(92092, sum);
        }
    }
}
