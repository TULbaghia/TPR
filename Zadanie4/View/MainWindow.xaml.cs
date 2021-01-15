using PresenterViewModel;
using System;
using System.Windows;

namespace PresenterView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            MainViewModel _viewModel = (MainViewModel) DataContext;
            _viewModel.DetailWindow = new Lazy<IDetail>(() => new DetailView());
            _viewModel.MainWindow = this;
        }
    }
}
