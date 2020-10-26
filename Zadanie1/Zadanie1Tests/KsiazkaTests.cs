using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;

namespace Zadanie1Tests
{
    [TestClass]
    public class KsiazkaTests
    {
        [TestMethod]
        public void KsiazkaConstructorTest()
        {
            Ksiazka ksiazka = new Ksiazka(1, "TestowyTytul", "TestowyAutor");
            Assert.AreEqual(1, ksiazka.Id);
            Assert.AreEqual("TestowyTytul", ksiazka.Tytul);
            Assert.AreEqual("TestowyAutor", ksiazka.Autor);

        }

        [TestMethod]
        public void KsiazkaSetTest()
        {
            Ksiazka ksiazka= new Ksiazka(1, "TestowaNazwa", "TestowyAutor");
            ksiazka.Id = 2;
            ksiazka.Tytul = "InnyTytul";
            ksiazka.Autor = "InnyAutor";
            Assert.AreEqual(2, ksiazka.Id);
            Assert.AreEqual("InnyAutor", ksiazka.Autor);
            Assert.AreEqual("InnyTytul", ksiazka.Tytul);
        }
    }
}
