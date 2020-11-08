using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Zadanie1.Data;

namespace Zadanie1Tests.Data
{
    [TestClass]
    public class DataRepositoryTests
    {
        #region Klient

        [TestMethod]
        public void AddKlientTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);
            Klient klient = new Klient("Jan", "Testowy");

            int klienciSize = dataRepository.GetAllKlient().Count();
            dataRepository.AddKlient(klient);

            Assert.AreEqual(klienciSize + 1, dataRepository.GetAllKlient().Count());
            Assert.AreEqual("Jan", dataRepository.GetKlient(klienciSize).Imie);
            Assert.AreEqual("Testowy", dataRepository.GetKlient(klienciSize).Nazwisko);
        }

        [TestMethod]
        public void GetKlientTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);

            for (int i = 0; i < dataContext.Klienci.Count; i++)
            {
                Assert.AreEqual("Jan" + i, dataRepository.GetKlient(i).Imie);
                Assert.AreEqual("Testowy" + i, dataRepository.GetKlient(i).Nazwisko);
            }
        }

        [TestMethod]
        public void GetKlientExceptionTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);

            Assert.ThrowsException<KeyNotFoundException>( () => dataRepository.GetKlient(dataRepository.GetAllKlient().Count() + 1) );
        }

        [TestMethod]
        public void GetAllKlientTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);

            Assert.AreEqual(dataContext.Klienci.Count, dataRepository.GetAllKlient().ToList().Count);

            List<Klient> klientGetAllList = dataRepository.GetAllKlient().ToList();
            for (int i = 0; i < klientGetAllList.Count; i++)
            {
                Assert.AreEqual("Jan" + i, klientGetAllList[i].Imie);
            }
        }

        [TestMethod]
        public void UpdateKlientTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);

            dataRepository.UpdateKlient(0, "Karol", "Update");
            Assert.AreEqual("Karol", dataRepository.GetKlient(0).Imie);
            Assert.AreEqual("Update", dataRepository.GetKlient(0).Nazwisko);
        }

        [TestMethod]
        public void UpdateKlientExceptionTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);

            Assert.ThrowsException<KeyNotFoundException>( () => dataRepository.UpdateKlient(dataRepository.GetAllKlient().Count()+1, "Jan", "Kowalski") );
        }

        [TestMethod]
        public void DeleteKlientTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);

            Klient klient = new Klient("Jan", "Kowalski");
            dataRepository.AddKlient(klient);

            Assert.AreSame(klient, dataRepository.GetKlient(dataRepository.GetAllKlient().Count()-1));
            dataRepository.DeleteKlient(klient);
            foreach (Klient k in dataRepository.GetAllKlient())
            {
                Assert.AreNotSame(klient, k);
            }
        }

        [TestMethod]
        public void DeleteKlientExceptionTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);

            Klient klient = dataRepository.GetKlient(0);
            dataRepository.AddZdarzenie(new Wypozyczenie(klient, dataRepository.GetStan(0)));

            Assert.AreSame(klient, dataRepository.GetKlient(0));
            Assert.ThrowsException<Exception>(() => dataRepository.DeleteKlient(klient));
        }

        [TestMethod]
        public void DeleteKlientAtTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);

            Klient klient1 = new Klient("Jan", "Kowalski");
            Klient klient2 = new Klient("Jan", "Kowalski");
            Klient klient3 = new Klient("Jan", "Kowalski");
            dataRepository.AddKlient(klient1);
            dataRepository.AddKlient(klient2);
            dataRepository.AddKlient(klient3);

            dataRepository.DeleteKlient(klient2);
            bool isKlient1 = false, isKlient2 = false, isKlient3 = false;
            foreach (Klient k in dataRepository.GetAllKlient())
            {
                if (k == klient1)
                {
                    isKlient1 = true;
                }
                if (k == klient2)
                {
                    isKlient2 = true;
                }
                if (k == klient3)
                {
                    isKlient3 = true;
                }
            }
            Assert.IsTrue(isKlient1);
            Assert.IsFalse(isKlient2);
            Assert.IsTrue(isKlient3);
        }

        #endregion

        #region Ksiazka

        [TestMethod]
        public void AddKsiazkaTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);
            Ksiazka ksiazka = new Ksiazka("TytulTest", "AutorTest");

            int ksiazkiSize = dataContext.Ksiazki.Count;
            dataRepository.AddKsiazka(ksiazka);

            Assert.AreEqual(ksiazkiSize + 1, dataContext.Ksiazki.Count);
            Assert.AreEqual("TytulTest", dataRepository.GetKsiazka(ksiazkiSize).Tytul);
            Assert.AreEqual("AutorTest", dataRepository.GetKsiazka(ksiazkiSize).Autor);
        }

        [TestMethod]
        public void AddKsiazkaExceptionTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);
            Ksiazka ksiazka1 = new Ksiazka("TytulTest", "AutorTest");
            Ksiazka ksiazka2 = new Ksiazka("TytulTest", "AutorTest");

            Assert.AreNotSame(ksiazka1, ksiazka2);
            Assert.AreEqual(ksiazka1, ksiazka2);

            dataRepository.AddKsiazka(ksiazka1);

            Assert.ThrowsException<Exception>(() => dataRepository.AddKsiazka(ksiazka2));
        }

        [TestMethod]
        public void GetKsiazkaTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);

            for (int i = 0; i < dataContext.Ksiazki.Count; i++)
            {
                Assert.AreEqual("TestowyTytul" + i, dataRepository.GetKsiazka(i).Tytul);
                Assert.AreEqual("TestowyAutor" + i, dataRepository.GetKsiazka(i).Autor);
            }
        }

        [TestMethod]
        public void GetKsiazkaExceptionTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);

            Assert.ThrowsException<KeyNotFoundException>(() => dataRepository.GetKsiazka(dataRepository.GetAllKsiazka().Count() + 1));
        }

        [TestMethod]
        public void GetAllKsiazkaTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);

            Assert.AreEqual(dataContext.Ksiazki.Count, dataRepository.GetAllKsiazka().ToList().Count);

            List<Ksiazka> ksiazkaGetAllList = dataRepository.GetAllKsiazka().ToList();
            for (int i = 0; i < ksiazkaGetAllList.Count; i++)
            {
                Assert.AreEqual("TestowyTytul" + i, ksiazkaGetAllList[i].Tytul);
            }
        }

        [TestMethod]
        public void UpdateKsiazkaTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);

            dataRepository.UpdateKsiazka(0, "UpdateTytul", "UpdateAutor");
            Assert.AreEqual("UpdateAutor", dataRepository.GetKsiazka(0).Autor);
            Assert.AreEqual("UpdateTytul", dataRepository.GetKsiazka(0).Tytul);
        }

        [TestMethod]
        public void DeleteKsiazkaTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);

            Ksiazka ksiazka = new Ksiazka("test", "ksiazka");
            dataRepository.AddKsiazka(ksiazka);

            Assert.AreEqual(ksiazka, dataRepository.GetKsiazka(dataRepository.GetAllKsiazka().Count()-1));
            dataRepository.DeleteKsiazka(ksiazka);
            foreach (Ksiazka k in dataRepository.GetAllKsiazka())
            {
                Assert.AreNotEqual(ksiazka, k);
            }
        }

        [TestMethod]
        public void DeleteKsiazkaExceptionTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);

            Ksiazka ksiazka = dataRepository.GetKsiazka(0);
            dataRepository.AddStan(new Stan(ksiazka, "", false));

            Assert.AreSame(ksiazka, dataRepository.GetKsiazka(0));
            Assert.ThrowsException<Exception>(() => dataRepository.DeleteKsiazka(ksiazka));
        }

        #endregion

        #region Stan

        [TestMethod]
        public void AddStanTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);

            Ksiazka ksiazka = new Ksiazka("TytulTest", "AutorTest");
            Stan stan = new Stan(ksiazka, "OpisTest", false, new DateTime(2020, 10, 10, 10, 10, 10));

            int stanySize = dataContext.Stany.Count;
            dataRepository.AddStan(stan);

            Assert.AreEqual(stanySize + 1, dataContext.Stany.Count);
            Assert.AreEqual("TytulTest", dataRepository.GetStan(stanySize).Ksiazka.Tytul);
            Assert.AreEqual("OpisTest", dataRepository.GetStan(stanySize).Opis);
            Assert.AreEqual(new DateTime(2020, 10, 10, 10, 10, 10), dataRepository.GetStan(stanySize).DataZakupu);
        }

        [TestMethod]
        public void GetStanTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);

            for (int i = 0; i < dataContext.Stany.Count; i++)
            {
                Assert.AreEqual(dataContext.Ksiazki[i], dataRepository.GetStan(i).Ksiazka);
                Assert.AreEqual("TestowyOpis" + i, dataRepository.GetStan(i).Opis);
                Assert.AreEqual(new DateTime(2020, 10, i + 1, 13, i + 1, 30), dataRepository.GetStan(i).DataZakupu);
            }
        }

        [TestMethod]
        public void GetStanExceptionTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);

            Assert.ThrowsException<KeyNotFoundException>(() => dataRepository.GetStan(dataRepository.GetAllStan().Count() + 1));
        }

        [TestMethod]
        public void GetAllStan()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);

            Assert.AreEqual(dataContext.Stany.Count, dataRepository.GetAllStan().ToList().Count);

            List<Stan> stanGetAllList = dataRepository.GetAllStan().ToList();
            for (int i = 0; i < stanGetAllList.Count; i++)
            {
                Assert.AreEqual("TestowyOpis" + i, stanGetAllList[i].Opis);
            }
        }

        [TestMethod]
        public void UpdateStanTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);

            dataRepository.UpdateStan(0, dataRepository.GetKsiazka(0), "UpdateOpisu", false, new DateTime(2000, 01, 01, 01, 01, 01));

            foreach (Stan stan in dataRepository.GetAllStan())
            {
                if (stan.Ksiazka.Equals(dataRepository.GetKsiazka(0)))
                {
                    Assert.AreEqual("UpdateOpisu", stan.Opis);
                    Assert.AreEqual(false, stan.CzyWypozyczona);
                    Assert.AreEqual(new DateTime(2000, 01, 01, 01, 01, 01), stan.DataZakupu);
                }
            }
        }

        [TestMethod]
        public void DeleteStanTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);

            Stan stan = new Stan(dataRepository.GetKsiazka(0), "x", false);
            dataRepository.AddStan(stan);

            Assert.AreEqual(stan, dataRepository.GetStan(dataRepository.GetAllStan().Count() - 1));
            dataRepository.DeleteStan(stan);
            foreach (Stan s in dataRepository.GetAllStan())
            {
                Assert.AreNotEqual(stan, s);
            }
        }

        [TestMethod]
        public void DeleteStanAlreadyUsedExceptionTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);

            Stan stan = dataRepository.GetStan(0);
            Zdarzenie zdarzenie = new Wypozyczenie(dataRepository.GetKlient(0), stan);

            Assert.ThrowsException<Exception>(() => dataRepository.DeleteStan(stan));
        }

        [TestMethod]
        public void DeleteStanAtTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);

            DateTime dt = DateTime.Now;
            Stan stan1 = new Stan(dataRepository.GetKsiazka(0), "x", false, dt);
            Stan stan2 = new Stan(dataRepository.GetKsiazka(0), "x", false, dt);
            Stan stan3 = new Stan(dataRepository.GetKsiazka(0), "x", false, dt);
            dataRepository.AddStan(stan1);
            dataRepository.AddStan(stan2);
            dataRepository.AddStan(stan3);

            dataRepository.DeleteStan(stan2);
            bool isStan1 = false, isStan2 = false, isStan3 = false;
            foreach (Stan s in dataRepository.GetAllStan())
            {
                if (s == stan1)
                {
                    isStan1 = true;
                }
                if (s == stan2)
                {
                    isStan2 = true;
                }
                if (s == stan3)
                {
                    isStan3 = true;
                }
            }
            Assert.IsTrue(isStan1);
            Assert.IsFalse(isStan2);
            Assert.IsTrue(isStan3);
        }

        #endregion

        #region Zdarzenie

        [TestMethod]
        public void AddWypozyczenieTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);

            Klient klient = new Klient("Jan", "NazwiskoWypozyczenie");
            Ksiazka ksiazka = new Ksiazka("Tytul", "AutorWypozyczenie");
            Stan stan = new Stan(ksiazka, "OpisWypozyczenie", false);
            Zdarzenie wypozyczenie = new Wypozyczenie(klient, stan);

            int zdarzeniaSize = dataContext.Zdarzenia.Count;
            dataRepository.AddZdarzenie(wypozyczenie);

            Assert.AreEqual(zdarzeniaSize + 1, dataContext.Zdarzenia.Count);
            Assert.AreEqual(stan, dataRepository.GetZdarzenie(zdarzeniaSize).Stan);
            Assert.AreEqual(klient, dataRepository.GetZdarzenie(zdarzeniaSize).Klient);
        }

        [TestMethod]
        public void AddZwrotTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);

            int zdarzeniaSize = dataContext.Zdarzenia.Count;
            Klient klient = new Klient("Jan", "NazwiskoZwrot");
            Ksiazka ksiazka = new Ksiazka("Tytul", "AutorZwrot");
            Stan stan = new Stan(ksiazka, "OpisZwrot", false);
            Zdarzenie zwrot = new Zwrot(klient, stan);

            dataRepository.AddZdarzenie(zwrot);

            Assert.AreEqual(zdarzeniaSize + 1, dataContext.Zdarzenia.Count);
            Assert.AreEqual(stan, dataRepository.GetZdarzenie(zdarzeniaSize).Stan);
            Assert.AreEqual(klient, dataRepository.GetZdarzenie(zdarzeniaSize).Klient);
        }

        [TestMethod]
        public void GetZdarzenieTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);

            int zdarzeniaSize = dataContext.Zdarzenia.Count;

            for (int i = 0; i < zdarzeniaSize; i++)
            {
                Assert.AreEqual(dataContext.Stany[i % (zdarzeniaSize / 2)], dataRepository.GetZdarzenie(i).Stan);
                Assert.AreEqual(dataContext.Klienci[i % (zdarzeniaSize / 2)], dataRepository.GetZdarzenie(i).Klient);
            }
        }

        [TestMethod]
        public void GetZdarzenieExceptionTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);

            Assert.ThrowsException<KeyNotFoundException>(() => dataRepository.GetZdarzenie(dataRepository.GetAllZdarzenie().Count() + 1));
        }

        [TestMethod]
        public void GetAllZdarzenie()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);

            int zdarzeniaSize = dataContext.Zdarzenia.Count;
            Assert.AreEqual(zdarzeniaSize, dataRepository.GetAllZdarzenie().ToList().Count);

            List<Zdarzenie> zdarzeniaGetAllList = dataRepository.GetAllZdarzenie().ToList();
            for (int i = 0; i < zdarzeniaGetAllList.Count; i++)
            {
                Assert.AreEqual(dataContext.Klienci[i % (zdarzeniaSize / 2)], zdarzeniaGetAllList[i].Klient);
            }
        }

        [TestMethod]
        public void UpdateZdarzenieTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);

            Zdarzenie zdarzenie = dataRepository.GetZdarzenie(0);
            Zdarzenie newZdarzenie = new Zwrot(dataRepository.GetKlient(0), dataRepository.GetStan(0));

            Assert.AreNotSame(zdarzenie, newZdarzenie);
            dataRepository.UpdateZdarzenie(0, newZdarzenie);
            Assert.AreNotSame(zdarzenie, dataRepository.GetZdarzenie(0));
            Assert.AreSame(newZdarzenie, dataRepository.GetZdarzenie(0));
        }


        [TestMethod]
        public void DeleteZdarzenieTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);

            Zdarzenie zdarzenie = dataRepository.GetZdarzenie(0);

            Assert.AreEqual(zdarzenie, dataRepository.GetZdarzenie(0));
            dataRepository.DeleteZdarzenie(zdarzenie);
            foreach (Zdarzenie z in dataRepository.GetAllZdarzenie())
            {
                Assert.AreNotEqual(zdarzenie, z);
            }
        }

        [TestMethod]
        public void DeleteZdarzenieAtTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);

            DateTime dt = DateTime.Now;
            Zdarzenie zdarzenie1 = new Wypozyczenie(dataRepository.GetKlient(0), dataRepository.GetStan(0), dt);
            Zdarzenie zdarzenie2 = new Wypozyczenie(dataRepository.GetKlient(0), dataRepository.GetStan(0), dt);
            Zdarzenie zdarzenie3 = new Wypozyczenie(dataRepository.GetKlient(0), dataRepository.GetStan(0), dt);
            dataRepository.AddZdarzenie(zdarzenie1);
            dataRepository.AddZdarzenie(zdarzenie2);
            dataRepository.AddZdarzenie(zdarzenie3);

            dataRepository.DeleteZdarzenie(zdarzenie2);
            bool isZdarzenie1 = false, isZdarzenie2 = false, isZdarzenie3 = false;
            foreach (Zdarzenie z in dataRepository.GetAllZdarzenie())
            {
                if (z == zdarzenie1)
                {
                    isZdarzenie1 = true;
                }
                if (z == zdarzenie2)
                {
                    isZdarzenie2 = true;
                }
                if (z == zdarzenie3)
                {
                    isZdarzenie3 = true;
                }
            }
            Assert.IsTrue(isZdarzenie1);
            Assert.IsFalse(isZdarzenie2);
            Assert.IsTrue(isZdarzenie3);
        }

        #endregion
    }
}
