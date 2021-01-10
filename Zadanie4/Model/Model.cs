using Data;
using Service;
using System.Collections.Generic;

namespace PresenterModel
{
    public class Model
    {
        private IDataRepository DataRepository { get; set; }

        public Model()
        {
            DataRepository = new DataRepository(new DataContext());
        }

        public IEnumerable<Product> GetProducts()
        {
            return DataRepository.GetProducts();
        }

        public Product GetProduct(int id)
        {
            return DataRepository.GetProduct(id);
        }
    }
}
