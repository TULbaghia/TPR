using System;
using Serializer;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonSerializer.Serialize("ZSERIALIZE", "test.json");
            Console.WriteLine("Zakonczono");
            Console.WriteLine(Directory.GetCurrentDirectory());
            Console.WriteLine("Otrzymano: " + JsonSerializer.Deserialize<String>("test.json"));
            Console.ReadKey();
        }
    }
}
