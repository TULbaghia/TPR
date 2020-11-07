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

        [TestMethod]
        public void GetAllZdarzeniaDlaKsiazkiTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);
            DataService dataService = new DataService(dataRepository);

            Ksiazka ksiazka = new Ksiazka("Testowa", "Ksiazka1");
            dataService.AddKsiazka(ksiazka);
            Stan stan = new Stan(ksiazka, "", 1);
            dataService.AddStan(stan);

            Assert.AreEqual(dataService.GetAllZdarzeniaDlaKsiazki(stan.Ksiazka).Count(), 0);

            dataService.WypozyczKsiazke(dataService.GetKlient(0), stan.Ksiazka);
            Assert.AreEqual(dataService.GetAllZdarzeniaDlaKsiazki(stan.Ksiazka).Count(), 1);

            dataService.ZwrocKsiazke(dataService.GetKlient(0), stan.Ksiazka);
            Assert.AreEqual(dataService.GetAllZdarzeniaDlaKsiazki(stan.Ksiazka).Count(), 2);

            dataService.WypozyczKsiazke(dataService.GetKlient(0), stan.Ksiazka);
            Assert.AreEqual(dataService.GetAllZdarzeniaDlaKsiazki(stan.Ksiazka).Count(), 3);
        }

        [TestMethod]
        public void GetAllZdarzeniaDlaKlientaTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);
            DataService dataService = new DataService(dataRepository);

            Klient klient = new Klient("Jan", "Kowalski");
            dataService.AddKlient(klient);
            Ksiazka ksiazka = new Ksiazka("Testowa", "Ksiazka1");
            dataService.AddKsiazka(ksiazka);
            Stan stan = new Stan(ksiazka, "", 1);
            dataService.AddStan(stan);

            Assert.AreEqual(dataService.GetAllZdarzeniaDlaKlienta(klient).Count(), 0);

            dataService.WypozyczKsiazke(klient, stan.Ksiazka);
            Assert.AreEqual(dataService.GetAllZdarzeniaDlaKlienta(klient).Count(), 1);

            dataService.ZwrocKsiazke(klient, stan.Ksiazka);
            Assert.AreEqual(dataService.GetAllZdarzeniaDlaKlienta(klient).Count(), 2);

            dataService.WypozyczKsiazke(klient, stan.Ksiazka);
            Assert.AreEqual(dataService.GetAllZdarzeniaDlaKlienta(klient).Count(), 3);
        }

        [TestMethod]
        public void GetAllZdarzeniaDlaStanuTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);
            DataService dataService = new DataService(dataRepository);

            Klient klient = new Klient("Jan", "Kowalski");
            dataService.AddKlient(klient);
            Ksiazka ksiazka = new Ksiazka("Testowa", "Ksiazka1");
            dataService.AddKsiazka(ksiazka);
            Stan stan = new Stan(ksiazka, "", 1);
            dataService.AddStan(stan);

            Assert.AreEqual(dataService.GetAllZdarzeniaDlaStanu(stan).Count(), 0);

            dataService.WypozyczKsiazke(klient, stan.Ksiazka);
            Assert.AreEqual(dataService.GetAllZdarzeniaDlaStanu(stan).Count(), 1);

            dataService.ZwrocKsiazke(klient, stan.Ksiazka);
            Assert.AreEqual(dataService.GetAllZdarzeniaDlaStanu(stan).Count(), 2);

            dataService.WypozyczKsiazke(klient, stan.Ksiazka);
            Assert.AreEqual(dataService.GetAllZdarzeniaDlaStanu(stan).Count(), 3);
        }

        [TestMethod]
        public void GetAllStanyDlaKsiazkiTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);
            DataService dataService = new DataService(dataRepository);

            Klient klient = new Klient("Jan", "Kowalski");
            dataService.AddKlient(klient);
            Ksiazka ksiazka = new Ksiazka("Testowa", "Ksiazka1");
            dataService.AddKsiazka(ksiazka);

            Assert.AreEqual(dataService.GetAllStanyDlaKsiazki(ksiazka).Count(), 0);

            dataService.AddStan(new Stan(ksiazka, "", 1));
            Assert.AreEqual(dataService.GetAllStanyDlaKsiazki(ksiazka).Count(), 1);

            dataService.AddStan(new Stan(ksiazka, "", 1));
            Assert.AreEqual(dataService.GetAllStanyDlaKsiazki(ksiazka).Count(), 2);

            dataService.AddStan(new Stan(ksiazka, "", 1));
            Assert.AreEqual(dataService.GetAllStanyDlaKsiazki(ksiazka).Count(), 3);
        }

        [TestMethod]
        public void GetAllZdarzeniaPomiedzyDatamiTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);
            DataService dataService = new DataService(dataRepository);

            Ksiazka ksiazka = new Ksiazka("Testowa", "Ksiazka1");
            dataService.AddKsiazka(ksiazka);
            Stan stan = new Stan(ksiazka, "", 1);
            dataService.AddStan(stan);

            DateTime start = DateTime.Now;
            DateTime stop = DateTime.Now;

            Assert.AreEqual(dataService.GetAllZdarzeniaPomiedzyDatami(start, stop).Count(), 0);

            dataService.WypozyczKsiazke(dataService.GetKlient(0), stan.Ksiazka);
            stop = DateTime.Now;
            Assert.AreEqual(dataService.GetAllZdarzeniaPomiedzyDatami(start, stop).Count(), 1);

            dataService.ZwrocKsiazke(dataService.GetKlient(0), stan.Ksiazka);
            stop = DateTime.Now;
            Assert.AreEqual(dataService.GetAllZdarzeniaPomiedzyDatami(start, stop).Count(), 2);

            dataService.WypozyczKsiazke(dataService.GetKlient(0), stan.Ksiazka);
            stop = DateTime.Now;
            Assert.AreEqual(dataService.GetAllZdarzeniaPomiedzyDatami(start, stop).Count(), 3);
        }
    }
}
