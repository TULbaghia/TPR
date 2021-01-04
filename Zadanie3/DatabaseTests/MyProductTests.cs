using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Zadanie3;

namespace DatabaseTests
{
    [TestClass]
    public class MyProductTests
    {
        [TestMethod]
        public void GetProductsByNameTest()
        {
            string text = "Decal";
            List<MyProduct> query = MyProductQueries.GetProductsByName(text);

            Assert.AreEqual(2, query.Count);
            foreach (MyProduct p in query)
            {
                Assert.IsTrue(p.Name.Contains(text));
            }
        }

        [TestMethod]
        public void GetProductsWithNRecentReviewsTest()
        {
            List<MyProduct> query = MyProductQueries.GetProductsWithNRecentReviews(2);

            Assert.AreEqual(1, query.Count);
            Assert.AreEqual(937, query[0].ProductID);
        }

        [TestMethod]
        public void GetNProductsFromCategoryTest()
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
