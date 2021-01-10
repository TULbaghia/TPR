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

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void ShowWindow()
        {
            throw new NotImplementedException();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            MainViewModel _viewModel = (MainViewModel) DataContext;
            _viewModel.DetailWindow = new Lazy<IWindow>(() => new DetailView());
            _viewModel.MainWindow = this;
        }
    }
}
