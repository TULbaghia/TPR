using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelClasses.Zadanie1.Data;
using Serializer;
using System;
using System.Linq;

namespace SerializerTests
{
    [TestClass]
    public class ModelZadanie1JsonSerializerTests
    {
        private readonly String path = "jsonSerializer.json";

        [TestMethod]
        public void CheckDeserializedModel()
        {
            DataContext dataContext = new DataContext();
            IDataFiller dataFiller = new TestDataFiller();
            dataFiller.Fill(dataContext);
            JsonSerializer.Serialize(dataContext, path);

            DataContext dataContextDeserialized = JsonSerializer.Deserialize<DataContext>(path);

            CollectionAssert.AreEqual(dataContext.Klienci, dataContextDeserialized.Klienci);
            CollectionAssert.AreEqual(dataContext.Ksiazki, dataContextDeserialized.Ksiazki);
            CollectionAssert.AreEqual(dataContext.Stany, dataContextDeserialized.Stany);
            CollectionAssert.AreEqual(dataContext.Zdarzenia, dataContextDeserialized.Zdarzenia);
        }

        [TestMethod]
        public void CheckDeserializedModelEmpty()
        {
            DataContext dataContext = new DataContext();
            JsonSerializer.Serialize(dataContext, path);

            DataContext dataContextDeserialized = JsonSerializer.Deserialize<DataContext>(path);

            CollectionAssert.AreEqual(dataContext.Klienci, dataContextDeserialized.Klienci);
            CollectionAssert.AreEqual(dataContext.Ksiazki, dataContextDeserialized.Ksiazki);
            CollectionAssert.AreEqual(dataContext.Stany, dataContextDeserialized.Stany);
            CollectionAssert.AreEqual(dataContext.Zdarzenia, dataContextDeserialized.Zdarzenia);

            Assert.AreEqual(0, dataContextDeserialized.Klienci.Count());
            Assert.AreEqual(0, dataContextDeserialized.Ksiazki.Count());
            Assert.AreEqual(0, dataContextDeserialized.Stany.Count());
            Assert.AreEqual(0, dataContextDeserialized.Zdarzenia.Count());
        }
    }
}
