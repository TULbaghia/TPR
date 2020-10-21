using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;

namespace Zadanie1Tests
{
    [TestClass]
    public class WykazTests
    {
        [TestMethod]
        public void WykazConstructorTest()
        {
            Wykaz wykaz = new Wykaz("999", "Jan", "Kowalski");
            Assert.AreEqual("999", wykaz.Id);
            Assert.AreEqual("Jan", wykaz.Imie);
            Assert.AreEqual("Kowalski", wykaz.Nazwisko);
        }

        [TestMethod]
        public void WykazSetTest()
        {
            Wykaz wykaz = new Wykaz("999", "Jan", "Kowalski");
            wykaz.Id = "1000";
            wykaz.Imie = "Karol";
            wykaz.Nazwisko = "Testowy";
            Assert.AreEqual("1000", wykaz.Id);
            Assert.AreEqual("Karol", wykaz.Imie);
            Assert.AreEqual("Testowy", wykaz.Nazwisko);
        }
    }
}
