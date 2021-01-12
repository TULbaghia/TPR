using Data;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            Task.Run(() =>
            {
                DataContext.AddItem(item);
            }).Wait();
        }

        public void DeleteProduct(Product item)
        {
            Task.Run(() =>
            {
                DataContext.DeleteItem(item);
            }).Wait();
        }

        public Product GetProduct(int id)
        {
            return DataContext.GetItem(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return DataContext.GetItems();
        }

        public void UpdateProduct(Product item)
        {
            Task.Run(() =>
            {
                DataContext.UpdateItem(item);
            }).Wait();
        }
    }
}
