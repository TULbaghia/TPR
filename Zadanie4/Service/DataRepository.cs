using Data;
using System.Collections.Generic;

namespace Service
{
    public class DataRepository : IDataRepository
    {
        private IDataContext<Product> DataContext { get; set; }

        public DataRepository(IDataContext<Product> dataContext)
        {
            DataContext = dataContext;
        }

        public void AddProduct(Product item)
        {
            DataContext.AddItem(item);
        }

        public void DeleteProduct(Product item)
        {
            DataContext.DeleteItem(item);
        }

        public Product GetProduct(int id)
        {
            return DataContext.GetItem(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return DataContext.GetItems();
        }

        public void UpdateItem(Product item)
        {
            DataContext.UpdateItem(item);
        }
    }
}
