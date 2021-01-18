using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using PresenterModel;

namespace PresenterViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public IModel Model { get; private set; }

        public MainViewModel()
        {
            Model = new Model();
            ShowDetail = new RelayCommand(_ShowDetail);
            ShowAddControl = new RelayCommand(() => ShowAdd(true));
            ShowEditControl = new RelayCommand(() => ShowAdd(false));
            DeleteProduct = new RelayCommand(() => { Task.Run(_DeleteProduct); });
            AppendProduct = new RelayCommand(() => { Task.Run(_AppendProduct); });
            ModifyProduct = new RelayCommand(() => { Task.Run(_ModifyProduct); });

            EditProduct = new ProductModel();
            Products = Model.GetProducts().ToList();
            ShowAdd(true);
        }


        #region ModifyProduct commands
        public RelayCommand ModifyProduct { get; private set; }
        private void _ModifyProduct()
        {
            try
            {
                int tempProductID = EditProduct.ProductID;
                Model.UpdateProduct(EditProduct);
                Products = Model.GetProducts().ToList();
                MessageBoxShowDelegate("Aktualizacja produktu przebiegła pomyślnie");
                EditProduct = Products.Single(x => x.ProductID == tempProductID);
            }
            catch (Exception e)
            {
                MessageBoxShowDelegate("Wystąpił problem z edycją produktu");
            }
        }
        #endregion

        #region AppendProduct commands
        public RelayCommand AppendProduct { get; private set; }
        private void _AppendProduct()
        {
            try
            {
                Model.AddProduct(AddProduct);
                Products = Model.GetProducts().ToList();
                MessageBoxShowDelegate("Dodawanie nowego produktu przebiegło pomyślnie");
                ShowAdd(true);
            }
            catch (Exception e)
            {
                MessageBoxShowDelegate("Dodawanie nowego produktu zakończyło się niepowodzeniem");
            }
        }
        #endregion

        #region Properties: AddProduct, EditProduct Products
        private List<ProductModel> productList;
        public List<ProductModel> Products
        {
            get => productList;
            set
            {
                productList = value;
                NotifyPropertyChanged();
            }
        }

        private ProductModel _EditProduct;
        private ProductModel _EditableProduct;
        public ProductModel EditProduct
        {
            get => _EditProduct;
            set
            {
                _EditProduct = value;
                if (value != null)
                {
                    EditableProduct = new ProductModel(_EditProduct.CreateProduct());
                }
                ShowAdd(false);
                NotifyPropertyChanged();
            }
        }
        public ProductModel EditableProduct
        {
            get => _EditableProduct;
            set
            {
                _EditableProduct = value;
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

        public Action<string> MessageBoxShowDelegate { get; set; }

        public Lazy<IDetail> DetailWindow { get; set; }
        public RelayCommand ShowDetail { get; set; }
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
        public RelayCommand ShowAddControl { get; set; }
        public RelayCommand ShowEditControl { get; set; }

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
        }
        #endregion

        #region DeleteProduct
        public RelayCommand DeleteProduct { get; private set; }

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
                Products = Model.GetProducts().ToList();
                MessageBoxShowDelegate("Pomyślnie usunięto wybrany produkt");
                ShowAdd(true);
            } catch(Exception e)
            {
                MessageBoxShowDelegate("Wystąpił problem z usunięciem produktu");
            }
        }
        #endregion

        #region Other
        public MainViewModel(IModel model)
        {
            Model = model;
            ShowDetail = new RelayCommand(_ShowDetail);
            ShowAddControl = new RelayCommand(() => ShowAdd(true));
            ShowEditControl = new RelayCommand(() => ShowAdd(false));
            DeleteProduct = new RelayCommand(() => { _DeleteProduct(); });
            AppendProduct = new RelayCommand(() => { _AppendProduct(); });
            ModifyProduct = new RelayCommand(() => { _ModifyProduct(); });

            EditProduct = new ProductModel();
            Products = Model.GetProducts().ToList();
            ShowAdd(true);
        }
        #endregion
    }
}
