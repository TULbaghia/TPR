using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Reflection;

namespace Data
{
    public class DataContext : IDataContext<Product>
    {
        public AdventureWorksDataContext AdventureWorksDataContext { get; private set; }

        public DataContext()
        {
            AdventureWorksDataContext = new AdventureWorksDataContext();
        }

        public void AddItem(Product item)
        {
            item.ModifiedDate = DateTime.Now;
            item.rowguid = Guid.NewGuid();
            AdventureWorksDataContext.Products.InsertOnSubmit(item);
            AdventureWorksDataContext.SubmitChanges();
        }

        public void DeleteItem(Product item)
        {
            Product product = GetItem(item.ProductID);
            if (product != null)
            {
                AdventureWorksDataContext.Products.DeleteOnSubmit(product);
                AdventureWorksDataContext.SubmitChanges(ConflictMode.ContinueOnConflict);
            }
        }

        public Product GetItem(int id)
        {
            return GetItems().Single(x => x.ProductID == id);
        }

        public IEnumerable<Product> GetItems()
        {
            return AdventureWorksDataContext.Products;
        }

        public void UpdateItem(Product item)
        {
            Product product = GetItem(item.ProductID);
            foreach (PropertyInfo property in product.GetType().GetProperties())
            {
                property.SetValue(product, property.GetValue(item));
            }
            AdventureWorksDataContext.SubmitChanges();
        }
    }
}
