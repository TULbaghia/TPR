using Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class DataRepository : IDataRepository
    {
        private IDataContext<Product> DataContext { get; set; }

        public DataRepository()
        {
            DataContext = new DataContext();
        }

        public DataRepository(IDataContext<Product> dataContext)
        {
            DataContext = dataContext;
        }

        public void AddProduct(ProductModelService item)
        {
            DataContext.AddItem(item.CreateProduct());
        }

        public void DeleteProduct(ProductModelService item)
        {
            DataContext.DeleteItem(item.CreateProduct());
        }

        public ProductModelService GetProduct(int id)
        {
            return new ProductModelService(DataContext.GetItem(id));
        }

        public IEnumerable<ProductModelService> GetProducts()
        {
            return DataContext.GetItems().Select(x => new ProductModelService(x));
        }

        public void UpdateProduct(ProductModelService item)
        {
            DataContext.UpdateItem(item.CreateProduct());
        }
    }
}
