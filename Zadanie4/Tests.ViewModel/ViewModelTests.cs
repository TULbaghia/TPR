using Microsoft.VisualStudio.TestTools.UnitTesting;
using PresenterModel;
using PresenterViewModel;
using System.Linq;

namespace Tests.ViewModel
{
    [TestClass]
    public class ViewModelTests
    {
        [TestMethod]
        public void MessegeBoxDelegateTest()
        {
            string dialog = "";
            MainViewModel mainViewModel = new MainViewModel(new TestModel());
            mainViewModel.MessageBoxShowDelegate = text => dialog = text;
            mainViewModel.MessageBoxShowDelegate("Witaj Swiecie");
            Assert.AreEqual("Witaj Swiecie", dialog);
        }

        [TestMethod]
        public void ShowAddTest()
        {
            MainViewModel mainViewModel = new MainViewModel(new TestModel());
            Assert.IsTrue(mainViewModel.ShowAddControl.CanExecute(null));
            mainViewModel.ShowAddControl.Execute(null);
            Assert.AreEqual("Visible", mainViewModel.AddVisibility);
            Assert.AreEqual("Hidden", mainViewModel.EditVisibility);
        }

        [TestMethod]
        public void ShowEditTest()
        {
            MainViewModel mainViewModel = new MainViewModel(new TestModel());
            Assert.IsTrue(mainViewModel.ShowEditControl.CanExecute(null));
            mainViewModel.ShowEditControl.Execute(null);
            Assert.AreEqual("Hidden", mainViewModel.AddVisibility);
            Assert.AreEqual("Visible", mainViewModel.EditVisibility);
        }

        [TestMethod]
        public void ShowEditPropertiesEmptyTest()
        {
            MainViewModel mainViewModel = new MainViewModel(new TestModel());
            Assert.IsTrue(mainViewModel.ShowEditControl.CanExecute(null));
            mainViewModel.ShowEditControl.Execute(null);
            Assert.AreEqual("Hidden", mainViewModel.AddVisibility);
            Assert.AreEqual("Visible", mainViewModel.EditVisibility);
            Assert.AreEqual(0, mainViewModel.AddProduct.ProductID);
            Assert.AreEqual(0, mainViewModel.EditProduct.ProductID);
        }

        [TestMethod]
        public void AppendProductTest()
        {
            string dialog = "";
            TestModel tm = new TestModel();
            MainViewModel mainViewModel = new MainViewModel(tm);
            ProductModel pm = new ProductModel();
            mainViewModel.MessageBoxShowDelegate = text => dialog = text;
            mainViewModel.AddProduct = pm;
            Assert.IsTrue(mainViewModel.AppendProduct.CanExecute(null));
            Assert.AreEqual(0, tm.GetProducts().Count());
            mainViewModel.AppendProduct.Execute(null);
            Assert.AreEqual("Dodawanie nowego produktu przebiegło pomyślnie", dialog);
            Assert.AreEqual(1, tm.GetProducts().Count());
            Assert.AreEqual("Visible", mainViewModel.AddVisibility);
            Assert.AreEqual("Hidden", mainViewModel.EditVisibility);
        }

        [TestMethod]
        public void AppendProductErrorTest()
        {
            string dialog = "";
            MainViewModel mainViewModel = new MainViewModel(new TestModel());
            mainViewModel.MessageBoxShowDelegate = text => dialog = text;
            mainViewModel.AddProduct = new ProductModel { ProductID = -1 };
            Assert.IsTrue(mainViewModel.AppendProduct.CanExecute(null));
            mainViewModel.AppendProduct.Execute(null);
            Assert.AreEqual("Dodawanie nowego produktu zakończyło się niepowodzeniem", dialog);
        }

        [TestMethod]
        public void DeleteProductTest()
        {
            string dialog = "";
            TestModel tm = new TestModel();
            ProductModel pm = new ProductModel { ProductID = 1 };
            tm.AddProduct(pm);
            MainViewModel mainViewModel = new MainViewModel(tm);
            mainViewModel.MessageBoxShowDelegate = text => dialog = text;
            mainViewModel.EditProduct = new ProductModel { ProductID = 1 };
            Assert.IsTrue(mainViewModel.DeleteProduct.CanExecute(null));
            Assert.AreEqual(1, tm.GetProducts().Count());
            mainViewModel.DeleteProduct.Execute(null);
            Assert.AreEqual("Pomyślnie usunięto wybrany produkt", dialog);
            Assert.AreEqual(0, tm.GetProducts().Count());
            Assert.AreEqual("Visible", mainViewModel.AddVisibility);
            Assert.AreEqual("Hidden", mainViewModel.EditVisibility);
        }

