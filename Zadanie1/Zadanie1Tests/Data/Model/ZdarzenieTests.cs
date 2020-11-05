using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Zadanie1.Data;

namespace Zadanie1Tests
{
    [TestClass]
    public class ZdarzenieTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            Klient klient = new Klient("Jan", "Kowalski");
            Stan stan = new Stan(new Ksiazka("Witaj swiecie", "Test"), "xyz", DateTime.Now);

            DateTime dateTimePrzed = DateTime.Now;
            Zdarzenie zdarzenie = new Zdarzenie(klient, stan);
            DateTime dateTimePo = DateTime.Now;

            Assert.AreEqual(klient, zdarzenie.Klient);
            Assert.AreEqual(stan, zdarzenie.Stan);
            Assert.IsTrue(zdarzenie.Data >= dateTimePrzed);
            Assert.IsTrue(zdarzenie.Data <= dateTimePo);
        }

        [TestMethod]
        public void ConstructorDataTest()
        {
            Klient klient = new Klient("Jan", "Kowalski");
            Stan stan = new Stan(new Ksiazka("Witaj swiecie", "Test"), "xyz", DateTime.Now);
            DateTime dateTime = DateTime.Now;

            Zdarzenie zdarzenie = new Zdarzenie(klient, stan, dateTime);

            Assert.AreEqual(klient, zdarzenie.Klient);
            Assert.AreEqual(stan, zdarzenie.Stan);
            Assert.AreEqual(dateTime, zdarzenie.Data);
        }

        [TestMethod]
        public void SetTest()
        {
            Klient klient1 = new Klient("Jan", "Kowalski");
            Klient klient2 = new Klient("Jan", "Kowalski");
            Stan stan1 = new Stan(new Ksiazka("Witaj swiecie", "Test"), "xyz", DateTime.Now);
            Stan stan2 = new Stan(new Ksiazka("Witaj swiecie", "Test"), "xyz", DateTime.Now);
            DateTime dateTime1 = DateTime.Now;
            DateTime dateTime2 = DateTime.Now.AddDays(1);

            Zdarzenie zdarzenie = new Zdarzenie(klient1, stan1, dateTime1);
            zdarzenie.Klient = klient2;
            zdarzenie.Stan = stan2;
            zdarzenie.Data = dateTime2;

            Assert.AreEqual(klient2, zdarzenie.Klient);
            Assert.AreEqual(stan2, zdarzenie.Stan);
            Assert.AreEqual(dateTime2, zdarzenie.Data);
        }

        [TestMethod]
        public void EqualsHashCodeTest()
        {
            Klient wykaz = new Klient("Jan", "Kowalski");
            DateTime dateTime = DateTime.Now;
            Stan opisStanu = new Stan(new Ksiazka("Witaj swiecie", "Test"), "xyz", dateTime);

            Zdarzenie zdarzenie = new Zdarzenie(wykaz, opisStanu, dateTime);
            Zdarzenie zdarzenie1 = new Zdarzenie(wykaz, opisStanu, dateTime);

            Assert.AreNotSame(zdarzenie, zdarzenie1);
            Assert.AreEqual(zdarzenie, zdarzenie1);
            Assert.AreEqual(zdarzenie.GetHashCode(), zdarzenie1.GetHashCode());

            zdarzenie1.Data = DateTime.Now.AddDays(1);

            Assert.AreNotSame(zdarzenie, zdarzenie1);
            Assert.AreNotEqual(zdarzenie, zdarzenie1);
            Assert.AreNotEqual(zdarzenie.GetHashCode(), zdarzenie1.GetHashCode());
        }
    }
}
