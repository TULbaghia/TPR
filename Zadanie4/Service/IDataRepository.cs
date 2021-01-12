using Data;
using System.Collections.Generic;

namespace Service
{
    public interface IDataRepository
    {
        IEnumerable<Product> GetProducts();
        void AddProduct(Product item);
        void UpdateProduct(Product item);
        void DeleteProduct(Product item);
        Product GetProduct(int id);

    }
}