        [TestMethod]
        public void DeleteNotSelectedTest()
        {
            string dialog = "";
            TestModel tm = new TestModel();
            ProductModel pm = new ProductModel { ProductID = 1 };
            tm.AddProduct(pm);
            pm.ProductID = 0;
            MainViewModel mainViewModel = new MainViewModel(tm);
            mainViewModel.MessageBoxShowDelegate = text => dialog = text;
            mainViewModel.EditProduct = pm;
            Assert.IsTrue(mainViewModel.DeleteProduct.CanExecute(null));
            Assert.AreEqual(1, tm.GetProducts().Count());
            mainViewModel.DeleteProduct.Execute(null);
            Assert.AreEqual("Nie wybrano produktu", dialog);
            Assert.AreEqual(1, tm.GetProducts().Count());
        }

        [TestMethod]
        public void DeleteErrorTest()
        {
            string dialog = "";
            MainViewModel mainViewModel = new MainViewModel(new TestModel());
            mainViewModel.MessageBoxShowDelegate = text => dialog = text;
            Assert.IsTrue(mainViewModel.DeleteProduct.CanExecute(null));
            mainViewModel.EditProduct = new ProductModel { ProductID = -1 };
            mainViewModel.DeleteProduct.Execute(null);
            Assert.AreEqual("Wystąpił problem z usunięciem produktu", dialog);
        }

        [TestMethod]
        public void ModifyProductTest()
        {
            string dialog = "";
            TestModel tm = new TestModel();
            ProductModel pm = new ProductModel { ProductID = 1, MakeFlag = true };
            tm.AddProduct(pm);
            MainViewModel mainViewModel = new MainViewModel(tm);
            pm.MakeFlag = false;
            mainViewModel.MessageBoxShowDelegate = text => dialog = text;
            mainViewModel.EditProduct = pm;
            Assert.IsTrue(mainViewModel.ModifyProduct.CanExecute(null));
            mainViewModel.ModifyProduct.Execute(null);
            Assert.AreEqual("Aktualizacja produktu przebiegła pomyślnie", dialog);
            Assert.AreEqual(1, tm.GetProducts().Count());
            Assert.AreEqual("Hidden", mainViewModel.AddVisibility);
            Assert.AreEqual("Visible", mainViewModel.EditVisibility);
        }

        [TestMethod]
        public void ModifyProductErrorTest()
        {
            string dialog = "";
            MainViewModel mainViewModel = new MainViewModel(new TestModel());
            mainViewModel.MessageBoxShowDelegate = text => dialog = text;
            mainViewModel.AddProduct = new ProductModel { ProductID = -1 };
            Assert.IsTrue(mainViewModel.ModifyProduct.CanExecute(null));
            mainViewModel.ModifyProduct.Execute(null);
            Assert.AreEqual("Wystąpił problem z edycją produktu", dialog);
        }

        [TestMethod]
        public void ShowDetailTest()
        {
            string dialog = "";
            MainViewModel mainViewModel = new MainViewModel(new TestModel());
            mainViewModel.MessageBoxShowDelegate = text => dialog = text;
            mainViewModel.EditProduct = new ProductModel { ProductID = 0 };
            mainViewModel.ShowDetail.Execute(null);
            Assert.AreEqual("Nie wybrano produktu", dialog);
        }

        [TestMethod]
        public void EditableNotEmptyTest()
        {
            string dialog = "";
            ProductModel pm = new ProductModel { ProductID = 111 };
            MainViewModel mainViewModel = new MainViewModel(new TestModel());
            mainViewModel.MessageBoxShowDelegate = text => dialog = text;
            mainViewModel.EditProduct = pm;
            Assert.AreEqual(pm.ProductID, mainViewModel.EditableProduct.ProductID);
        }

        [TestMethod]
        public void SelectedProductDetailedTest()
        {
            ProductModel pm = new ProductModel { ProductID = 1 };
            MainViewModel mainViewModel = new MainViewModel(new TestModel());
            mainViewModel.EditProduct = pm;
            DetailViewModel detailViewModel = new DetailViewModel();
            detailViewModel.SetSelectedProduct(mainViewModel);
            Assert.AreEqual(pm.ProductID, detailViewModel.SelectedProduct.ProductID);
            Assert.AreEqual(pm.ProductID, mainViewModel.EditProduct.ProductID);
        }
    }

}
