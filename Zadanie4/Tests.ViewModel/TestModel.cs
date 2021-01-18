using PresenterModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Tests.ViewModel
{
    public class TestModel : IModel
    {
        private List<ProductModel> Products { get; set; }

        public TestModel()
        {
            Products = new List<ProductModel>();
        }

        public IEnumerable<ProductModel> GetProducts()
        {
            return Products.Select(x =>
            {
                ProductModel pm = new ProductModel();
                foreach (PropertyInfo property in x.GetType().GetProperties())
                {
                    property.SetValue(pm, property.GetValue(x));
                }
                return pm;
            });
        }

        public ProductModel GetProduct(int id)
        {
            ProductModel getProduct = Products.Single(x => x.ProductID == id);
            ProductModel pm = new ProductModel();
            foreach (PropertyInfo property in getProduct.GetType().GetProperties())
            {
                property.SetValue(pm, property.GetValue(getProduct));
            }
            return pm;
        }

        public void DeleteProduct(ProductModel item)
        {
            if (item.ProductID < 0)
            {
                throw new InvalidOperationException();
            }
            Products.RemoveAll(x => x.ProductID == item.ProductID);
        }

        public void AddProduct(ProductModel item)
        {
            if (item.ProductID < 0)
            {
                throw new InvalidOperationException();
            }
            item.ProductID = Products.Count + 1;
            Products.Add(item);
        }

        public void UpdateProduct(ProductModel item)
        {
            if (item.ProductID < 0)
            {
                throw new InvalidOperationException();
            }
            ProductModel product = GetProduct(item.ProductID);
            foreach (PropertyInfo property in product.GetType().GetProperties())
            {
                property.SetValue(product, property.GetValue(product));
            }
        }
    }
}
