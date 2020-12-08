using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelClasses.XmlModel;
using Serializer;
using System.IO;

namespace SerializerTests.XmlSerializerTests
{
    [TestClass]
    public class XmlModelSerializationTests
    {
        private readonly string path = ".\\XmlModel\\xmlSerializerTest.xml";

        [TestMethod]
        public void test()
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            Katalog katalog = new Katalog();
            katalog.Samochody.Add(new Samochod("Fiat", "Punto", 1997, 123951, 6536));
            katalog.Samochody.Add(new Samochod("Opel", "Kadet", 1986, 5182575, 913));
            katalog.Samochody.Add(new Samochod("Ford", "Mustang", 1968, 230498, 12637));
            katalog.Samochody.Add(new Samochod("Peugeot", "306", 2018, 1254, 71945));
            katalog.Samochody.Add(new Samochod("Tesla", "Roadster", 2020, 1273, 948325));

            XmlSerialization.Serialize(katalog, path, "Katalog.xslt");

            Katalog kolekcjaDeserialized = XmlSerialization.Deserialize<Katalog>(path);
        }
    }
}
