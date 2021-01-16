using Data;
using System;

namespace Service
{
    public class ProductModelService
    {
        #region Product model private fields
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public bool MakeFlag { get; set; }
        public bool FinishedGoodsFlag { get; set; }
        public short SafetyStockLevel { get; set; }
        public short ReorderPoint { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public int DaysToManufacture { get; set; }
        public DateTime SellStartDate { get; set; }
        #endregion
        public ProductModelService() 
        {
            SellStartDate = DateTime.Now;
        }

        public ProductModelService(Product x)
        {
            ProductID = x.ProductID;
            Name = x.Name;
            ProductNumber = x.ProductNumber;
            MakeFlag = x.MakeFlag;
            FinishedGoodsFlag = x.FinishedGoodsFlag;
            SafetyStockLevel = x.SafetyStockLevel;
            ReorderPoint = x.ReorderPoint;
            StandardCost = x.StandardCost;
            ListPrice = x.ListPrice;
            DaysToManufacture = x.DaysToManufacture;
            SellStartDate = x.SellStartDate;
        }

        public Product CreateProduct()
        {
            return new Product
            {
                ProductID = ProductID,
                Name = Name,
                ProductNumber = ProductNumber,
                MakeFlag = MakeFlag,
                FinishedGoodsFlag = FinishedGoodsFlag,
                SafetyStockLevel = SafetyStockLevel,
                ReorderPoint = ReorderPoint,
                StandardCost = StandardCost,
                ListPrice = ListPrice,
                DaysToManufacture = DaysToManufacture,
                SellStartDate = SellStartDate
        };
        }
    }
}
