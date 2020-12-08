using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelClasses.XmlModel;
using Serializer;
using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace SerializerTests
{
    [TestClass]
    public class XmlModelSerializationTests
    {
        private readonly string path = ".\\XmlModel\\xmlSerializerTest.xml";

        [TestMethod]
        public void CheckDeserializedXmlModelTest()
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            Katalog katalog = new Katalog();
            TestXmlDataFiller testXmlDataFiller = new TestXmlDataFiller();
            testXmlDataFiller.Fill(katalog);

            XmlSerialization.Serialize(katalog, path, "Katalog.xslt");

            Katalog kolekcjaDeserialized = XmlSerialization.Deserialize<Katalog>(path);

            Assert.AreNotSame(katalog, kolekcjaDeserialized);
            Assert.AreNotSame(null, kolekcjaDeserialized.Samochody);
            Assert.AreNotSame(katalog.Samochody, kolekcjaDeserialized.Samochody);

            CollectionAssert.AreEqual(katalog.Samochody, kolekcjaDeserialized.Samochody);
        }

        [TestMethod]
        public void CheckValidationXmlModelPositiveTest()
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            Katalog katalog = new Katalog();
            TestXmlDataFiller testXmlDataFiller = new TestXmlDataFiller();
            testXmlDataFiller.Fill(katalog);

            XmlSerialization.Serialize(katalog, path, "Katalog.xslt");
            
            XmlSerialization.ValidateXml(".\\XmlModel\\KatalogSchema.xsd", path);
        }

        [TestMethod]
        public void CheckValidationXmlModelNegativeTest()
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            Katalog katalog = new Katalog();
            TestXmlDataFiller testXmlDataFiller = new TestXmlDataFiller();
            testXmlDataFiller.Fill(katalog);

            XmlSerialization.Serialize(katalog, path, "Katalog.xslt");

            XmlDocument document = new XmlDocument();
            document.Load(path);
            XmlNode root = document.DocumentElement;
            document.GetElementsByTagName("Samochod")[0].AppendChild(document.CreateNode("element", "pages", ""));
            document.Save(path);

            Assert.ThrowsException<XmlSchemaValidationException>(() => XmlSerialization.ValidateXml(".\\XmlModel\\KatalogSchema.xsd", path));
        }

        [TestMethod]
        public void CheckTransformationXmlModelTest()
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            Katalog katalog = new Katalog();
            TestXmlDataFiller testXmlDataFiller = new TestXmlDataFiller();
            testXmlDataFiller.Fill(katalog);

            XmlSerialization.Serialize(katalog, path, "Katalog.xslt");

            XmlSerialization.XsltTransform(".\\XmlModel\\Katalog.xslt", path, "htmlTest.html");

            Assert.IsTrue(File.Exists("htmlTest.html"));
        }
    }
}
