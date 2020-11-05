using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1.Data;

namespace Zadanie1Tests
{
    [TestClass]
    public class KlientTests
    {
        [TestMethod]
        public void KlientConstructorTest()
        {
            Klient klient = new Klient("Jan", "Kowalski");
            Assert.AreEqual("Jan", klient.Imie);
            Assert.AreEqual("Kowalski", klient.Nazwisko);
        }

        [TestMethod]
        public void KlientSetTest()
        {
            Klient klient = new Klient("Jan", "Kowalski");
            klient.Imie = "Karol";
            klient.Nazwisko = "Testowy";
            Assert.AreEqual("Karol", klient.Imie);
            Assert.AreEqual("Testowy", klient.Nazwisko);
        }
    }
}
