using System.Collections.Generic;

namespace PresenterModel
{
    public interface IModel
    {
        IEnumerable<ProductModel> GetProducts();
        ProductModel GetProduct(int id);
        void DeleteProduct(ProductModel product);
        void AddProduct(ProductModel product);
        void UpdateProduct(ProductModel product);
    }
}
