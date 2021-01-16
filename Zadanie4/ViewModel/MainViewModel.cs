using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
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
            DeleteProduct = new ViewModelCommand(() => { Task.Run(_DeleteProduct); });
            AppendProduct = new ViewModelCommand(() => { Task.Run(_AppendProduct); });
            ModifyProduct = new ViewModelCommand(() => { Task.Run(_ModifyProduct); });

            EditProduct = new ProductModel();
            Products = Model.GetProducts().ToList();
            ShowAdd(true);
        }

        #region ModifyProduct commands
        public ViewModelCommand ModifyProduct { get; private set; }
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
        public ViewModelCommand AppendProduct { get; private set; }
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
                MessageBoxShowDelegate(e.Message);
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
                Products = Model.GetProducts().ToList();
            } catch(Exception e)
            {
                MessageBoxShowDelegate(e.Message);
                //MessageBoxShowDelegate("Wystąpił problem z usunięciem produktu");
            }
        }
        #endregion
    }
}
