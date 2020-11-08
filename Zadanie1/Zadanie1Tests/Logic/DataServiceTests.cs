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
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);
            DataService dataService = new DataService(dataRepository);

            Klient klient1 = new Klient("Jan", "Nazwisko1");
            Klient klient2 = new Klient("Jan", "Nazwisko2");
            Ksiazka ksiazka1 = new Ksiazka("Tytul", "Autor1");
            Ksiazka ksiazka2 = new Ksiazka("Tytul", "Autor2");
            Stan stan1 = new Stan(ksiazka1, "Opis1", false);
            Stan stan2 = new Stan(ksiazka2, "Opis2", false);
            dataService.AddStan(stan1);
            dataService.AddStan(stan2);

            dataService.WypozyczKsiazke(klient1, stan1);
            Assert.ThrowsException<ArgumentException>(() => dataService.WypozyczKsiazke(klient2, stan1));
            dataService.WypozyczKsiazke(klient2, stan2);
            Assert.ThrowsException<ArgumentException>(() => dataService.WypozyczKsiazke(klient2, stan2));

            Assert.AreEqual(dataService.GetAllZdarzeniaDlaKlienta(klient1).ToList().Count, 1);
            Assert.AreEqual(dataService.GetAllZdarzeniaDlaKlienta(klient2).ToList().Count, 1);

            Assert.AreEqual(dataService.GetAllZdarzeniaDlaStanu(stan1).ToList().Count, 1);
            Assert.AreEqual(dataService.GetAllZdarzeniaDlaStanu(stan2).ToList().Count, 1);
        }

        [TestMethod]
        public void ZwrocKsiazkeTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);
            DataService dataService = new DataService(dataRepository);

            Klient klient1 = new Klient("Jan", "Nazwisko1");
            Klient klient2 = new Klient("Jan", "Nazwisko2");
            Ksiazka ksiazka1 = new Ksiazka("Tytul", "Autor1");
            Ksiazka ksiazka2 = new Ksiazka("Tytul", "Autor2");
            Stan stan1 = new Stan(ksiazka1, "Opis1", false);
            Stan stan2 = new Stan(ksiazka1, "Opis1", false);
            Stan stan3 = new Stan(ksiazka2, "Opis3", false);
            dataService.AddStan(stan1);
            dataService.AddStan(stan2);
            dataService.AddStan(stan3);

            dataService.WypozyczKsiazke(klient1, stan1);
            Assert.ThrowsException<ArgumentException>(() => dataService.WypozyczKsiazke(klient2, stan1));
            dataService.WypozyczKsiazke(klient2, stan2);
            dataService.WypozyczKsiazke(klient2, stan3);

            Assert.ThrowsException<ArgumentException>(() => dataService.ZwrocKsiazke(klient1, stan2));
            dataService.ZwrocKsiazke(klient1, stan1);
            dataService.ZwrocKsiazke(klient2, stan2);
            dataService.ZwrocKsiazke(klient2, stan3);

            Assert.ThrowsException<ArgumentException>(() => dataService.ZwrocKsiazke(klient2, stan2));
            Assert.ThrowsException<ArgumentException>(() => dataService.ZwrocKsiazke(klient2, stan3));

            Assert.AreEqual(dataService.GetAllZdarzeniaDlaKlienta(klient1).ToList().Count, 2);
            Assert.AreEqual(dataService.GetAllZdarzeniaDlaKlienta(klient2).ToList().Count, 4);

            Assert.AreEqual(dataService.GetAllZdarzeniaDlaStanu(stan1).ToList().Count, 2);
            Assert.AreEqual(dataService.GetAllZdarzeniaDlaStanu(stan2).ToList().Count, 2);
            Assert.AreEqual(dataService.GetAllZdarzeniaDlaStanu(stan3).ToList().Count, 2);
        }

        [TestMethod]
        public void GetAllZdarzeniaDlaKsiazkiTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);
            DataService dataService = new DataService(dataRepository);

            Ksiazka ksiazka = new Ksiazka("Testowa", "Ksiazka1");
            dataService.AddKsiazka(ksiazka);
            Stan stan = new Stan(ksiazka, "", false);
            dataService.AddStan(stan);

            Assert.AreEqual(dataService.GetAllZdarzeniaDlaKsiazki(stan.Ksiazka).Count(), 0);

            dataService.WypozyczKsiazke(dataService.GetKlient(0), stan);
            Assert.AreEqual(dataService.GetAllZdarzeniaDlaKsiazki(stan.Ksiazka).Count(), 1);

            dataService.ZwrocKsiazke(dataService.GetKlient(0), stan);
            Assert.AreEqual(dataService.GetAllZdarzeniaDlaKsiazki(stan.Ksiazka).Count(), 2);

            dataService.WypozyczKsiazke(dataService.GetKlient(0), stan);
            Assert.AreEqual(dataService.GetAllZdarzeniaDlaKsiazki(stan.Ksiazka).Count(), 3);
        }

        [TestMethod]
        public void GetAllZdarzeniaDlaKlientaTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);
            DataService dataService = new DataService(dataRepository);

            Klient klient = new Klient("Jan", "Kowalski");
            dataService.AddKlient(klient);
            Ksiazka ksiazka = new Ksiazka("Testowa", "Ksiazka1");
            dataService.AddKsiazka(ksiazka);
            Stan stan = new Stan(ksiazka, "", false);
            dataService.AddStan(stan);

            Assert.AreEqual(dataService.GetAllZdarzeniaDlaKlienta(klient).Count(), 0);

            dataService.WypozyczKsiazke(klient, stan);
            Assert.AreEqual(dataService.GetAllZdarzeniaDlaKlienta(klient).Count(), 1);

            dataService.ZwrocKsiazke(klient, stan);
            Assert.AreEqual(dataService.GetAllZdarzeniaDlaKlienta(klient).Count(), 2);

            dataService.WypozyczKsiazke(klient, stan);
            Assert.AreEqual(dataService.GetAllZdarzeniaDlaKlienta(klient).Count(), 3);
        }

        [TestMethod]
        public void GetAllZdarzeniaDlaStanuTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);
            DataService dataService = new DataService(dataRepository);

            Klient klient = new Klient("Jan", "Kowalski");
            dataService.AddKlient(klient);
            Ksiazka ksiazka = new Ksiazka("Testowa", "Ksiazka1");
            dataService.AddKsiazka(ksiazka);
            Stan stan = new Stan(ksiazka, "", false);
            dataService.AddStan(stan);

            Assert.AreEqual(dataService.GetAllZdarzeniaDlaStanu(stan).Count(), 0);

            dataService.WypozyczKsiazke(klient, stan);
            Assert.AreEqual(dataService.GetAllZdarzeniaDlaStanu(stan).Count(), 1);

            dataService.ZwrocKsiazke(klient, stan);
            Assert.AreEqual(dataService.GetAllZdarzeniaDlaStanu(stan).Count(), 2);

            dataService.WypozyczKsiazke(klient, stan);
            Assert.AreEqual(dataService.GetAllZdarzeniaDlaStanu(stan).Count(), 3);
        }

        [TestMethod]
        public void GetAllStanyDlaKsiazkiTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);
            DataService dataService = new DataService(dataRepository);

            Klient klient = new Klient("Jan", "Kowalski");
            dataService.AddKlient(klient);
            Ksiazka ksiazka = new Ksiazka("Testowa", "Ksiazka1");
            dataService.AddKsiazka(ksiazka);

            Assert.AreEqual(dataService.GetAllStanyDlaKsiazki(ksiazka).Count(), 0);

            dataService.AddStan(new Stan(ksiazka, "", false));
            Assert.AreEqual(dataService.GetAllStanyDlaKsiazki(ksiazka).Count(), 1);

            dataService.AddStan(new Stan(ksiazka, "", false));
            Assert.AreEqual(dataService.GetAllStanyDlaKsiazki(ksiazka).Count(), 2);

            dataService.AddStan(new Stan(ksiazka, "", false));
            Assert.AreEqual(dataService.GetAllStanyDlaKsiazki(ksiazka).Count(), 3);
        }

        [TestMethod]
        public void GetAllZdarzeniaPomiedzyDatamiTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);
            DataService dataService = new DataService(dataRepository);

            Ksiazka ksiazka = new Ksiazka("Testowa", "Ksiazka1");
            dataService.AddKsiazka(ksiazka);
            Stan stan = new Stan(ksiazka, "", false);
            dataService.AddStan(stan);

            DateTime start = DateTime.Now;
            DateTime stop = DateTime.Now;

            Assert.AreEqual(dataService.GetAllZdarzeniaPomiedzyDatami(start, stop).Count(), 0);

            dataService.WypozyczKsiazke(dataService.GetKlient(0), stan);
            stop = DateTime.Now;
            Assert.AreEqual(dataService.GetAllZdarzeniaPomiedzyDatami(start, stop).Count(), 1);

            dataService.ZwrocKsiazke(dataService.GetKlient(0), stan);
            stop = DateTime.Now;
            Assert.AreEqual(dataService.GetAllZdarzeniaPomiedzyDatami(start, stop).Count(), 2);

            dataService.WypozyczKsiazke(dataService.GetKlient(0), stan);
            stop = DateTime.Now;
            Assert.AreEqual(dataService.GetAllZdarzeniaPomiedzyDatami(start, stop).Count(), 3);
        }

        [TestMethod]
        public void FindInKsiazkiTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);
            DataService dataService = new DataService(dataRepository);

            String query = "Witaj Swiecie";

            Assert.AreEqual(dataService.FindInKsiazki(query).Count(), 0);

            dataService.AddKsiazka(new Ksiazka("Witaj Swiecie", "Jan"));

            Assert.AreEqual(dataService.FindInKsiazki(query).Count(), 1);

            dataService.AddKsiazka(new Ksiazka("Witaj Swiecie Tom 2", "Jan"));
            dataService.AddKsiazka(new Ksiazka("Pan Tadeusz", "Jan"));

            Assert.AreEqual(dataService.FindInKsiazki(query).Count(), 2);

            dataService.AddKsiazka(new Ksiazka("Tom 3", "Witaj Swiecie"));

            Assert.AreEqual(dataService.FindInKsiazki(query).Count(), 3);
        }

        [TestMethod]
        public void FindInStanyTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);
            DataService dataService = new DataService(dataRepository);

            String query = "Witaj Swiecie";
            Ksiazka ksiazka = new Ksiazka("Witaj Swiecie", "Jan");
            dataService.AddKsiazka(ksiazka);

            Assert.AreEqual(dataService.FindInStany(query).Count(), 0);

            dataService.AddStan(new Stan(ksiazka, "", false));

            Assert.AreEqual(dataService.FindInStany(query).Count(), 1);

            dataService.AddStan(new Stan(dataService.GetKsiazka(0), "Witaj Swiecie", false));
            dataService.AddStan(new Stan(dataService.GetKsiazka(0), "", true));

            Assert.AreEqual(dataService.FindInStany(query).Count(), 2);

            dataService.AddStan(new Stan(ksiazka, "Witaj Swiecie", false));

            Assert.AreEqual(dataService.FindInStany(query).Count(), 3);
        }

        [TestMethod]
        public void FindInKlientTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);
            DataService dataService = new DataService(dataRepository);

            String query = "Witaj Swiecie";

            Assert.AreEqual(dataService.FindInKlienci(query).Count(), 0);

            dataService.AddKlient(new Klient("Witaj Swiecie", "Kowalski"));

            Assert.AreEqual(dataService.FindInKlienci(query).Count(), 1);

            dataService.AddKlient(new Klient("Witaj Swiecie Tom 2", "Kowalski"));
            dataService.AddKlient(new Klient("Pan Tadeusz", "Kowalski"));

            Assert.AreEqual(dataService.FindInKlienci(query).Count(), 2);

            dataService.AddKlient(new Klient("Jan", "Witaj Swiecie"));

            Assert.AreEqual(dataService.FindInKlienci(query).Count(), 3);
        }

        [TestMethod]
        public void FindInZdarzeniaTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);
            DataService dataService = new DataService(dataRepository);

            String query = "Witaj Swiecie";

            Assert.AreEqual(dataService.FindInZdarzenia(query).Count(), 0);

            Assert.Inconclusive();
/*
            Ksiazka ksiazka = new Ksiazka("Pan Tadeusz", "Jan");
            dataService.AddKsiazka(ksiazka);
            Stan stan = new Stan(ksiazka, "Witaj Swiecie", false);
            dataService.AddStan(stan);
            dataService.WypozyczKsiazke(dataService.GetKlient(0), stan);
            Assert.AreEqual(dataService.FindInZdarzenia(query).Count(), 1);


            Klient klient = new Klient("Witaj Swiecie", "Kowalski");
            dataService.AddKlient(klient);
            Stan stan1 = new Stan(ksiazka, "", false);
            dataService.AddStan(stan1);
            dataService.WypozyczKsiazke(klient, stan1);
            Assert.AreEqual(dataService.FindInZdarzenia(query).Count(), 2);

            Stan stan2 = new Stan(ksiazka, "", false);
            dataService.AddStan(stan2);
            dataService.WypozyczKsiazke(dataService.GetKlient(0), stan2);
            Assert.AreEqual(dataService.FindInZdarzenia(query).Count(), 2);*/
        }
    }
}
