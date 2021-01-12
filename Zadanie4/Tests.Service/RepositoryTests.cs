using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System.Linq;

namespace Tests.Service
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void AddProductTest()
        {
            IDataContext<Product> dataContext = new TestDataContext();
            IDataRepository dataRepository = new DataRepository(dataContext);

            Product product = new Product();

            Assert.AreEqual(0, dataContext.GetItems().Count());

            dataRepository.AddProduct(product);

            Assert.AreEqual(1, dataContext.GetItems().Count());

            Assert.AreSame(product, dataContext.GetItems().First());
        }

        [TestMethod]
        public void GetProductTest()
        {
            IDataContext<Product> dataContext = new TestDataContext();
            IDataRepository dataRepository = new DataRepository(dataContext);

            Product product = new Product();

            Assert.AreEqual(0, dataRepository.GetProducts().Count());

            dataRepository.AddProduct(product);

            Assert.AreEqual(1, dataRepository.GetProducts().Count());

            Assert.AreSame(product, dataRepository.GetProduct(product.ProductID));
        }

        [TestMethod]
        public void GetProductsTest()
        {
            IDataContext<Product> dataContext = new TestDataContext();
            IDataRepository dataRepository = new DataRepository(dataContext);

            Product product = new Product();

            Assert.AreEqual(0, dataRepository.GetProducts().Count());

            dataContext.AddItem(product);

            Assert.AreEqual(1, dataRepository.GetProducts().Count());

            Assert.IsTrue(CollectionAssert.Equals(dataContext.GetItems(), dataRepository.GetProducts()));
        }

        [TestMethod]
        public void DeleteProductTest()
        {
            IDataContext<Product> dataContext = new TestDataContext();
            IDataRepository dataRepository = new DataRepository(dataContext);

            Product product = new Product();
            dataRepository.AddProduct(product);
            Assert.AreEqual(1, dataRepository.GetProducts().Count());

            Product delete = new Product { ProductID = product.ProductID };

            dataRepository.DeleteProduct(delete);

            Assert.AreEqual(0, dataRepository.GetProducts().Count());
        }

        [TestMethod]
        public void UpdateProductTest()
        {
            IDataContext<Product> dataContext = new TestDataContext();
            IDataRepository dataRepository = new DataRepository(dataContext);

            Product product = new Product {
                Name = "Witaj"
            };
            dataRepository.AddProduct(product);
            Assert.AreEqual(1, dataRepository.GetProducts().Count());

            Assert.AreEqual("Witaj", dataRepository.GetProduct(product.ProductID).Name);

            Product update = new Product { 
                ProductID = product.ProductID,
                Name = "Test",
                Weight = 2
            };

            dataRepository.UpdateProduct(update);

            Assert.AreEqual("Test", dataRepository.GetProduct(product.ProductID).Name);
            Assert.AreEqual(2, dataRepository.GetProduct(product.ProductID).Weight);
        }
    }
}
