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

            ProductModelService product = new ProductModelService();

            Assert.AreEqual(0, dataContext.GetItems().Count());

            dataRepository.AddProduct(product);

            Assert.AreEqual(1, dataContext.GetItems().Count());

            Assert.AreEqual(1, dataContext.GetItems().First().ProductID);
        }

        [TestMethod]
        public void GetProductTest()
        {
            IDataContext<Product> dataContext = new TestDataContext();
            IDataRepository dataRepository = new DataRepository(dataContext);

            ProductModelService product = new ProductModelService();

            Assert.AreEqual(0, dataRepository.GetProducts().Count());

            dataRepository.AddProduct(product);

            Assert.AreEqual(1, dataRepository.GetProducts().Count());

            Assert.AreEqual(1, dataRepository.GetProduct(1).ProductID);
        }

        [TestMethod]
        public void GetProductsTest()
        {
            IDataContext<Product> dataContext = new TestDataContext();
            IDataRepository dataRepository = new DataRepository(dataContext);

            ProductModelService product = new ProductModelService();

            Assert.AreEqual(0, dataRepository.GetProducts().Count());

            dataContext.AddItem(product.CreateProduct());

            Assert.AreEqual(1, dataRepository.GetProducts().Count());
        }

        [TestMethod]
        public void DeleteProductTest()
        {
            IDataContext<Product> dataContext = new TestDataContext();
            IDataRepository dataRepository = new DataRepository(dataContext);

            ProductModelService product = new ProductModelService();
            dataRepository.AddProduct(product);
            Assert.AreEqual(1, dataRepository.GetProducts().Count());

            ProductModelService delete = new ProductModelService(new Product { ProductID = 1 });

            dataRepository.DeleteProduct(delete);

            Assert.AreEqual(0, dataRepository.GetProducts().Count());
        }

        [TestMethod]
        public void UpdateProductTest()
        {
            IDataContext<Product> dataContext = new TestDataContext();
            IDataRepository dataRepository = new DataRepository(dataContext);

            ProductModelService product = new ProductModelService(new Product
            {
                Name = "Witaj"
            });
            dataRepository.AddProduct(product);
            Assert.AreEqual(1, dataRepository.GetProducts().Count());

            Assert.AreEqual("Witaj", dataRepository.GetProduct(1).Name);

            ProductModelService update = new ProductModelService(new Product
            {
                ProductID = 1,
                Name = "Test",
                MakeFlag = true
            });

            dataRepository.UpdateProduct(update);

            Assert.AreEqual("Test", dataRepository.GetProduct(1).Name);
            Assert.AreEqual(true, dataRepository.GetProduct(1).MakeFlag);
        }
    }
}
