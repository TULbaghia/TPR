using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using PresenterModel;

namespace PresenterViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public Model Model { get; private set; }

        public MainViewModel()
        {
            Model = new Model();
            ShowDetail = new ViewModelCommand(_ShowDetail);
            DisplayTextCommand = new ViewModelCommand(() => MessageBoxShowDelegate("Tekst"));
            ShowAddControl = new ViewModelCommand(() => ShowAdd(true));
            ShowEditControl = new ViewModelCommand(() => ShowAdd(false));
            DeleteProduct = new ViewModelCommand(_DeleteProduct);

            EditProduct = new ProductModel();

            ShowAdd(true);
        }

        #region AddProduct, EditProduct Products
        public ObservableCollection<ProductModel> Products { get => new ObservableCollection<ProductModel>(Model.GetProducts()); }

        private ProductModel _EditProduct;
        public ProductModel EditProduct
        {
            get => _EditProduct;
            set
            {
                _EditProduct = value;
                ShowAdd(false);
                NotifyPropertyChanged();
            }
        }

        private ProductModel _AddProduct;
        public ProductModel AddProduct
        {
            get => _AddProduct;
            set
            {
                _AddProduct = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region HandleWindows
        public IWindow MainWindow { get; set; }

        public ViewModelCommand DisplayTextCommand { get; private set; }
        public Action<string> MessageBoxShowDelegate { get; set; }

        public Lazy<IDetail> DetailWindow { get; set; }
        public ViewModelCommand ShowDetail { get; set; }
        private void _ShowDetail()
        {
            if (EditProduct.ProductID == 0)
            {
                MessageBoxShowDelegate("Nie wybrano produktu");
            } else
            {
                DetailWindow.Value.ShowWindow(this);
            }
        }
        #endregion

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

        #region AddEditVisiblity
        public ViewModelCommand ShowAddControl { get; set; }
        public ViewModelCommand ShowEditControl { get; set; }

        private string _AddVisiblity;
        private string _EditVisibility;
        public string AddVisibility
        {
            get => _AddVisiblity;
            set
            {
                _AddVisiblity = value;
                NotifyPropertyChanged();
            }
        }
        public string EditVisibility { get => _EditVisibility; 
            set {
                _EditVisibility = value;
                NotifyPropertyChanged();
            } 
        }
        public void ShowAdd(bool showAdd)
        {
            if(showAdd)
            {
                if (AddVisibility == "Hidden" && EditVisibility == "Visible")
                {
                    AddProduct = new ProductModel();
                    EditProduct = new ProductModel();
                }
                AddVisibility = "Visible";
                EditVisibility = "Hidden";
            }
            else
            {
                AddVisibility = "Hidden";
                EditVisibility = "Visible";
            }
            int a = 5;
        }
        #endregion

        #region DeleteProduct
        public ViewModelCommand DeleteProduct { get; private set; }

        private void _DeleteProduct()
        {
            if(EditProduct.ProductID == 0)
            {
                MessageBoxShowDelegate("Nie wybrano produktu");
                return;
            }
            try
            {
                Model.DeleteProduct(EditProduct);
            } catch(Exception e)
            {
                MessageBoxShowDelegate("Wystąpił problem z usunięciem produktu");
            }
        }
        #endregion
    }
}
