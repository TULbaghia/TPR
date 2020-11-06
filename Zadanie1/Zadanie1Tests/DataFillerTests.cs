using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Zadanie1.Data;
using Zadanie1.Logic;

namespace Zadanie1Tests
{
    [TestClass]
    public class DataFillerTests
    {

        [TestMethod]
        public void WypelnianieStalymiTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, new DataContext());

            Assert.AreEqual(10, dataRepository.DataContext.Klienci.Count);
            Assert.AreEqual(10, dataRepository.DataContext.Ksiazki.Count);
            Assert.AreEqual(10, dataRepository.DataContext.Stany.Count);
            Assert.AreEqual(20, dataRepository.DataContext.Zdarzenia.Count);
        }

        [TestMethod]
        public void WypelnianieLosowymiTest()
        {
            WypelnianieLosowymi wypelnianieLosowymi = new WypelnianieLosowymi();
            DataRepository dataRepository = new DataRepository(wypelnianieLosowymi, new DataContext());

            Assert.AreEqual(10, dataRepository.DataContext.Klienci.Count);
            Assert.AreEqual(10, dataRepository.DataContext.Ksiazki.Count);
            Assert.AreEqual(10, dataRepository.DataContext.Stany.Count);
            Assert.AreEqual(20, dataRepository.DataContext.Zdarzenia.Count);
        }
    }
}
