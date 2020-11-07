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
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);

            Assert.AreEqual(10, dataRepository.DataContext.Klienci.Count);
            Assert.AreEqual(10, dataRepository.DataContext.Ksiazki.Count);
            Assert.AreEqual(10, dataRepository.DataContext.Stany.Count);
            Assert.AreEqual(20, dataRepository.DataContext.Zdarzenia.Count);
        }

        [TestMethod]
        public void WypelnianieLosowymiTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);

            Assert.AreEqual(10, dataRepository.DataContext.Klienci.Count);
            Assert.AreEqual(10, dataRepository.DataContext.Ksiazki.Count);
            Assert.AreEqual(10, dataRepository.DataContext.Stany.Count);
            Assert.AreEqual(20, dataRepository.DataContext.Zdarzenia.Count);
        }
    }
}
