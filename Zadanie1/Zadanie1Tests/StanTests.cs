using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Zadanie1;

namespace Zadanie1Tests
{
    [TestClass]
    public class StanTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            DateTime dateTime = DateTime.Now;
            Ksiazka ksiazka = new Ksiazka(1, "Witaj swiecie", "Test");
            Stan opisStanu = new Stan(1, ksiazka, "xyz", dateTime);

            Assert.AreEqual(1, opisStanu.Id);
            Assert.AreSame(ksiazka, opisStanu.Ksiazka);
            Assert.AreEqual("xyz", opisStanu.Opis);
            Assert.AreEqual(dateTime, opisStanu.DataZakupu);
        }

        [TestMethod]
        public void SetTest()
        {
            DateTime dateTime1 = DateTime.Now;
            DateTime dateTime2 = DateTime.Now.AddDays(2);
            Ksiazka ksiazka1 = new Ksiazka(1, "Witaj swiecie", "Test");
            Ksiazka ksiazka2 = new Ksiazka(2, "Swiecie witaj", "Tset");

            Stan stan = new Stan(1, ksiazka1, "xyz1", dateTime1);
            stan.Id = 2;
            stan.Ksiazka = ksiazka2;
            stan.Opis = "xyz2";
            stan.DataZakupu = dateTime2;

            Assert.AreEqual(2, stan.Id);
            Assert.AreSame(ksiazka2, stan.Ksiazka);
            Assert.AreEqual("xyz2", stan.Opis);
            Assert.AreEqual(dateTime2, stan.DataZakupu);
        }

        [TestMethod]
        public void EqualsHashCodeTest()
        {
            DateTime dateTime = DateTime.Now;
            Ksiazka ksiazka = new Ksiazka(1, "Witaj swiecie", "Test");

            Stan stan = new Stan(1, ksiazka, "xyz", dateTime);
            Stan stan1 = new Stan(1, ksiazka, "xyz", dateTime);

            Assert.AreNotSame(stan1, stan);
            Assert.AreEqual(stan1, stan);
            Assert.AreEqual(stan1.GetHashCode(), stan.GetHashCode());

            stan1.Id = 2;

            Assert.AreNotSame(stan1, stan);
            Assert.AreNotEqual(stan1, stan);
            Assert.AreNotEqual(stan1.GetHashCode(), stan.GetHashCode());
        }
    }
}
