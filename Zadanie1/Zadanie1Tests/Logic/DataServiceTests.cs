using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Zadanie1.Data;
using Zadanie1.Logic;

namespace Zadanie1Tests.Logic
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

            Assert.AreEqual(1, dataService.GetAllZdarzeniaDlaKlienta(klient1).ToList().Count);
            Assert.AreEqual(1, dataService.GetAllZdarzeniaDlaKlienta(klient2).ToList().Count);

            Assert.AreEqual(1, dataService.GetAllZdarzeniaDlaStanu(stan1).ToList().Count);
            Assert.AreEqual(1, dataService.GetAllZdarzeniaDlaStanu(stan2).ToList().Count);
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

            Assert.AreEqual(2, dataService.GetAllZdarzeniaDlaKlienta(klient1).ToList().Count);
            Assert.AreEqual(4, dataService.GetAllZdarzeniaDlaKlienta(klient2).ToList().Count);

            Assert.AreEqual(2, dataService.GetAllZdarzeniaDlaStanu(stan1).ToList().Count);
            Assert.AreEqual(2, dataService.GetAllZdarzeniaDlaStanu(stan2).ToList().Count);
            Assert.AreEqual(2, dataService.GetAllZdarzeniaDlaStanu(stan3).ToList().Count);
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

            Assert.AreEqual(0, dataService.GetAllZdarzeniaDlaKsiazki(stan.Ksiazka).Count());

            dataService.WypozyczKsiazke(dataService.GetKlient(0), stan);
            Assert.AreEqual(1, dataService.GetAllZdarzeniaDlaKsiazki(stan.Ksiazka).Count());

            dataService.ZwrocKsiazke(dataService.GetKlient(0), stan);
            Assert.AreEqual(2, dataService.GetAllZdarzeniaDlaKsiazki(stan.Ksiazka).Count());

            dataService.WypozyczKsiazke(dataService.GetKlient(0), stan);
            Assert.AreEqual(3, dataService.GetAllZdarzeniaDlaKsiazki(stan.Ksiazka).Count());
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

            Assert.AreEqual(0, dataService.GetAllZdarzeniaDlaKlienta(klient).Count());

            dataService.WypozyczKsiazke(klient, stan);
            Assert.AreEqual(1, dataService.GetAllZdarzeniaDlaKlienta(klient).Count());

            dataService.ZwrocKsiazke(klient, stan);
            Assert.AreEqual(2, dataService.GetAllZdarzeniaDlaKlienta(klient).Count());

            dataService.WypozyczKsiazke(klient, stan);
            Assert.AreEqual(3, dataService.GetAllZdarzeniaDlaKlienta(klient).Count());
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

            Assert.AreEqual(0, dataService.GetAllZdarzeniaDlaStanu(stan).Count());

            dataService.WypozyczKsiazke(klient, stan);
            Assert.AreEqual(1, dataService.GetAllZdarzeniaDlaStanu(stan).Count());

            dataService.ZwrocKsiazke(klient, stan);
            Assert.AreEqual(2, dataService.GetAllZdarzeniaDlaStanu(stan).Count());

            dataService.WypozyczKsiazke(klient, stan);
            Assert.AreEqual(3, dataService.GetAllZdarzeniaDlaStanu(stan).Count());
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

            Assert.AreEqual(0, dataService.GetAllStanyDlaKsiazki(ksiazka).Count());

            dataService.AddStan(new Stan(ksiazka, "", false));
            Assert.AreEqual(1, dataService.GetAllStanyDlaKsiazki(ksiazka).Count());

            dataService.AddStan(new Stan(ksiazka, "", false));
            Assert.AreEqual(2, dataService.GetAllStanyDlaKsiazki(ksiazka).Count());

            dataService.AddStan(new Stan(ksiazka, "", false));
            Assert.AreEqual(3, dataService.GetAllStanyDlaKsiazki(ksiazka).Count());
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

            Assert.AreEqual(0, dataService.GetAllZdarzeniaPomiedzyDatami(start, stop).Count());

            dataService.WypozyczKsiazke(dataService.GetKlient(0), stan);
            stop = DateTime.Now;
            Assert.AreEqual(1, dataService.GetAllZdarzeniaPomiedzyDatami(start, stop).Count());

            dataService.ZwrocKsiazke(dataService.GetKlient(0), stan);
            stop = DateTime.Now;
            Assert.AreEqual(2, dataService.GetAllZdarzeniaPomiedzyDatami(start, stop).Count());

            dataService.WypozyczKsiazke(dataService.GetKlient(0), stan);
            stop = DateTime.Now;
            Assert.AreEqual(3, dataService.GetAllZdarzeniaPomiedzyDatami(start, stop).Count());
        }

        [TestMethod]
        public void FindInKsiazkiTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);
            DataService dataService = new DataService(dataRepository);

            String query = "Witaj Swiecie";

            Assert.AreEqual(0, dataService.FindInKsiazki(query).Count());

            dataService.AddKsiazka(new Ksiazka("Witaj Swiecie", "Jan"));

            Assert.AreEqual(1, dataService.FindInKsiazki(query).Count());

            dataService.AddKsiazka(new Ksiazka("Witaj Swiecie Tom 2", "Jan"));
            dataService.AddKsiazka(new Ksiazka("Pan Tadeusz", "Jan"));

            Assert.AreEqual(2, dataService.FindInKsiazki(query).Count());

            dataService.AddKsiazka(new Ksiazka("Tom 3", "Witaj Swiecie"));

            Assert.AreEqual(3, dataService.FindInKsiazki(query).Count());
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

            Assert.AreEqual(0, dataService.FindInStany(query).Count());

            dataService.AddStan(new Stan(ksiazka, "", false));

            Assert.AreEqual(1, dataService.FindInStany(query).Count());

            dataService.AddStan(new Stan(dataService.GetKsiazka(0), "Witaj Swiecie", false));
            dataService.AddStan(new Stan(dataService.GetKsiazka(0), "", true));

            Assert.AreEqual(2, dataService.FindInStany(query).Count());

            dataService.AddStan(new Stan(ksiazka, "Witaj Swiecie", false));

            Assert.AreEqual(3, dataService.FindInStany(query).Count());
        }

        [TestMethod]
        public void FindInKlientTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);
            DataService dataService = new DataService(dataRepository);

            String query = "Witaj Swiecie";

            Assert.AreEqual(0, dataService.FindInKlienci(query).Count());

            dataService.AddKlient(new Klient("Witaj Swiecie", "Kowalski"));

            Assert.AreEqual(1, dataService.FindInKlienci(query).Count());

            dataService.AddKlient(new Klient("Witaj Swiecie Tom 2", "Kowalski"));
            dataService.AddKlient(new Klient("Pan Tadeusz", "Kowalski"));

            Assert.AreEqual(2, dataService.FindInKlienci(query).Count());

            dataService.AddKlient(new Klient("Jan", "Witaj Swiecie"));

            Assert.AreEqual(3, dataService.FindInKlienci(query).Count());
        }

        [TestMethod]
        public void FindInZdarzeniaTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);
            DataService dataService = new DataService(dataRepository);

            String query = "Witaj Swiecie";

            Assert.AreEqual(0, dataService.FindInZdarzenia(query).Count());

            Ksiazka ksiazka = new Ksiazka("Witaj Swiecie", "Jan");
            dataService.AddKsiazka(ksiazka);
            Stan stan = new Stan(ksiazka, "", false);
            dataService.AddStan(stan);
            dataService.WypozyczKsiazke(dataService.GetKlient(0), stan);
            Assert.AreEqual(1, dataService.FindInZdarzenia(query).Count());

            dataService.ZwrocKsiazke(dataService.GetKlient(0), stan);
            dataService.WypozyczKsiazke(dataService.GetKlient(0), dataService.GetStan(0));
            Assert.AreEqual(2, dataService.FindInZdarzenia(query).Count());
        }
    }
}
