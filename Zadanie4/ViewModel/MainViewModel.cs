using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Data;
using PresenterModel;

namespace PresenterViewModel
{
    public class MainViewModel
    {
        public Model Model { get; private set; }

        public List<Product> Products { get => Model.GetProducts().ToList(); }
        public Product SelectedProduct { get; set; }
        public ViewModelCommand ShowDetail { get; set; }

        public MainViewModel()
        {
            Model = new Model();
            ShowDetail = new ViewModelCommand(() => DetailWindow.Value.ShowWindow());
        }

        public Lazy<IWindow> DetailWindow { get; set; }

        public IWindow MainWindow { get; set; }
    }
}
