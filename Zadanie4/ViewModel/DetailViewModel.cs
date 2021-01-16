using PresenterModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace PresenterViewModel
{
    public class DetailViewModel : INotifyPropertyChanged
    {
        private ProductModel selectedProduct { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public DetailViewModel()
        {
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ProductModel SelectedProduct
        {
            get
            {
                return this.selectedProduct;
            }

            set
            {
                if (value != this.selectedProduct)
                {
                    this.selectedProduct = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public void SetSelectedProduct(MainViewModel mvm)
        {
            SelectedProduct = mvm.EditProduct;
        }
    }
}
