using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Zadanie3;

namespace DatabaseTests
{
    [TestClass]
    public class MyProductTests
    {
        [TestMethod]
        public void GetProductsByName_Test()
        {
            List<MyProduct> query = MyProductQueries.GetProductsByName("Decal");
            Assert.AreEqual(2, query.Count);
        }

        [TestMethod]
        public void GetProductsWithNRecentReviews()
        {
            List<MyProduct> query = MyProductQueries.GetProductsWithNRecentReviews(2);
            Assert.AreEqual(1, query.Count);
        }

        [TestMethod]
        public void GetNProductsFromCategory()
        {
            List<MyProduct> query = MyProductQueries.GetNProductsFromCategory("Bikes", 10);
            Assert.AreEqual(10, query.Count);
            foreach (MyProduct p in query)
            {
                Assert.IsTrue(p.Name.Contains("Mountain"));
            }
        }
    }
}
