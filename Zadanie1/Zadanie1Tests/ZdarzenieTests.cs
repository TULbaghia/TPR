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
            Wykaz wykaz = new Wykaz(1, "Jan", "Kowalski");
            OpisStanu opisStanu = new OpisStanu(1, new Katalog(1, "Witaj swiecie", "Test"), "xyz", DateTime.Now);

            DateTime dateTimePrzed = DateTime.Now;
            Zdarzenie zdarzenie = new Zdarzenie(1, wykaz, opisStanu);
            DateTime dateTimePo = DateTime.Now;

            Assert.AreEqual(1, zdarzenie.Id);
            Assert.AreEqual(wykaz, zdarzenie.Wykaz);
            Assert.AreEqual(opisStanu, zdarzenie.OpisStanu);
            Assert.IsTrue(zdarzenie.Data >= dateTimePrzed);
            Assert.IsTrue(zdarzenie.Data <= dateTimePo);
        }

        [TestMethod]
        public void ConstructorzDataTest()
        {
            Wykaz wykaz = new Wykaz(1, "Jan", "Kowalski");
            OpisStanu opisStanu = new OpisStanu(1, new Katalog(1, "Witaj swiecie", "Test"), "xyz", DateTime.Now);
            DateTime dateTime = DateTime.Now;

            Zdarzenie zdarzenie = new Zdarzenie(1, wykaz, opisStanu, dateTime);

            Assert.AreEqual(1, zdarzenie.Id);
            Assert.AreEqual(wykaz, zdarzenie.Wykaz);
            Assert.AreEqual(opisStanu, zdarzenie.OpisStanu);
            Assert.AreEqual(dateTime, zdarzenie.Data);
        }

        [TestMethod]
        public void SetTest()
        {
            Wykaz wykaz1 = new Wykaz(1, "Jan", "Kowalski");
            Wykaz wykaz2 = new Wykaz(2, "Jan", "Kowalski");
            OpisStanu opisStanu1 = new OpisStanu(1, new Katalog(1, "Witaj swiecie", "Test"), "xyz", DateTime.Now);
            OpisStanu opisStanu2 = new OpisStanu(2, new Katalog(1, "Witaj swiecie", "Test"), "xyz", DateTime.Now);
            DateTime dateTime1 = DateTime.Now;
            DateTime dateTime2 = DateTime.Now.AddDays(1);

            Zdarzenie zdarzenie = new Zdarzenie(1, wykaz1, opisStanu1, dateTime1);
            zdarzenie.Id = 2;
            zdarzenie.Wykaz = wykaz2;
            zdarzenie.OpisStanu = opisStanu2;
            zdarzenie.Data = dateTime2;

            Assert.AreEqual(2, zdarzenie.Id);
            Assert.AreEqual(wykaz2, zdarzenie.Wykaz);
            Assert.AreEqual(opisStanu2, zdarzenie.OpisStanu);
            Assert.AreEqual(dateTime2, zdarzenie.Data);
        }
    }
}
