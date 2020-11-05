using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1.Data;

namespace Zadanie1Tests
{
    [TestClass]
    public class KsiazkaTests
    {
        [TestMethod]
        public void KsiazkaConstructorTest()
        {
            Ksiazka ksiazka = new Ksiazka("TestowyTytul", "TestowyAutor");
            Assert.AreEqual("TestowyTytul", ksiazka.Tytul);
            Assert.AreEqual("TestowyAutor", ksiazka.Autor);

        }

        [TestMethod]
        public void KsiazkaSetTest()
        {
            Ksiazka ksiazka= new Ksiazka("TestowaNazwa", "TestowyAutor");
            ksiazka.Tytul = "InnyTytul";
            ksiazka.Autor = "InnyAutor";
            Assert.AreEqual("InnyAutor", ksiazka.Autor);
            Assert.AreEqual("InnyTytul", ksiazka.Tytul);
        }
    }
}
