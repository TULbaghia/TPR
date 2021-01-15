using Data;
using System.Collections.Generic;

namespace Service
{
    public interface IDataRepository
    {
        IEnumerable<ProductModelService> GetProducts();
        void AddProduct(ProductModelService item);
        void UpdateProduct(ProductModelService item);
        void DeleteProduct(ProductModelService item);
        ProductModelService GetProduct(int id);

    }
}
