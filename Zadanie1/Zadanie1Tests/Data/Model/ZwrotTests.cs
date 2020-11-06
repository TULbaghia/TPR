using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Zadanie1.Data;

namespace Zadanie1Tests
{
    [TestClass]
    public class ZwrotTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            Klient klient = new Klient("Jan", "Kowalski");
            Stan stan = new Stan(new Ksiazka("Witaj swiecie", "Test"), "xyz", DateTime.Now);

            DateTime dateTimePrzed = DateTime.Now;
            Zwrot wypozyczenie = new Zwrot(klient, stan);
            DateTime dateTimePo = DateTime.Now;

            Assert.AreEqual(klient, wypozyczenie.Klient);
            Assert.AreEqual(stan, wypozyczenie.Stan);
            Assert.IsTrue(wypozyczenie.Data >= dateTimePrzed);
            Assert.IsTrue(wypozyczenie.Data <= dateTimePo);
        }

        [TestMethod]
        public void ConstructorDataTest()
        {
            Klient klient = new Klient("Jan", "Kowalski");
            Stan stan = new Stan(new Ksiazka("Witaj swiecie", "Test"), "xyz", DateTime.Now);
            DateTime dateTime = DateTime.Now;

            Zwrot wypozyczenie = new Zwrot(klient, stan, dateTime);

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

            Zwrot zwrot1 = new Zwrot(klient, stan, dateTime);
            Zwrot zwrot2 = new Zwrot(klient, stan, dateTime);
            Zdarzenie zdarzenie = new Wypozyczenie(klient, stan, dateTime);

            Assert.AreNotSame(zwrot2, zwrot1);
            Assert.AreEqual(zwrot2, zwrot1);
            Assert.AreEqual(zwrot2.GetHashCode(), zwrot1.GetHashCode());

            Assert.AreNotSame(zwrot1, zdarzenie);
            Assert.AreNotEqual(zwrot1, zdarzenie);
            Assert.AreEqual(zdarzenie, zwrot1);
            Assert.AreNotEqual(zdarzenie.GetHashCode(), zwrot1.GetHashCode());
        }
    }
}
