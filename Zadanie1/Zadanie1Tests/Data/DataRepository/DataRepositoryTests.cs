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
            Assert.Inconclusive();
        }


        [TestMethod]
        public void DeleteKlientTest()
        {
            Assert.Inconclusive();
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
            Assert.Inconclusive();
        }


        [TestMethod]
        public void DeleteKsiazkaTest()
        {
            Assert.Inconclusive();
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
        public void AddStanTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());
            Ksiazka ksiazka = new Ksiazka("TytulTest", "AutorTest");
            Stan stan = new Stan(ksiazka, "OpisTest", new DateTime(2020, 10, 10, 10, 10, 10));

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
            Assert.Inconclusive();
        }


        [TestMethod]
        public void DeleteStanTest()
        {
            Assert.Inconclusive();
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
        public void AddWypozyczenieTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());

            Klient klient = new Klient("Jan", "NazwiskoWypozyczenie");
            Ksiazka ksiazka = new Ksiazka("Tytul", "AutorWypozyczenie");
            Stan stan = new Stan(ksiazka, "OpisWypozyczenie");
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
            Stan stan = new Stan(ksiazka, "OpisZwrot");
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
            Assert.Inconclusive();
        }
    }
}
