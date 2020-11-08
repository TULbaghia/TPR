using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Zadanie1.Data;

namespace Zadanie1Tests.Data
{
    [TestClass]
    public class StanTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            DateTime dateTime = DateTime.Now;
            Ksiazka ksiazka = new Ksiazka("Witaj swiecie", "Test");
            Stan opisStanu = new Stan(ksiazka, "xyz", false, dateTime);

            Assert.AreSame(ksiazka, opisStanu.Ksiazka);
            Assert.AreEqual("xyz", opisStanu.Opis);
            Assert.AreEqual(dateTime, opisStanu.DataZakupu);
        }

        [TestMethod]
        public void SetTest()
        {
            DateTime dateTime1 = DateTime.Now;
            DateTime dateTime2 = DateTime.Now.AddDays(2);
            Ksiazka ksiazka1 = new Ksiazka("Witaj swiecie", "Test");
            Ksiazka ksiazka2 = new Ksiazka("Swiecie witaj", "Tset");

            Stan stan = new Stan(ksiazka1, "xyz", false, dateTime1);
            stan.Ksiazka = ksiazka2;
            stan.Opis = "xyz2";
            stan.DataZakupu = dateTime2;

            Assert.AreSame(ksiazka2, stan.Ksiazka);
            Assert.AreEqual("xyz2", stan.Opis);
            Assert.AreEqual(dateTime2, stan.DataZakupu);
        }

        [TestMethod]
        public void EqualsHashCodeTest()
        {
            DateTime dateTime = DateTime.Now;
            Ksiazka ksiazka = new Ksiazka("Witaj swiecie", "Test");

            Stan stan = new Stan(ksiazka, "xyz", false, dateTime);
            Stan stan1 = new Stan(ksiazka, "xyz", false, dateTime);

            Assert.AreNotSame(stan1, stan);
            Assert.AreEqual(stan1, stan);
            Assert.AreEqual(stan1.GetHashCode(), stan.GetHashCode());

            stan1.DataZakupu = DateTime.Now;

            Assert.AreNotSame(stan1, stan);
            Assert.AreNotEqual(stan1, stan);
            Assert.AreNotEqual(stan1.GetHashCode(), stan.GetHashCode());
        }
    }
}
