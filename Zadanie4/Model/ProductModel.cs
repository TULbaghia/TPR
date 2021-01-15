using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace PresenterModel
{
    public class ProductModel : INotifyPropertyChanged
    {
        public ProductModelService ProductModelNew { get; private set; }

        public ProductModel(ProductModelService x)
        {
            ProductModelNew = x;
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
            get { return ProductModelNew.ProductID; }
            set
            {
                ProductModelNew.ProductID = value;
                NotifyPropertyChanged();
            }
        }
        public string Name
        {
            get { return ProductModelNew.Name; }
            set
            {
                ProductModelNew.Name = value;
                NotifyPropertyChanged();
            }
        }
        public string ProductNumber
        {
            get { return ProductModelNew.ProductNumber; }
            set
            {
                ProductModelNew.ProductNumber = value;
                NotifyPropertyChanged();
            }
        }
        public string Color
        {
            get { return ProductModelNew.Color; }
            set
            {
                ProductModelNew.Color = value;
                NotifyPropertyChanged();
            }
        }
        public decimal StandardCost
        {
            get { return ProductModelNew.StandardCost; }
            set
            {
                ProductModelNew.StandardCost = value;
                NotifyPropertyChanged();
            }
        }
        public decimal ListPrice
        {
            get { return ProductModelNew.ListPrice; }
            set
            {
                ProductModelNew.ListPrice = value;
                NotifyPropertyChanged();
            }
        }
        public decimal? Weight
        {
            get { return ProductModelNew.Weight; }
            set
            {
                ProductModelNew.Weight = value;
                NotifyPropertyChanged();
            }
        }
        public string Size
        {
            get { return ProductModelNew.Size; }
            set
            {
                ProductModelNew.Size = value;
                NotifyPropertyChanged();
            }
        }
        public string ProductLine
        {
            get { return ProductModelNew.ProductLine; }
            set
            {
                ProductModelNew.ProductLine = value;
                NotifyPropertyChanged();
            }
        }
        public string Class
        {
            get { return ProductModelNew.Class; }
            set
            {
                ProductModelNew.Class = value;
                NotifyPropertyChanged();
            }
        }
        public string Style
        {
            get { return ProductModelNew.Style; }
            set
            {
                ProductModelNew.Style = value;
                NotifyPropertyChanged("Weight");
            }
        }
        public int? ProductSubcategoryID
        {
            get { return ProductModelNew.ProductSubcategoryID; }
            set
            {
                ProductModelNew.ProductSubcategoryID = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime SellStartDate
        {
            get { return ProductModelNew.SellStartDate; }
            set
            {
                ProductModelNew.SellStartDate = value;
                NotifyPropertyChanged("SellStartDate");
            }
        }
        public DateTime? SellEndDate
        {
            get { return ProductModelNew.SellEndDate; }
            set
            {
                ProductModelNew.SellEndDate = value;
                NotifyPropertyChanged("SellStartDate");
            }
        }
        #endregion
    }
}
