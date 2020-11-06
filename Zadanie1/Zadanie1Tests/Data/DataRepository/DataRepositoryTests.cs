using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
