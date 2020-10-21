using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;

namespace Zadanie1Tests
{
    [TestClass]
    public class KatalogTests
    {
        [TestMethod]
        public void KatalogConstructorTest()
        {
            Katalog katalog = new Katalog(1, "TestowaNazwa", "TestowyProducent");
            Assert.AreEqual(1, katalog.Id);
            Assert.AreEqual("TestowaNazwa", katalog.Nazwa);
            Assert.AreEqual("TestowyProducent", katalog.Producent);

        }

        [TestMethod]
        public void KatalogSetTest()
        {
            Katalog katalog = new Katalog(1, "TestowaNazwa", "TestowyProducent");
            katalog.Id = 2;
            katalog.Producent = "InnyProducent";
            katalog.Nazwa = "InnaNazwa";
            Assert.AreEqual(2, katalog.Id);
            Assert.AreEqual("InnyProducent", katalog.Producent);
            Assert.AreEqual("InnaNazwa", katalog.Nazwa);
        }
    }
}
