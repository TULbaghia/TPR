using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Zadanie1;

namespace Zadanie1Tests
{
    [TestClass]
    public class ZdarzenieTests
    {
        [TestMethod]
        public void ConstructorBezDatyTest()
        {
            Klient klient = new Klient(1, "Jan", "Kowalski");
            Stan stan = new Stan(1, new Ksiazka(1, "Witaj swiecie", "Test"), "xyz", DateTime.Now);

            DateTime dateTimePrzed = DateTime.Now;
            Zdarzenie zdarzenie = new Zdarzenie(1, klient, stan);
            DateTime dateTimePo = DateTime.Now;

            Assert.AreEqual(1, zdarzenie.Id);
            Assert.AreEqual(klient, zdarzenie.Klient);
            Assert.AreEqual(stan, zdarzenie.Stan);
            Assert.IsTrue(zdarzenie.Data >= dateTimePrzed);
            Assert.IsTrue(zdarzenie.Data <= dateTimePo);
        }

        [TestMethod]
        public void ConstructorzDataTest()
        {
            Klient klient = new Klient(1, "Jan", "Kowalski");
            Stan stan = new Stan(1, new Ksiazka(1, "Witaj swiecie", "Test"), "xyz", DateTime.Now);
            DateTime dateTime = DateTime.Now;

            Zdarzenie zdarzenie = new Zdarzenie(1, klient, stan, dateTime);

            Assert.AreEqual(1, zdarzenie.Id);
            Assert.AreEqual(klient, zdarzenie.Klient);
            Assert.AreEqual(stan, zdarzenie.Stan);
            Assert.AreEqual(dateTime, zdarzenie.Data);
        }

        [TestMethod]
        public void SetTest()
        {
            Klient klient1 = new Klient(1, "Jan", "Kowalski");
            Klient klient2 = new Klient(2, "Jan", "Kowalski");
            Stan stan1 = new Stan(1, new Ksiazka(1, "Witaj swiecie", "Test"), "xyz", DateTime.Now);
            Stan stan2 = new Stan(2, new Ksiazka(1, "Witaj swiecie", "Test"), "xyz", DateTime.Now);
            DateTime dateTime1 = DateTime.Now;
            DateTime dateTime2 = DateTime.Now.AddDays(1);

            Zdarzenie zdarzenie = new Zdarzenie(1, klient1, stan1, dateTime1);
            zdarzenie.Id = 2;
            zdarzenie.Klient = klient2;
            zdarzenie.Stan = stan2;
            zdarzenie.Data = dateTime2;

            Assert.AreEqual(2, zdarzenie.Id);
            Assert.AreEqual(klient2, zdarzenie.Klient);
            Assert.AreEqual(stan2, zdarzenie.Stan);
            Assert.AreEqual(dateTime2, zdarzenie.Data);
        }
    }
}
