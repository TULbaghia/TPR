﻿using ModelClasses;
using Serializer;
using System;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath;
            Class1 class1Deserialized = new Class1();
            Class1 class1DeserializedJson = new Class1();
            //DataContext dataContext = new DataContext();

            Console.WriteLine("         Zadanie 2 - Serializacja        \r");
            Console.WriteLine("-----------------------------------------\n");
            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("Custom");
            Console.WriteLine("\t1 - Personal graph custom serialization");
            Console.WriteLine("\t2 - Personal graph custom deserialization");
            Console.WriteLine("\t3 - Show deserialized custom graph ");
            Console.WriteLine("JSON");
            Console.WriteLine("\t4 - DataContext JSON serialization");
            Console.WriteLine("\t5 - DataContext JSON deserialization");
            Console.WriteLine("\t6 - Show deserialized JSON object");
            Console.WriteLine("0 - Exit");

            do
            {
                Console.Write("\nYour choice: ");
                switch (Console.ReadLine())
                {
                    #region MySerializer options
                    case "1":
                        {
                            Console.Write("Enter file path: ");
                            filePath = Console.ReadLine();
                            if (File.Exists(filePath))
                            {
                                File.Delete(filePath);
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
                            MySerializer mySerializer = new MySerializer();
                            using FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
                            mySerializer.Serialize(fs, class1);
                            Console.WriteLine("> Serialization done");
                            fs.Close();
                            break;
                        }
                    case "2":
                        {
                            Console.Write("Enter file path: ");
                            filePath = Console.ReadLine();
                            if (File.Exists(filePath))
                            {
                                MySerializer mySerializer = new MySerializer();
                                using FileStream fsDes = new FileStream(filePath, FileMode.Open);
                                class1Deserialized = (Class1)mySerializer.Deserialize(fsDes);
                                Console.WriteLine("> Deserialization done");
                                fsDes.Close();
                            }
                            else
                            {
                                Console.WriteLine("> Given filePath does not exist");
                            }
                            break;
                        }
                    case "3":
                        {
                            if (class1Deserialized.Class2 == null)
                            {
                                Console.WriteLine("> You should deserialize the class first");
                            }
                            else Console.WriteLine(class1Deserialized.ToString());
                            break;
                        }
                    #endregion

                    #region JsonSerializer options
                    case "4":
                        {
                            // now Class1, todo: DataContext
                            Console.Write("Enter file path: ");
                            filePath = Console.ReadLine();
                            if (File.Exists(filePath))
                            {
                                File.Delete(filePath);
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
                            JsonSerializer.Serialize(class1, filePath);
                            Console.WriteLine("> Serialization done");
                            break;
                        }
                    case "5":
                        {
                            // now Class1, todo: DataContext
                            Console.Write("Enter file path: ");
                            filePath = Console.ReadLine();
                            if (File.Exists(filePath))
                            {
                                class1DeserializedJson = (Class1)JsonSerializer.Deserialize<Class1>(filePath);
                                Console.WriteLine("> Deserialization done");
                            }
                            else
                            {
                                Console.WriteLine("> Given filePath does not exist");
                            }
                            break;
                        }
                    case "6":
                        {
                            // now Class1, todo: DataContext
                            if (class1DeserializedJson.Class2 == null)
                            {
                                Console.WriteLine("> You should deserialize the class first");
                            }
                            else Console.WriteLine(class1DeserializedJson.ToString());
                            break;
                        }
                    #endregion

                    #region Options handling
                    case "0":
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("> Unknown option");
                            break;
                        }
                    #endregion
                }

            } while (true);
        }
    }
}
