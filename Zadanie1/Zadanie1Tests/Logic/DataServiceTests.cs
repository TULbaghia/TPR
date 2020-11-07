using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zadanie1.Data;
using Zadanie1.Logic;

namespace Zadanie1Tests
{
    [TestClass]
    public class DataServiceTests
    {
        [TestMethod]
        public void WypozyczKsiazkeTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);
            DataService dataService = new DataService(dataRepository);

            Klient klient1 = new Klient("Jan", "Nazwisko1");
            Klient klient2 = new Klient("Jan", "Nazwisko2");
            Ksiazka ksiazka1 = new Ksiazka("Tytul", "Autor1");
            Ksiazka ksiazka2 = new Ksiazka("Tytul", "Autor2");
            Stan stan1 = new Stan(ksiazka1, "Opis1", 1);
            Stan stan2 = new Stan(ksiazka2, "Opis2", 2);
            dataService.AddStan(stan1);
            dataService.AddStan(stan2);

            dataService.WypozyczKsiazke(klient1, ksiazka1);
            Assert.ThrowsException<ArgumentException>(() => dataService.WypozyczKsiazke(klient2, ksiazka1));
            dataService.WypozyczKsiazke(klient2, ksiazka2);
            dataService.WypozyczKsiazke(klient1, ksiazka2);

            Assert.AreEqual(dataService.GetAllZdarzeniaDlaKlienta(klient1).ToList().Count, 2);
            Assert.AreEqual(dataService.GetAllZdarzeniaDlaKlienta(klient2).ToList().Count, 1);
        }

        [TestMethod]
        public void ZwrocKsiazkeTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);
            DataService dataService = new DataService(dataRepository);

            Klient klient1 = new Klient("Jan", "Nazwisko1");
            Klient klient2 = new Klient("Jan", "Nazwisko2");
            Ksiazka ksiazka1 = new Ksiazka("Tytul", "Autor1");
            Ksiazka ksiazka2 = new Ksiazka("Tytul", "Autor2");
            Stan stan1 = new Stan(ksiazka1, "Opis1", 1);
            Stan stan2 = new Stan(ksiazka2, "Opis2", 2);
            dataService.AddStan(stan1);
            dataService.AddStan(stan2);

            dataService.WypozyczKsiazke(klient1, ksiazka1);
            Assert.ThrowsException<ArgumentException>(() => dataService.WypozyczKsiazke(klient2, ksiazka1));
            dataService.WypozyczKsiazke(klient2, ksiazka2);
            dataService.WypozyczKsiazke(klient1, ksiazka2);

            Assert.ThrowsException<ArgumentException>(() => dataService.ZwrocKsiazke(klient2, ksiazka1));
            dataService.ZwrocKsiazke(klient2, ksiazka2);
            dataService.ZwrocKsiazke(klient1, ksiazka1);
            dataService.ZwrocKsiazke(klient1, ksiazka2);

            Assert.AreEqual(dataService.GetAllZdarzeniaDlaKlienta(klient1).ToList().Count, 4);
            Assert.AreEqual(dataService.GetAllZdarzeniaDlaKlienta(klient2).ToList().Count, 2);

        }
    }
}
