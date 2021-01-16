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
            try
            {
                item.ModifiedDate = DateTime.Now;
                item.rowguid = Guid.NewGuid();
                AdventureWorksDataContext.Products.InsertOnSubmit(item);
                AdventureWorksDataContext.SubmitChanges();
            } catch (Exception e)
            {
                AdventureWorksDataContext.Products.DeleteOnSubmit(item);
                throw e;
            }

        }
        
        public void DeleteItem(Product item)
        {
            Product product = GetItem(item.ProductID);
            try 
            {
                if (product != null)
                {
                    AdventureWorksDataContext.Products.DeleteOnSubmit(product);
                    AdventureWorksDataContext.SubmitChanges(ConflictMode.ContinueOnConflict);
                }
            }
            catch (Exception e)
            {
                AdventureWorksDataContext.Products.InsertOnSubmit(product);
                throw e;
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
            try
            {
                Product product = GetItem(item.ProductID);
                product.ProductID = item.ProductID;
                product.Name = item.Name;
                product.ProductNumber = item.ProductNumber;
                product.MakeFlag = item.MakeFlag;
                product.FinishedGoodsFlag = item.FinishedGoodsFlag;
                product.SafetyStockLevel = item.SafetyStockLevel;
                product.ReorderPoint = item.ReorderPoint;
                product.StandardCost = item.StandardCost;
                product.ListPrice = item.ListPrice;
                product.DaysToManufacture = item.DaysToManufacture;
                product.SellStartDate = item.SellStartDate;

                AdventureWorksDataContext.SubmitChanges();
            } catch (Exception e)
            {
                AdventureWorksDataContext.GetChangeSet().Updates.Clear();
                throw e;
            }

        }
    }
}
