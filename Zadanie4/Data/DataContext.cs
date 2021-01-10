using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataContext : IDataContext<Product>
    {
        public bool AddItem(Product item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItem(Product item)
        {
            throw new NotImplementedException();
        }

        public Product GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetItems()
        {
            throw new NotImplementedException();
        }

        public bool UpdateItem(Product item)
        {
            throw new NotImplementedException();
        }
    }
}
