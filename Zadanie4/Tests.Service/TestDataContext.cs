using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Tests.Service
{
    class TestDataContext : IDataContext<Product>
    {
        private List<Product> Products { get; set; }

        public TestDataContext()
        {
            Products = new List<Product>();
        }

        public void AddItem(Product item)
        {
            item.ProductID = Products.Count + 1;
            item.ModifiedDate = DateTime.Now;
            item.rowguid = Guid.NewGuid();
            Products.Add(item);
        }

        public void DeleteItem(Product item)
        {
            Product product = GetItem(item.ProductID);
            Products.Remove(product);
        }

        public Product GetItem(int id)
        {
            return Products.Single(x => x.ProductID == id);
        }

        public IEnumerable<Product> GetItems()
        {
            return Products;
        }

        public void UpdateItem(Product item)
        {
            Product product = GetItem(item.ProductID);
            foreach (PropertyInfo property in product.GetType().GetProperties())
            {
                property.SetValue(product, property.GetValue(item));
            }
        }
    }
}
