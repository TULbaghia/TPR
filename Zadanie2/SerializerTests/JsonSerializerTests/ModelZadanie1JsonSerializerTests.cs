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
        private readonly String path = "mySerializer.txt";

        [TestMethod]
        public void CheckDeserializedModel()
        {
            DataContext dataContext = new DataContext();
            IDataFiller dataFiller = new TestDataFiller();
            dataFiller.Fill(dataContext);
            JsonSerializer.Serialize(dataContext, path);

            DataContext dataContextDeserialized = JsonSerializer.Deserialize<DataContext>(path);

            Assert.IsTrue(Enumerable.SequenceEqual(dataContext.Klienci, dataContextDeserialized.Klienci));
            Assert.IsTrue(Enumerable.SequenceEqual(dataContext.Ksiazki, dataContextDeserialized.Ksiazki));
            Assert.IsTrue(Enumerable.SequenceEqual(dataContext.Stany, dataContextDeserialized.Stany));
            Assert.IsTrue(Enumerable.SequenceEqual(dataContext.Zdarzenia, dataContextDeserialized.Zdarzenia));
        }
    }
}
