using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Zadanie1;

namespace Zadanie1Tests
{
    [TestClass]
    public class OpisStanuTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            DateTime dateTime = DateTime.Now;
            Katalog katalog = new Katalog(1, "Witaj swiecie", "Test");
            OpisStanu opisStanu = new OpisStanu(1, katalog, "xyz", dateTime);

            Assert.AreEqual(1, opisStanu.Id);
            Assert.AreSame(katalog, opisStanu.Katalog);
            Assert.AreEqual("xyz", opisStanu.Opis);
            Assert.AreEqual(dateTime, opisStanu.DataZakupu);
        }

        [TestMethod]
        public void SetTest()
        {
            DateTime dateTime1 = DateTime.Now;
            DateTime dateTime2 = DateTime.Now.AddDays(2);
            Katalog katalog1 = new Katalog(1, "Witaj swiecie", "Test");
            Katalog katalog2 = new Katalog(2, "Swiecie witaj", "Tset");

            OpisStanu opisStanu = new OpisStanu(1, katalog1, "xyz1", dateTime1);
            opisStanu.Id = 2;
            opisStanu.Katalog = katalog2;
            opisStanu.Opis = "xyz2";
            opisStanu.DataZakupu = dateTime2;

            Assert.AreEqual(2, opisStanu.Id);
            Assert.AreSame(katalog2, opisStanu.Katalog);
            Assert.AreEqual("xyz2", opisStanu.Opis);
            Assert.AreEqual(dateTime2, opisStanu.DataZakupu);
        }

        [TestMethod]
        public void EqualsHashCodeTest()
        {
            DateTime dateTime = DateTime.Now;
            Katalog katalog = new Katalog(1, "Witaj swiecie", "Test");

            OpisStanu opisStanu = new OpisStanu(1, katalog, "xyz", dateTime);
            OpisStanu opisStanu1 = new OpisStanu(1, katalog, "xyz", dateTime);

            Assert.AreNotSame(opisStanu1, opisStanu);
            Assert.AreEqual(opisStanu1, opisStanu);
            Assert.AreEqual(opisStanu1.GetHashCode(), opisStanu.GetHashCode());

            opisStanu1.Id = 2;

            Assert.AreNotSame(opisStanu1, opisStanu);
            Assert.AreNotEqual(opisStanu1, opisStanu);
            Assert.AreNotEqual(opisStanu1.GetHashCode(), opisStanu.GetHashCode());
        }
    }
}
