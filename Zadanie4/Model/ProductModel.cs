using Service;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PresenterModel
{
    public class ProductModel : INotifyPropertyChanged
    {
        public ProductModelService ProductModelService { get; private set; }

        public ProductModel(ProductModelService x)
        {
            ProductModelService = x;
        }

        public ProductModel()
        {
            ProductModelService = new ProductModelService();
        }

        public ProductModelService CreateProduct()
        {
            return ProductModelService;
        }

        #region PropertyChangedEventHandler
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region Product properties
        public int ProductID
        {
            get => ProductModelService.ProductID;
            set
            {
                ProductModelService.ProductID = value;
                NotifyPropertyChanged();
            }
        }
        public string Name
        {
            get => ProductModelService.Name;
            set
            {
                ProductModelService.Name = value;
                NotifyPropertyChanged();
            }
        }
        public string ProductNumber
        {
            get => ProductModelService.ProductNumber;
            set
            {
                ProductModelService.ProductNumber = value;
                NotifyPropertyChanged();
            }
        }
        public bool MakeFlag
        {
            get => ProductModelService.MakeFlag;
            set
            {
                ProductModelService.MakeFlag = value;
                NotifyPropertyChanged();
            }
        }
        public bool FinishedGoodsFlag
        {
            get => ProductModelService.FinishedGoodsFlag;
            set
            {
                ProductModelService.FinishedGoodsFlag = value;
                NotifyPropertyChanged();
            }
        }
        public short SafetyStockLevel
        {
            get => ProductModelService.SafetyStockLevel;
            set
            {
                ProductModelService.SafetyStockLevel = value;
                NotifyPropertyChanged();
            }
        }
        public short ReorderPoint
        {
            get => ProductModelService.ReorderPoint;
            set
            {
                ProductModelService.ReorderPoint = value;
                NotifyPropertyChanged();
            }
        }
        public decimal StandardCost
        {
            get => ProductModelService.StandardCost;
            set
            {
                ProductModelService.StandardCost = value;
                NotifyPropertyChanged();
            }
        }
        public decimal ListPrice
        {
            get => ProductModelService.ListPrice;
            set
            {
                ProductModelService.ListPrice = value;
                NotifyPropertyChanged();
            }
        }
        public int DaysToManufacture
        {
            get => ProductModelService.DaysToManufacture;
            set
            {
                ProductModelService.DaysToManufacture = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime SellStartDate
        {
            get => ProductModelService.SellStartDate;
            set
            {
                ProductModelService.SellStartDate = value;
                NotifyPropertyChanged();
            }
        }
        #endregion
    }
}
