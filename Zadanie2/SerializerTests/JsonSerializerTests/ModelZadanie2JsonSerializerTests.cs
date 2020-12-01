using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelClasses.Zadanie2;
using Serializer;
using System;
using System.IO;

namespace SerializerTests
{
    [TestClass]
    public class ModelZadanie2JsonSerializerTests
    {
        private readonly String path = "jsonSerializer.json";

        [TestMethod]
        public void CheckDeserializedClass1Values()
        {

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            Class1 class1 = new Class1("KLASA1", DateTime.Now, 1.1d);
            Class2 class2 = new Class2("KLASA2", DateTime.Now, 2.2d);
            Class3 class3 = new Class3("KLASA3", DateTime.Now, 3.3d);

            class1.Class2 = class2;
            class1.Class3 = class3;

            class2.Class1 = class1;
            class2.Class3 = class3;

            class3.Class1 = class1;
            class3.Class2 = class2;

            JsonSerializer.Serialize(class1, path);
            Class1 class1Deserialized = JsonSerializer.Deserialize<Class1>(path);

            Assert.AreNotSame(class1, class1Deserialized);
            Assert.AreNotSame(null, class1Deserialized.Class2);
            Assert.AreNotSame(null, class1Deserialized.Class3);

            Assert.AreEqual(class3.Text, class1Deserialized.Class3.Text);
            Assert.AreEqual(class3.Number, class1Deserialized.Class3.Number);
            Assert.AreEqual(class3.DateTime.ToString(), class1Deserialized.Class3.DateTime.ToString());

            Assert.AreEqual(class2.Text, class1Deserialized.Class2.Text);
            Assert.AreEqual(class2.Number, class1Deserialized.Class2.Number);
            Assert.AreEqual(class2.DateTime.ToString(), class1Deserialized.Class2.DateTime.ToString());

            Assert.AreEqual(class1.Text, class1Deserialized.Text);
            Assert.AreEqual(class1.Number, class1Deserialized.Number);
            Assert.AreEqual(class1.DateTime.ToString(), class1Deserialized.DateTime.ToString());
        }

        [TestMethod]
        public void CheckDeserializedClass1References()
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            Class1 class1 = new Class1("KLASA1", DateTime.Now, 1.1d);
            Class2 class2 = new Class2("KLASA2", DateTime.Now, 2.2d);
            Class3 class3 = new Class3("KLASA3", DateTime.Now, 3.3d);

            class1.Class2 = class2;
            class1.Class3 = class3;

            class2.Class1 = class1;
            class2.Class3 = class3;

            class3.Class1 = class1;
            class3.Class2 = class2;

            JsonSerializer.Serialize(class1, path);
            Class1 class1Deserialized = JsonSerializer.Deserialize<Class1>(path);

            Assert.AreNotSame(class1, class1Deserialized);
            Assert.AreNotSame(null, class1Deserialized.Class2);
            Assert.AreNotSame(null, class1Deserialized.Class3);
            Assert.AreNotSame(null, class1Deserialized.Class2.Class1);
            Assert.AreNotSame(null, class1Deserialized.Class2.Class3);
            Assert.AreNotSame(null, class1Deserialized.Class3.Class2);
            Assert.AreNotSame(null, class1Deserialized.Class3.Class1);

            Assert.AreSame(class1Deserialized, class1Deserialized.Class2.Class1);
            Assert.AreSame(class1Deserialized, class1Deserialized.Class3.Class1);
            Assert.AreSame(class1Deserialized.Class2, class1Deserialized.Class3.Class2);
            Assert.AreSame(class1Deserialized.Class3, class1Deserialized.Class2.Class3);
        }

        [TestMethod]
        public void CheckDeserializedClass2Values()
        {

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            Class1 class1 = new Class1("KLASA1", DateTime.Now, 1.1d);
            Class2 class2 = new Class2("KLASA2", DateTime.Now, 2.2d);
            Class3 class3 = new Class3("KLASA3", DateTime.Now, 3.3d);

            class1.Class2 = class2;
            class1.Class3 = class3;

            class2.Class1 = class1;
            class2.Class3 = class3;

            class3.Class1 = class1;
            class3.Class2 = class2;

            JsonSerializer.Serialize(class2, path);
            Class2 class2Deserialized = JsonSerializer.Deserialize<Class2>(path);

            Assert.AreNotSame(class2, class2Deserialized);
            Assert.AreNotSame(null, class2Deserialized.Class1);
            Assert.AreNotSame(null, class2Deserialized.Class3);

            Assert.AreEqual(class3.Text, class2Deserialized.Class3.Text);
            Assert.AreEqual(class3.Number, class2Deserialized.Class3.Number);
            Assert.AreEqual(class3.DateTime.ToString(), class2Deserialized.Class3.DateTime.ToString());

            Assert.AreEqual(class2.Text, class2Deserialized.Text);
            Assert.AreEqual(class2.Number, class2Deserialized.Number);
            Assert.AreEqual(class2.DateTime.ToString(), class2Deserialized.DateTime.ToString());

            Assert.AreEqual(class1.Text, class2Deserialized.Class1.Text);
            Assert.AreEqual(class1.Number, class2Deserialized.Class1.Number);
            Assert.AreEqual(class1.DateTime.ToString(), class2Deserialized.Class1.DateTime.ToString());
        }


