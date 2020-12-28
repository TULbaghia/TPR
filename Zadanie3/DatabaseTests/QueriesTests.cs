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
            Assert.AreEqual(query.Count, 2);
        }
        [TestMethod]
        public void GetProductsByVendorNameTest()
        {
            List<Product> query = Queries.GetProductsByVendorName("Advanced Bicycles");
            Assert.AreEqual(query.Count, 16);
        }
        [TestMethod]
        public void GetProductNamesByVendorNameTest()
        {
            List<string> query = Queries.GetProductNamesByVendorName("Advanced Bicycles");
            Assert.AreEqual(query.Count, 16);
        }
        [TestMethod]
        public void GetProductVendorByProductName()
        {
            string query = Queries.GetProductVendorByProductName("Adjustable Race");
            Assert.AreEqual(query, "Litware, Inc.");
        }
        [TestMethod]
        public void GetProductsWithNRecentReviews()
        {
            List<Product> query = Queries.GetProductsWithNRecentReviews(2);
            Assert.AreEqual(query.Count, 1);
        }
    }
}
