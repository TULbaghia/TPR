using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;
using Zadanie1.Data;

namespace Zadanie1Tests
{
    [TestClass]
    public class DataFillerTests
    {

        [TestMethod]
        public void WypelnianieStalymiTest()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi(), new DataContext());

            Assert.AreEqual(10, dataRepository.DataContext.Klienci.Count);
            Assert.AreEqual(10, dataRepository.DataContext.Ksiazki.Count);
            Assert.AreEqual(10, dataRepository.DataContext.Stany.Count);
            Assert.AreEqual(20, dataRepository.DataContext.Zdarzenia.Count);
        }
    }
}