        [TestMethod]
        public void CheckDeserializedClass2References()
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            Class1 class1 = new Class1("KLASA1", DateTime.Now, 1.1d);
            Class2 class2 = new Class2("KLASA2", DateTime.Now, 2.2d);
            Class3 class3 = new Class3("KLASA3", DateTime.Now, 3.3d);

            class1.Class2 = class2;
            class1.Class3 = class3;

            class2.Class1 = class1;
            class2.Class3 = class3;

            class3.Class1 = class1;
            class3.Class2 = class2;

            JsonSerializer.Serialize(class2, path);
            Class2 class2Deserialized = JsonSerializer.Deserialize<Class2>(path);

            Assert.AreNotSame(class2, class2Deserialized);
            Assert.AreNotSame(null, class2Deserialized.Class1);
            Assert.AreNotSame(null, class2Deserialized.Class3);
            Assert.AreNotSame(null, class2Deserialized.Class1.Class2);
            Assert.AreNotSame(null, class2Deserialized.Class1.Class3);
            Assert.AreNotSame(null, class2Deserialized.Class3.Class2);
            Assert.AreNotSame(null, class2Deserialized.Class3.Class1);

            Assert.AreSame(class2Deserialized, class2Deserialized.Class1.Class2);
            Assert.AreSame(class2Deserialized, class2Deserialized.Class3.Class2);
            Assert.AreSame(class2Deserialized.Class1, class2Deserialized.Class3.Class1);
            Assert.AreSame(class2Deserialized.Class3, class2Deserialized.Class1.Class3);
        }

        [TestMethod]
        public void CheckDeserializedClass3Values()
        {

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            Class1 class1 = new Class1("KLASA1", DateTime.Now, 1.1d);
            Class2 class2 = new Class2("KLASA2", DateTime.Now, 2.2d);
            Class3 class3 = new Class3("KLASA3", DateTime.Now, 3.3d);

            class1.Class2 = class2;
            class1.Class3 = class3;

            class2.Class1 = class1;
            class2.Class3 = class3;

            class3.Class1 = class1;
            class3.Class2 = class2;

            JsonSerializer.Serialize(class3, path);
            Class3 class3Deserialized = JsonSerializer.Deserialize<Class3>(path);

            Assert.AreNotSame(class2, class3Deserialized);
            Assert.AreNotSame(null, class3Deserialized.Class1);
            Assert.AreNotSame(null, class3Deserialized.Class2);

            Assert.AreEqual(class1.Text, class3Deserialized.Class1.Text);
            Assert.AreEqual(class1.Number, class3Deserialized.Class1.Number);
            Assert.AreEqual(class1.DateTime.ToString(), class3Deserialized.Class1.DateTime.ToString());

            Assert.AreEqual(class2.Text, class3Deserialized.Class2.Text);
            Assert.AreEqual(class2.Number, class3Deserialized.Class2.Number);
            Assert.AreEqual(class2.DateTime.ToString(), class3Deserialized.Class2.DateTime.ToString());

            Assert.AreEqual(class3.Text, class3Deserialized.Text);
            Assert.AreEqual(class3.Number, class3Deserialized.Number);
            Assert.AreEqual(class3.DateTime.ToString(), class3Deserialized.DateTime.ToString());
        }


        [TestMethod]
        public void CheckDeserializedClass3References()
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            Class1 class1 = new Class1("KLASA1", DateTime.Now, 1.1d);
            Class2 class2 = new Class2("KLASA2", DateTime.Now, 2.2d);
            Class3 class3 = new Class3("KLASA3", DateTime.Now, 3.3d);

            class1.Class2 = class2;
            class1.Class3 = class3;

            class2.Class1 = class1;
            class2.Class3 = class3;

            class3.Class1 = class1;
            class3.Class2 = class2;

            JsonSerializer.Serialize(class3, path);
            Class3 class3Deserialized = JsonSerializer.Deserialize<Class3>(path);

            Assert.AreNotSame(class3, class3Deserialized);
            Assert.AreNotSame(null, class3Deserialized.Class1);
            Assert.AreNotSame(null, class3Deserialized.Class2);
            Assert.AreNotSame(null, class3Deserialized.Class2.Class1);
            Assert.AreNotSame(null, class3Deserialized.Class2.Class3);
            Assert.AreNotSame(null, class3Deserialized.Class1.Class2);
            Assert.AreNotSame(null, class3Deserialized.Class1.Class3);

            Assert.AreSame(class3Deserialized, class3Deserialized.Class2.Class3);
            Assert.AreSame(class3Deserialized, class3Deserialized.Class1.Class3);
            Assert.AreSame(class3Deserialized.Class1, class3Deserialized.Class2.Class1);
            Assert.AreSame(class3Deserialized.Class2, class3Deserialized.Class1.Class2);
        }



    }
}
