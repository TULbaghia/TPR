using Data;
using System.Collections.Generic;

namespace Service
{
    public interface IDataRepository
    {
        IEnumerable<Product> GetProducts();
        void AddProduct(Product item);
        void UpdateItem(Product item);
        void DeleteProduct(Product item);
        Product GetProduct(int id);

    }
}
