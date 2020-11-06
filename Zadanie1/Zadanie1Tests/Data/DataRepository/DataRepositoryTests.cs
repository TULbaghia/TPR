﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Zadanie1.Data;

namespace Zadanie1Tests
{
    [TestClass]
    public class DataRepositoryTests
    {
        // Klient
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

            dataRepository.UpdateKlient(0, "Karol", "Update");
            Assert.AreEqual(dataRepository.GetKlient(0).Imie, "Karol");
            Assert.AreEqual(dataRepository.GetKlient(0).Nazwisko, "Update");
        }

        [TestMethod]
        public void DeleteKlientTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());

            Klient klient = dataRepository.GetKlient(0);

            Assert.AreEqual(dataRepository.GetKlient(0), klient);
            dataRepository.DeleteKlient(klient);
            foreach (Klient k in dataRepository.GetAllKlient())
            {
                Assert.AreNotEqual(k, klient);
            }
        }

        // Ksiazka
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

            dataRepository.UpdateKsiazka(0, "UpdateTytul", "UpdateAutor");
            Assert.AreEqual(dataRepository.GetKsiazka(0).Autor, "UpdateAutor");
            Assert.AreEqual(dataRepository.GetKsiazka(0).Tytul, "UpdateTytul");
        }

        [TestMethod]
        public void DeleteKsiazkaTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());

            Ksiazka ksiazka = dataRepository.GetKsiazka(0);

            Assert.AreEqual(dataRepository.GetKsiazka(0), ksiazka);
            dataRepository.DeleteKsiazka(ksiazka);
            foreach (Ksiazka k in dataRepository.GetAllKsiazka())
            {
                Assert.AreNotEqual(k, ksiazka);
            }
        }

        // Stan
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

            dataRepository.UpdateStan(dataRepository.GetKsiazka(0), "UpdateOpisu", 999, new DateTime(2000, 01, 01, 01, 01, 01));

            foreach (Stan stan in dataRepository.GetAllStan())
            {
                if (stan.Ksiazka.Equals(dataRepository.GetKsiazka(0)))
                {
                    Assert.AreEqual(stan.Opis, "UpdateOpisu");
                    Assert.AreEqual(stan.Ilosc, 999);
                    Assert.AreEqual(stan.DataZakupu, new DateTime(2000, 01, 01, 01, 01, 01));
                }
            }

        }


        [TestMethod]
        public void DeleteStanTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());

            Stan stan = dataRepository.GetStan(0);

            Assert.AreEqual(dataRepository.GetStan(0), stan);
            dataRepository.DeleteStan(stan);
            foreach (Stan s in dataRepository.GetAllStan())
            {
                Assert.AreNotEqual(s, stan);
            }
        }

        // Zdarzenie
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
            Assert.Inconclusive();
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
    }
}
