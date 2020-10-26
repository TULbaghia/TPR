using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;

namespace Zadanie1Tests
{
    [TestClass]
    public class KlientTests
    {
        [TestMethod]
        public void KlientConstructorTest()
        {
            Klient klient = new Klient(999, "Jan", "Kowalski");
            Assert.AreEqual(999, klient.Id);
            Assert.AreEqual("Jan", klient.Imie);
            Assert.AreEqual("Kowalski", klient.Nazwisko);
        }

        [TestMethod]
        public void KlientSetTest()
        {
            Klient klient = new Klient(999, "Jan", "Kowalski");
            klient.Id = 1000;
            klient.Imie = "Karol";
            klient.Nazwisko = "Testowy";
            Assert.AreEqual(1000, klient.Id);
            Assert.AreEqual("Karol", klient.Imie);
            Assert.AreEqual("Testowy", klient.Nazwisko);
        }
    }
}
