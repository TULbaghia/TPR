using Data;
using System;

namespace Service
{
    public class ProductModelService
    {
        #region Product model private fields
        private int productId;
        private string name;
        private string productNumber;
        private string color;
        private decimal standardCost;
        private decimal listPrice;
        private string size;
        private decimal? weight;
        private string productLine;
        private string productClass;
        private string style;
        private int? productSubcategoryId;
        private DateTime sellStartDate;
        private DateTime? sellEndDate;
        #endregion
        public ProductModelService() 
        {
        }

        public ProductModelService(Product x)
        {
            ProductID = x.ProductID;
            Name = x.Name;
            ProductNumber = x.ProductNumber;
            Color = x.Color;
            StandardCost = x.StandardCost;
            ListPrice = x.ListPrice;
            Size = x.Size;
            Weight = x.Weight;
            ProductLine = x.ProductLine;
            Class = x.Class;
            Style = x.Style;
            ProductSubcategoryID = x.ProductSubcategoryID;
            SellStartDate = x.SellStartDate;
            SellEndDate = x.SellEndDate;
        }

        public Product CreateProduct()
        {
            return new Product {
                ProductID = ProductID,
                Name = Name,
                ProductNumber = ProductNumber,
                Color = Color,
                StandardCost = StandardCost,
                ListPrice = ListPrice,
                Size = Size,
                Weight = Weight,
                ProductLine = ProductLine,
                Class = Class,
                Style = Style,
                ProductSubcategoryID = ProductSubcategoryID,
                SellStartDate = SellStartDate,
                SellEndDate = SellEndDate,
            };
        }
        

        #region Product properties
        public int ProductID
        {
            get { return productId; }
            set
            {
                productId = value;
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }
        public string ProductNumber
        {
            get { return productNumber; }
            set
            {
                productNumber = value;
            }
        }
        public string Color
        {
            get { return color; }
            set
            {
                color = value;
            }
        }
        public decimal StandardCost
        {
            get { return standardCost; }
            set
            {
                standardCost = value;
            }
        }
        public decimal ListPrice
        {
            get { return listPrice; }
            set
            {
                listPrice = value;
            }
        }
        public decimal? Weight
        {
            get { return weight; }
            set
            {
                weight = value;
            }
        }
        public string Size
        {
            get { return size; }
            set
            {
                size = value;
            }
        }
        public string ProductLine
        {
            get { return productLine; }
            set
            {
                productLine = value;
            }
        }
        public string Class
        {
            get { return productClass; }
            set
            {
                productClass = value;
            }
        }
        public string Style
        {
            get { return style; }
            set
            {
                style = value;
            }
        }
        public int? ProductSubcategoryID
        {
            get { return productSubcategoryId; }
            set
            {
                productSubcategoryId = value;
            }
        }

        public DateTime SellStartDate
        {
            get { return sellStartDate; }
            set
            {
                sellStartDate = value;
            }
        }
        public DateTime? SellEndDate
        {
            get { return sellEndDate; }
            set
            {
                sellEndDate = value;
            }
        }
        #endregion
    }
}
