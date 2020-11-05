using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Zadanie1.Data;

namespace Zadanie1Tests
{
    [TestClass]
    public class WypozyczenieTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            Klient klient = new Klient("Jan", "Kowalski");
            Stan opisStanu = new Stan(new Ksiazka("Witaj swiecie", "Test"), "xyz", DateTime.Now);

            DateTime dateTimePrzed = DateTime.Now;
            Wypozyczenie wypozyczenie = new Wypozyczenie(klient, opisStanu);
            DateTime dateTimePo = DateTime.Now;

            Assert.AreEqual(klient, wypozyczenie.Klient);
            Assert.AreEqual(opisStanu, wypozyczenie.Stan);
            Assert.IsTrue(wypozyczenie.Data >= dateTimePrzed);
            Assert.IsTrue(wypozyczenie.Data <= dateTimePo);
        }

        [TestMethod]
        public void ConstructorDataTest()
        {
            Klient klient = new Klient("Jan", "Kowalski");
            Stan stan = new Stan(new Ksiazka("Witaj swiecie", "Test"), "xyz", DateTime.Now);
            DateTime dateTime = DateTime.Now;

            Wypozyczenie wypozyczenie = new Wypozyczenie(klient, stan, dateTime);

            Assert.AreEqual(klient, wypozyczenie.Klient);
            Assert.AreEqual(stan, wypozyczenie.Stan);
            Assert.AreEqual(dateTime, wypozyczenie.Data);
        }

        [TestMethod]
        public void EqualsTest()
        {
            Klient klient = new Klient("Jan", "Kowalski");
            Stan stan = new Stan(new Ksiazka("Witaj swiecie", "Test"), "xyz", DateTime.Now);
            DateTime dateTime = DateTime.Now;

            Wypozyczenie wypozyczenie1 = new Wypozyczenie(klient, stan, dateTime);
            Wypozyczenie wypozyczenie2 = new Wypozyczenie(klient, stan, dateTime);
            Zdarzenie zdarzenie = new Zdarzenie(klient, stan, dateTime);

            Assert.AreNotSame(wypozyczenie2, wypozyczenie1);
            Assert.AreEqual(wypozyczenie2, wypozyczenie1);
            Assert.AreEqual(wypozyczenie2.GetHashCode(), wypozyczenie1.GetHashCode());

            zdarzenie.Data = DateTime.Now.AddDays(1);

            Assert.AreNotSame(wypozyczenie1, zdarzenie);
            Assert.AreNotEqual(wypozyczenie1, zdarzenie);
            Assert.AreNotEqual(zdarzenie, wypozyczenie1);
            Assert.AreNotEqual(zdarzenie.GetHashCode(), wypozyczenie1.GetHashCode());
        }
    }
}
