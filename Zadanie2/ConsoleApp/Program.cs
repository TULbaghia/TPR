using ModelClasses;
using Serializer;
using System;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            File.Delete("mySerializer.txt");
            File.Delete("mySerializer2.txt");

            Class1 class1 = new Class1("KLASA1", DateTime.Now, 1.1d);
            Class2 class2 = new Class2("KLASA2", DateTime.Now, 2.2d);
            Class3 class3 = new Class3("KLASA3", DateTime.Now, 3.3d);

            class1.Class2 = class2;
            class1.Class3 = class3;

            class2.Class1 = class1;
            class2.Class3 = class3;

            class3.Class1 = class1;
            class3.Class2 = class2;

            MySerializer mySerializer = new MySerializer();
            using FileStream fs = new FileStream("mySerializer.txt", FileMode.OpenOrCreate);
            using FileStream fs2 = new FileStream("mySerializer2.txt", FileMode.OpenOrCreate);

            Class4 class4 = new Class4();
            class4.class4 = class4;
            mySerializer.Serialize(fs, class1);
            mySerializer.Serialize(fs2, class4);

            fs.Close();
            fs2.Close();


            using FileStream fsDes = new FileStream("mySerializer.txt", FileMode.Open);
            using FileStream fs2Des = new FileStream("mySerializer2.txt", FileMode.Open);
            Class1 class4Deserialized = (Class1)mySerializer.Deserialize(fsDes);
            Class4 stringDeserialized = (Class4)mySerializer.Deserialize(fs2Des);

            JsonSerializer.Serialize(class4, "test.json");
            Console.WriteLine("Zakonczono");
            Console.WriteLine(Directory.GetCurrentDirectory());

            Class1 class1Deserialized = JsonSerializer.Deserialize<Class1>("test.json");

            Console.WriteLine("Otrzymano: ");
            Console.ReadKey();
        }
    }
}
