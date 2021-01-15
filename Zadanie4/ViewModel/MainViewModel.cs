using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using PresenterModel;

namespace PresenterViewModel
{
    public class MainViewModel
    {
        public Model Model { get; private set; }
        public List<ProductModel> Products { get => Model.GetProducts().ToList(); }
        public ProductModel SelectedProduct { get; set; }
        public ViewModelCommand ShowDetail { get; set; }

        public MainViewModel()
        {
            Model = new Model();
            ShowDetail = new ViewModelCommand(() => DetailWindow.Value.ShowWindow(this));
        }

        public Lazy<IDetail> DetailWindow { get; set; }

        public IWindow MainWindow { get; set; }
    }
}
