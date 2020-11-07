using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Zadanie1.Data;

namespace Zadanie1Tests
{
    [TestClass]
    public class DataRepositoryTests
    {
        #region Klient

        [TestMethod]
        public void AddKlientTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());
            Klient klient = new Klient("Jan", "Testowy");

            int klienciSize = dataRepository.DataContext.Klienci.Count;
            dataRepository.AddKlient(klient);

            Assert.AreEqual(dataRepository.DataContext.Klienci.Count, klienciSize + 1);
            Assert.AreEqual(dataRepository.GetKlient(klienciSize).Imie, "Jan");
            Assert.AreEqual(dataRepository.GetKlient(klienciSize).Nazwisko, "Testowy");
        }

        [TestMethod]
        public void GetKlientTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());

            for (int i = 0; i < dataRepository.DataContext.Klienci.Count; i++)
            {
                Assert.AreEqual(dataRepository.GetKlient(i).Imie, "Jan" + i);
                Assert.AreEqual(dataRepository.GetKlient(i).Nazwisko, "Testowy" + i);
            }
        }

        [TestMethod]
        public void GetKlientExceptionTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());

            Assert.ThrowsException<KeyNotFoundException>( () => dataRepository.GetKlient(dataRepository.GetAllKlient().Count() + 1) );
        }

        [TestMethod]
        public void GetAllKlientTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());

            Assert.AreEqual(dataRepository.GetAllKlient().ToList().Count, dataRepository.DataContext.Klienci.Count);

            List<Klient> klientGetAllList = dataRepository.GetAllKlient().ToList();
            for (int i = 0; i < klientGetAllList.Count; i++)
            {
                Assert.AreEqual(klientGetAllList[i].Imie, "Jan" + i);
            }
        }

        [TestMethod]
        public void UpdateKlientTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());

            Klient klient = dataRepository.GetKlient(0);
            Klient newKlient = new Klient("Jan_newKlient", "Testowy_newKlient");

            Assert.AreNotSame(klient, newKlient);
            dataRepository.UpdateKlient(0, newKlient);
            Assert.AreSame(klient, dataRepository.GetKlient(0));
            Assert.AreEqual(klient, newKlient);
        }

        [TestMethod]
        public void UpdateKlientExceptionTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());

            Klient klient = dataRepository.GetKlient(0);
            Klient newKlient = new Klient("Jan_newKlient", "Testowy_newKlient");

            Assert.ThrowsException<KeyNotFoundException>( () => dataRepository.UpdateKlient(dataRepository.GetAllKlient().Count()+1, newKlient) );
        }

        [TestMethod]
        public void DeleteKlientTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());

            Klient klient = new Klient("Jan", "Kowalski");
            dataRepository.AddKlient(klient);

            Assert.AreSame(dataRepository.GetKlient(dataRepository.GetAllKlient().Count()-1), klient);
            dataRepository.DeleteKlient(klient);
            foreach (Klient k in dataRepository.GetAllKlient())
            {
                Assert.AreNotSame(k, klient);
            }
        }

        [TestMethod]
        public void DeleteKlientExceptionTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());

            Klient klient = dataRepository.GetKlient(0);
            dataRepository.AddZdarzenie(new Wypozyczenie(klient, dataRepository.GetStan(0)));

            Assert.AreSame(dataRepository.GetKlient(0), klient);
            Assert.ThrowsException<Exception>(() => dataRepository.DeleteKlient(klient));
        }

        [TestMethod]
        public void DeleteKlientAtTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());

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
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());
            Ksiazka ksiazka = new Ksiazka("TytulTest", "AutorTest");

            int ksiazkiSize = dataRepository.DataContext.Ksiazki.Count;
            dataRepository.AddKsiazka(ksiazka);

            Assert.AreEqual(dataRepository.DataContext.Ksiazki.Count, ksiazkiSize + 1);
            Assert.AreEqual(dataRepository.GetKsiazka(ksiazkiSize).Tytul, "TytulTest");
            Assert.AreEqual(dataRepository.GetKsiazka(ksiazkiSize).Autor, "AutorTest");
        }

        [TestMethod]
        public void AddKsiazkaExceptionTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());
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
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());

            for (int i = 0; i < dataRepository.DataContext.Ksiazki.Count; i++)
            {
                Assert.AreEqual(dataRepository.GetKsiazka(i).Tytul, "TestowyTytul" + i);
                Assert.AreEqual(dataRepository.GetKsiazka(i).Autor, "TestowyAutor" + i);
            }
        }

        [TestMethod]
        public void GetKsiazkaExceptionTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());

            Assert.ThrowsException<KeyNotFoundException>(() => dataRepository.GetKsiazka(dataRepository.GetAllKsiazka().Count() + 1));
        }

        [TestMethod]
        public void GetAllKsiazkaTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());

            Assert.AreEqual(dataRepository.GetAllKsiazka().ToList().Count, dataRepository.DataContext.Ksiazki.Count);

            List<Ksiazka> ksiazkaGetAllList = dataRepository.GetAllKsiazka().ToList();
            for (int i = 0; i < ksiazkaGetAllList.Count; i++)
            {
                Assert.AreEqual(ksiazkaGetAllList[i].Tytul, "TestowyTytul" + i);
            }
        }

        [TestMethod]
        public void UpdateKsiazkaTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());
            Ksiazka ksiazka = dataRepository.GetKsiazka(0);
            Ksiazka newKsiazka = new Ksiazka("TytulTest", "AutorTest");

            Assert.AreNotSame(ksiazka, newKsiazka);
            dataRepository.UpdateKsiazka(0, newKsiazka);
            Assert.AreSame(ksiazka, dataRepository.GetKsiazka(0));
            Assert.AreEqual(ksiazka, newKsiazka);
        }

        [TestMethod]
        public void UpdateKsiazkaExceptionTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());
            Ksiazka ksiazka1 = new Ksiazka("TytulTest", "AutorTest");
            Ksiazka ksiazka2 = new Ksiazka("TytulTest1", "AutorTest1");
            dataRepository.AddKsiazka(ksiazka1);
            dataRepository.AddKsiazka(ksiazka2);
            Ksiazka newKsiazka = new Ksiazka("TytulTest", "AutorTest");

            Assert.ThrowsException<Exception>(() => dataRepository.UpdateKsiazka(ksiazka2.Id, newKsiazka));
        }

        [TestMethod]
        public void DeleteKsiazkaTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());

            Ksiazka ksiazka = new Ksiazka("test", "ksiazka");
            dataRepository.AddKsiazka(ksiazka);

            Assert.AreEqual(dataRepository.GetKsiazka(dataRepository.GetAllKsiazka().Count()-1), ksiazka);
            dataRepository.DeleteKsiazka(ksiazka);
            foreach (Ksiazka k in dataRepository.GetAllKsiazka())
            {
                Assert.AreNotEqual(k, ksiazka);
            }
        }

        [TestMethod]
        public void DeleteKsiazkaExceptionTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());

            Ksiazka ksiazka = dataRepository.GetKsiazka(0);
            dataRepository.AddStan(new Stan(ksiazka, "", 1));

            Assert.AreSame(dataRepository.GetKsiazka(0), ksiazka);
            Assert.ThrowsException<Exception>(() => dataRepository.DeleteKsiazka(ksiazka));
        }

        #endregion

        #region Stan

        [TestMethod]
        public void AddStanTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());
            Ksiazka ksiazka = new Ksiazka("TytulTest", "AutorTest");
            Stan stan = new Stan(ksiazka, "OpisTest", 1, new DateTime(2020, 10, 10, 10, 10, 10));

            int stanySize = dataRepository.DataContext.Stany.Count;
            dataRepository.AddStan(stan);

            Assert.AreEqual(dataRepository.DataContext.Stany.Count, stanySize + 1);
            Assert.AreEqual(dataRepository.GetStan(stanySize).Ksiazka.Tytul, "TytulTest");
            Assert.AreEqual(dataRepository.GetStan(stanySize).Opis, "OpisTest");
            Assert.AreEqual(dataRepository.GetStan(stanySize).DataZakupu, new DateTime(2020, 10, 10, 10, 10, 10));
        }

        [TestMethod]
        public void GetStanTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());

            for (int i = 0; i < dataRepository.DataContext.Stany.Count; i++)
            {
                Assert.AreEqual(dataRepository.GetStan(i).Ksiazka, dataRepository.DataContext.Ksiazki[i]);
                Assert.AreEqual(dataRepository.GetStan(i).Opis, "TestowyOpis" + i);
                Assert.AreEqual(dataRepository.GetStan(i).DataZakupu, new DateTime(2020, 10, i + 1, 13, i + 1, 30));
            }
        }

        [TestMethod]
        public void GetStanExceptionTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());

            Assert.ThrowsException<KeyNotFoundException>(() => dataRepository.GetStan(dataRepository.GetAllStan().Count() + 1));
        }

        [TestMethod]
        public void GetAllStan()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());

            Assert.AreEqual(dataRepository.GetAllStan().ToList().Count, dataRepository.DataContext.Stany.Count);

            List<Stan> stanGetAllList = dataRepository.GetAllStan().ToList();
            for (int i = 0; i < stanGetAllList.Count; i++)
            {
                Assert.AreEqual(stanGetAllList[i].Opis, "TestowyOpis" + i);
            }
        }

        [TestMethod]
        public void UpdateStanTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());
            Stan stan = dataRepository.GetStan(0);
            Stan newStan = new Stan(stan.Ksiazka, "xyz", 0);

            Assert.AreNotSame(stan, newStan);
            dataRepository.UpdateStan(0, newStan);
            Assert.AreSame(stan, dataRepository.GetStan(0));
            Assert.AreEqual(stan, newStan);
        }

        [TestMethod]
        public void UpdateStanExceptionTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());
            Stan stan = dataRepository.GetStan(0);
            Stan newStan = new Stan(stan.Ksiazka, "xyz", -1);

            Assert.ThrowsException<Exception>(() => dataRepository.UpdateStan(0, newStan));
        }

        [TestMethod]
        public void DeleteStanTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());

            Stan stan = new Stan(dataRepository.GetKsiazka(0), "x", 1);
            dataRepository.AddStan(stan);

            Assert.AreEqual(dataRepository.GetStan(dataRepository.GetAllStan().Count() - 1), stan);
            dataRepository.DeleteStan(stan);
            foreach (Stan s in dataRepository.GetAllStan())
            {
                Assert.AreNotEqual(s, stan);
            }
        }

        [TestMethod]
        public void DeleteStanAlreadyUsedExceptionTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());

            Stan stan = dataRepository.GetStan(0);
            Zdarzenie zdarzenie = new Wypozyczenie(dataRepository.GetKlient(0), stan);

            Assert.ThrowsException<Exception>(() => dataRepository.DeleteStan(stan));
        }

        [TestMethod]
        public void DeleteStanAtTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());

            DateTime dt = DateTime.Now;
            Stan stan1 = new Stan(dataRepository.GetKsiazka(0), "x", 1, dt);
            Stan stan2 = new Stan(dataRepository.GetKsiazka(0), "x", 1, dt);
            Stan stan3 = new Stan(dataRepository.GetKsiazka(0), "x", 1, dt);
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
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());

            Klient klient = new Klient("Jan", "NazwiskoWypozyczenie");
            Ksiazka ksiazka = new Ksiazka("Tytul", "AutorWypozyczenie");
            Stan stan = new Stan(ksiazka, "OpisWypozyczenie", 1);
            Zdarzenie wypozyczenie = new Wypozyczenie(klient, stan);

            int zdarzeniaSize = dataRepository.DataContext.Zdarzenia.Count;
            dataRepository.AddZdarzenie(wypozyczenie);

            Assert.AreEqual(dataRepository.DataContext.Zdarzenia.Count, zdarzeniaSize + 1);
            Assert.AreEqual(dataRepository.GetZdarzenie(zdarzeniaSize).Stan, stan);
            Assert.AreEqual(dataRepository.GetZdarzenie(zdarzeniaSize).Klient, klient);
        }

        [TestMethod]
        public void AddZwrotTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());

            int zdarzeniaSize = dataRepository.DataContext.Zdarzenia.Count;
            Klient klient = new Klient("Jan", "NazwiskoZwrot");
            Ksiazka ksiazka = new Ksiazka("Tytul", "AutorZwrot");
            Stan stan = new Stan(ksiazka, "OpisZwrot", 1);
            Zdarzenie zwrot = new Zwrot(klient, stan);

            dataRepository.AddZdarzenie(zwrot);

            Assert.AreEqual(dataRepository.DataContext.Zdarzenia.Count, zdarzeniaSize + 1);
            Assert.AreEqual(dataRepository.GetZdarzenie(zdarzeniaSize).Stan, stan);
            Assert.AreEqual(dataRepository.GetZdarzenie(zdarzeniaSize).Klient, klient);
        }

        [TestMethod]
        public void GetZdarzenieTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());

            int zdarzeniaSize = dataRepository.DataContext.Zdarzenia.Count;

            for (int i = 0; i < zdarzeniaSize; i++)
            {
                Assert.AreEqual(dataRepository.GetZdarzenie(i).Stan, dataRepository.DataContext.Stany[i % (zdarzeniaSize / 2)]);
                Assert.AreEqual(dataRepository.GetZdarzenie(i).Klient, dataRepository.DataContext.Klienci[i % (zdarzeniaSize / 2)]);
            }
        }

        [TestMethod]
        public void GetZdarzenieExceptionTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());

            Assert.ThrowsException<KeyNotFoundException>(() => dataRepository.GetZdarzenie(dataRepository.GetAllZdarzenie().Count() + 1));
        }

        [TestMethod]
        public void GetAllZdarzenie()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());

            int zdarzeniaSize = dataRepository.DataContext.Zdarzenia.Count;
            Assert.AreEqual(dataRepository.GetAllZdarzenie().ToList().Count, zdarzeniaSize);

            List<Zdarzenie> zdarzeniaGetAllList = dataRepository.GetAllZdarzenie().ToList();
            for (int i = 0; i < zdarzeniaGetAllList.Count; i++)
            {
                Assert.AreEqual(zdarzeniaGetAllList[i].Klient, dataRepository.DataContext.Klienci[i % (zdarzeniaSize / 2)]);
            }
        }

        [TestMethod]
        public void UpdateZdarzenieTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());
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
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());

            Zdarzenie zdarzenie = dataRepository.GetZdarzenie(0);

            Assert.AreEqual(dataRepository.GetZdarzenie(0), zdarzenie);
            dataRepository.DeleteZdarzenie(zdarzenie);
            foreach (Zdarzenie z in dataRepository.GetAllZdarzenie())
            {
                Assert.AreNotEqual(z, zdarzenie);
            }
        }

        [TestMethod]
        public void DeleteZdarzenieAtTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());

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
