using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serializer;
using SerializerTests.Model;
using System;
using System.IO;

namespace SerializerTests
{
    [TestClass]
    public class Class4MySerializerTests
    {
        private readonly String path = "mySerializer.txt";

        [TestMethod]
        public void CheckDeserializedClass4Values()
        {

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            Class4 class4 = new Class4("Deskorolka", true, 4.9d);
            class4.class4 = class4;

            MySerializer mySerializer = new MySerializer();
            using FileStream fsSerialize = new FileStream(path, FileMode.Create);
            mySerializer.Serialize(fsSerialize, class4);
            fsSerialize.Close();

            using FileStream fsDeserialize = new FileStream(path, FileMode.Open);
            Class4 class4Deserialized = (Class4)mySerializer.Deserialize(fsDeserialize);
            fsDeserialize.Close();

            Assert.AreNotSame(null, class4Deserialized);
            Assert.AreNotSame(class4, class4Deserialized);

            Assert.AreEqual(class4.Text, class4Deserialized.Text);
            Assert.AreEqual(class4.Number, class4Deserialized.Number);
            Assert.AreEqual(class4.Boolean, class4Deserialized.Boolean);
        }

        [TestMethod]
        public void CheckDeserializedClass4References()
        {

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            Class4 class4 = new Class4("Deskorolka", true, 4.9d);
            class4.class4 = class4;

            MySerializer mySerializer = new MySerializer();
            using FileStream fsSerialize = new FileStream(path, FileMode.Create);
            mySerializer.Serialize(fsSerialize, class4);
            fsSerialize.Close();

            using FileStream fsDeserialize = new FileStream(path, FileMode.Open);
            Class4 class4Deserialized = (Class4)mySerializer.Deserialize(fsDeserialize);
            fsDeserialize.Close();

            Assert.AreNotSame(null, class4Deserialized);
            Assert.AreSame(class4Deserialized, class4Deserialized.class4);
        }

        [TestMethod]
        public void CheckDeserializedNullReference()
        {

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            Class4 class4 = new Class4("Deskorolka", true, 4.9d);

            MySerializer mySerializer = new MySerializer();
            using FileStream fsSerialize = new FileStream(path, FileMode.Create);
            mySerializer.Serialize(fsSerialize, class4);
            fsSerialize.Close();

            using FileStream fsDeserialize = new FileStream(path, FileMode.Open);
            Class4 class4Deserialized = (Class4)mySerializer.Deserialize(fsDeserialize);
            fsDeserialize.Close();

            Assert.AreNotSame(null, class4Deserialized);
            Assert.AreSame(null, class4Deserialized.class4);
        }

    }
}
