using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1.Data;

namespace Zadanie1Tests.Data
{
    [TestClass]
    public class DataFillerTests
    {

        [TestMethod]
        public void WypelnianieStalymiTest()
        {
            IDataFiller wypelnianieStalymi = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieStalymi, dataContext);

            Assert.AreEqual(10, dataContext.Klienci.Count);
            Assert.AreEqual(10, dataContext.Ksiazki.Count);
            Assert.AreEqual(10, dataContext.Stany.Count);
            Assert.AreEqual(20, dataContext.Zdarzenia.Count);
        }

        [TestMethod]
        public void WypelnianieLosowymiTest()
        {
            IDataFiller wypelnianieLosowymi = new WypelnianieLosowymi();
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(wypelnianieLosowymi, dataContext);

            Assert.AreEqual(10, dataContext.Klienci.Count);
            Assert.AreEqual(10, dataContext.Ksiazki.Count);
            Assert.AreEqual(10, dataContext.Stany.Count);
            Assert.AreEqual(20, dataContext.Zdarzenia.Count);
        }
    }
}
