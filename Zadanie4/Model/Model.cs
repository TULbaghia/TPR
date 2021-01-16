using Service;
using System.Collections.Generic;
using System.Linq;

namespace PresenterModel
{
    public class Model
    {
        private IDataRepository DataRepository { get; set; }

        public Model()
        {
            DataRepository = new DataRepository();
        }

        public IEnumerable<ProductModel> GetProducts()
        {
            return DataRepository.GetProducts().Select(x => new ProductModel(x));
        }

        public ProductModel GetProduct(int id)
        {
            return new ProductModel(DataRepository.GetProduct(id));
        }
        public void DeleteProduct(ProductModel product)
        {
            DataRepository.DeleteProduct(product.CreateProduct());
        }
        public void AddProduct(ProductModel product)
        {
            DataRepository.AddProduct(product.CreateProduct());
        }
        public void UpdateProduct(ProductModel product)
        {
            DataRepository.UpdateProduct(product.CreateProduct());
        }
    }
}
